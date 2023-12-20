using System;
namespace BasicAPI.Models
{
    public class UpdateProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
