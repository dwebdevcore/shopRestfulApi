using System.Collections.Generic;

namespace shopdevAPI.Models
{
    public class OrderCreateDTO
    {
        public UserDTO User { get; set; }
        public List<PurchaseItemDTO> Items { get; set; }
    }

    public class PurchaseItemDTO
    {
        public string ProductId { get; set; }
        public int Qty { get; set; }
    }
}