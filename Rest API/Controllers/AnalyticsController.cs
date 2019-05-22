using Swashbuckle.Swagger.Annotations;
using System.Linq;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class AnalyticsController : ApiController
    {
        // GET api/analytics
        [SwaggerOperation("GetSales")]
        public IHttpActionResult Get()
        {
            using (var db = new DBEntities())
            {
                var numberOfUsers = db.Users.Count();
                var numberOfOrders = db.Orders.Count();
                var totalSales = db.OrderItems.Sum(oi => oi.SalePrice * oi.Qty);

                var salesByItem = (from oi in db.OrderItems
                                   join p in db.Products on oi.ProductId equals p.Id.ToString()
                                   select new { p.Name, oi.Qty, oi.SalePrice } into temp
                                   group temp by new { temp.Name } into answer
                                   select new
                                   {
                                       ProductName = answer.Key.Name,
                                       Count = answer.Sum(x => x.Qty),
                                       Sales = answer.Sum(x => x.Qty * x.SalePrice)
                                   }).ToList();

                return Ok(new
                        {
                           NumberOfUsers = numberOfUsers,
                           NumberOfOrders = numberOfOrders,
                           TotalSales = totalSales,
                           SalesByProduct = salesByItem
                        });
            }
        }
    }
}
