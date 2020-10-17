using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Data;
using OrdersManager.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdersManager
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext model;
        public ProductController(ApplicationDbContext model)
        {
            this.model = model;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("addNewProduct")]
        public JsonResult Post([FromBody]ProductAddDTO body)
        {

            //this.model.Database.ExecuteSqlCommand("DELETE FROM [Products]");
            model.SaveChanges();
            var newModel = model.Add(new Product()
            {
                Name = body.ProductName,
                Price = body.ProductPrice
            }).Entity;
            model.SaveChanges();
            return Json(newModel);
        }

        [HttpPost]
        [Route("updateProduct")]
        public JsonResult Update([FromBody]ProductAddDTO body)
        {
            var newModel = model.Update(new Product()
            {
                Id = body.Id,
                Name = body.ProductName,
                Price = body.ProductPrice
            }).Entity;
            model.SaveChanges();
            return Json(newModel);
        }

        [HttpGet]
        [Route("getAllProducts")]
        public JsonResult GetAllProducts()
        {
            return Json(model.Products.Select(s => s).ToList());
        }

        [HttpPost]
        [Route("deleteProduct")]
        public JsonResult Delete([FromBody]ProductAddDTO body)
        {
            var newModel = model.Remove(new Product()
            {
                Id = body.Id,
                Name = body.ProductName,
                Price = body.ProductPrice
            }).Entity;
            model.SaveChanges();
            return Json(newModel);
        }
    }
}
