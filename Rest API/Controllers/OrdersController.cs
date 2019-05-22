using AutoMapper;
using SampleAPI.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class OrdersController : ApiController
    {
        // GET api/orders
        [SwaggerOperation("GetAll")]
        public IHttpActionResult Get()
        {
            using (var db = new DBEntities())
            {
                var data = (from o in db.Orders
                            join oi in db.OrderItems on o.Id.ToString() equals oi.OrderId
                            join u in db.Users on o.UserId equals u.Id.ToString()
                            select new { o.Id, o.TransactionDate, u.Firstname, u.Lastname, u.City, u.State, oi.Qty, oi.SalePrice } into temp
                            group temp by new { temp.Id, temp.TransactionDate, temp.Firstname, temp.Lastname, temp.City, temp.State } into answer
                            select new OrderDTO
                            {
                                Id = answer.Key.Id.ToString(),
                                TransactionDate = answer.Key.TransactionDate,
                                Customer = answer.Key.Firstname + ", " + answer.Key.Lastname,
                                Total = answer.Sum(x => x.Qty * x.SalePrice),
                                City = answer.Key.City,
                                State = answer.Key.State
                            }).ToList();
                return Ok(data);
            }
        }

        // GET api/orders/1/items
        [SwaggerOperation("GetItemsByOrder")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult GetItems(string id)
        {
            using (var db = new DBEntities())
            {
                var data = (from oi in db.OrderItems
                            join p in db.Products on oi.ProductId equals p.Id.ToString()
                            where oi.OrderId == id
                            select new
                            {
                                p.Name,
                                p.ImageUrl,
                                Price = oi.SalePrice,
                                oi.Qty,
                                Total = oi.SalePrice * oi.Qty
                            }).ToList();

                if (data == null)
                    return NotFound();

                return Ok(data);
            }
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]OrderCreateDTO orderCreateDTO)
        {
            using (var db = new DBEntities())
            {
                // Create the user
                var newUser = Mapper.Map<User>(orderCreateDTO.User);
                newUser.Id = Guid.NewGuid();
                
                // Create the order and map the user 
                Order newOrder = new Order();
                newOrder.Id = Guid.NewGuid();
                newOrder.UserId = newUser.Id.ToString();
                newOrder.TransactionDate = DateTime.UtcNow;

                // Add each item in the order
                foreach (var item in orderCreateDTO.Items)
                {
                    var product = db.Products.Where(p => p.Id.ToString() == item.ProductId).Single();
                    
                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderId = newOrder.Id.ToString();
                    orderItem.ProductId = product.Id.ToString();
                    orderItem.Qty = item.Qty;
                    orderItem.PurchasePrice = product.PurchasePrice;
                    orderItem.SalePrice = product.SalePrice;
                    db.OrderItems.Add(orderItem);
                }
                db.SaveChanges();
            }
        }
    }
}
