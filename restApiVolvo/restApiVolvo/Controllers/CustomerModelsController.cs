using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using restApiVolvo.Models;

namespace restApiVolvo.Controllers
{
    public class CustomerModelsController : ApiController
    {

        List<CustomerModel> customers = new List<CustomerModel>
        {
            new CustomerModel {Id=1, Name="Jose", Surname="Bouldin", Birthdate="1995-08-05", Email="jose.bouldin@mail.com", Gender="Male" },
            new CustomerModel {Id=2, Name="Tawnya", Surname="Delk", Birthdate="1992-02-01", Email="tawnya.delk@mail.com", Gender="Female" },
            new CustomerModel {Id=3, Name="Cari", Surname="Holt", Birthdate="1997-12-11", Email="cari.holt@mail.com", Gender="Female" },
            new CustomerModel {Id=4, Name="Tameika", Surname="Kash", Birthdate="1974-10-17", Email="tameika.kash@mail.com", Gender="Female" },
            new CustomerModel {Id=5, Name="Alberto", Surname="Hydrick", Birthdate="1982-06-24", Email="alberto.hydric@mail.com", Gender="Male" }
        };

        // GET: api/CustomerModels
        [HttpGet]
        public IEnumerable<CustomerModel> GetCustomerModels()
        {

            return customers;
        }

        // GET: api/CustomerModels/5
        [HttpGet]
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult GetCustomerModel(int id)
        {
            var customer = customers.FirstOrDefault((p) => p.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/CustomerModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerModel(int id, CustomerModel customerModel)
        {
            var customer = customers.FirstOrDefault((p) => p.Id == id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerModel.Id)
            {
                return BadRequest();
            }

            customer.Name = customerModel.Name;
            customer.Surname = customerModel.Surname;
            customer.Email = customerModel.Email;
            customer.Birthdate = customerModel.Birthdate;
            customer.Gender = customerModel.Gender;

            return Ok(customers);
        }

        // POST: api/CustomerModels
        [HttpPost]
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult PostCustomerModel(CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customers.Add(customerModel);
            customers.ToList().Add(customerModel);

            return Ok(customers);
        }

        // DELETE: api/CustomerModels/5
        [HttpDelete]
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult DeleteCustomerModel(int id)
        {
            var customer = customers.FirstOrDefault((p) => p.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            customers.Remove(customer);

            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
        //        db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerModelExists(int id)
        {
            return customers.Count(e => e.Id == id) > 0;
        }
    }
}