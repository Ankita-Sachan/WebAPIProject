using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;
using System.Web.Http.Cors;

namespace WebAPIProject.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            DataEntities entities = new DataEntities();
return entities.Employees.ToList();

        }
        public HttpResponseMessage LoadAllEmployeWithId(int id)
        {
            using (DataEntities entities = new DataEntities())
            {
                var emp = entities.Employees.Where(x => x.ID == id).FirstOrDefault();
                if (emp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id =" + id + "is not found.");
                }
            }
        }


        public HttpResponseMessage Put([FromBody] Employee emp, int id)
        {
            using (DataEntities entities = new DataEntities())
            {
                var employ = entities.Employees.Where(x => x.ID == id).FirstOrDefault();
                if (employ != null)
                {
                    employ.FirstName = emp.FirstName;
                    employ.LastName = emp.LastName;
                    employ.City = emp.City;
                    employ.Gender = emp.Gender;
                    entities.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, employ);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id =" + id + "is not found.");
                }
            }
        }
        public HttpResponseMessage Post([FromBody] Employee emp)
        {
            try
            {
                using (DataEntities entities = new DataEntities())
                {
                    entities.Employees.Add(emp);
                    entities.SaveChanges();
                    var msg = Request.CreateResponse(HttpStatusCode.Created, emp, Configuration.Formatters.JsonFormatter);
                    msg.Headers.Location = new Uri(Request.RequestUri + emp.ID.ToString());
                    return msg;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            using (DataEntities entities = new DataEntities())
            {
                var emp = entities.Employees.FirstOrDefault(x => x.ID == id);
                try
                {
                    if (emp != null)
                    {
                        entities.Employees.Remove(emp);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, "Deleted Succsfully");
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employe with Id " + id + " is not found.");
                    }
                }
                catch
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Employe with Id " + id + " is not found.");
                }
            }
        }
    }
}