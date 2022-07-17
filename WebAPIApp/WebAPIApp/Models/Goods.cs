using System;

namespace WebAPIApp.Models
{
    public class GoodsVM
    {
        public string GoodsId { get; set; }
        public string GoodsName { get; set; }
        public double UnitPrice { get; set; }
    }
    public class Goods : GoodsVM
    {
        public Guid GoodsId { get; set; }
    }
}
