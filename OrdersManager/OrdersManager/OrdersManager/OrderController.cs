using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Data;
using OrdersManager.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdersManager
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        // GET: api/<controller>
        private readonly ApplicationDbContext model;
        public OrderController(ApplicationDbContext model)
        {
            this.model = model;
        }

        [HttpGet]
        [Route("getAllOrders")]
        public ContentResult GetAllOrders()
        {
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;

            var resultData = model.Orders.Include(o => o.OrderProducts).ThenInclude(o => o.Product).ToList();
            resultData.ForEach(m=>m.OrderProducts.ToList().ForEach(s=>s.Order=null));
            var results = resultData.Select(s => new OrderSelectDTO(){Id = s.Id,PersonResponsible = s.PersonResponsible, CreateDate = s.CreateDate.ToString("yyyy MM dd") });
            var result = new ContentResult
            {
                Content = serializer.Serialize(results),
                ContentType = "application/json",
            };
            return result;

        }

        [HttpPost]
        [Route("addNewOrder")]
        public int AddNewOrder([FromBody]OrderAddDTO body)
        {
            var order = model.Orders.Add(new Order()
            {
                PersonResponsible = body.OrderPerson,
                CreateDate = DateTime.UtcNow
            }).Entity;
            model.SaveChanges();
            var listOfProducts = body.OrderProductIds
                .Select(p => new OrderProducts() {ProductId = p, Quantity = 0, OrderId = order.Id}).ToList();
            model.AddRange(listOfProducts);
            model.SaveChanges();
            return order.Id;
        }

        [HttpPost]
        [Route("deleteOrder")]
        public JsonResult Delete([FromBody]OrderAddDTO body)
        {
            var newModel = model.Remove(new Order()
            {
                Id = body.Id,
                PersonResponsible = body.OrderPerson,
                CreateDate= DateTime.UtcNow
            }).Entity;
            model.SaveChanges();
            return Json(newModel);
        }

    }
}
