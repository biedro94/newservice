using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using testbiedro.Models;

namespace testbiedro.Controllers
{
    public class ProductsController : ApiController
    {
        private testbiedroContext db = new testbiedroContext();

        // GET: api/Products

        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        [HttpPost]
        [Route("api/Order/{Client_Name}/{Table_number}/{Status}")]
        public int AddOrder(string Client_Name, int Table_number, int Status)
        {

            string query = "INSERT INTO Orders(Client_Name,Table_Number,Order_Date,Status) VALUES(@p0,@p1,GetDate(),@p2)";

            SqlParameter p0 = new SqlParameter("p0", Client_Name);
            SqlParameter p1 = new SqlParameter("p1", Table_number);
            SqlParameter p2 = new SqlParameter("p2", Status);

            object[] parameter = new object[] { p0,p1,p2 };

            int result = db.Database.ExecuteSqlCommand(query, parameter);
            return result;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Product_Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Product_Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Product_Id == id) > 0;
        }
    }
}