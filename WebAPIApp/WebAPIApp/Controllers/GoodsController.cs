using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIApp.Models;
using System.Linq;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        public static List<Goods> Goods = new List<Goods>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Goods);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                //LinQ (object) query    
                var goods = Goods.SingleOrDefault(g => g.GoodsId == Guid.Parse(id));
                if (goods == null)
                {
                    return NotFound();
                }
                return Ok(goods);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPost]
        public IActionResult Create(GoodsVM goodsVM)
        {
            var goods = new Goods
            {
                GoodsId = Guid.NewGuid(),
                GoodsName = goodsVM.GoodsName,
                UnitPrice = goodsVM.UnitPrice
            };
            Goods.Add(goods);
            return Ok(new
            {
                Success = true,
                Data = goods
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(string id, Goods goodsEdit)
        {
            try
            {
                //LinQ (object) query    
                var goods = Goods.SingleOrDefault(g => g.GoodsId == Guid.Parse(id));
                if (goods == null)
                {
                    return NotFound();
                }
                if(goodsEdit.GoodsId.ToString() != id)
                {
                    return BadRequest();
                }
                //update
                goods.GoodsName = goodsEdit.GoodsName;
                goods.UnitPrice = goodsEdit.UnitPrice;
                return Ok(goods);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Remove(string id)  
        {
            try
            {
                //LinQ (object) query    
                var goods = Goods.SingleOrDefault(g => g.GoodsId == Guid.Parse(id));
                if (goods == null)
                {
                    return NotFound();
                }
                //delete
                Goods.Remove(goods);
                return Ok(goods);
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
