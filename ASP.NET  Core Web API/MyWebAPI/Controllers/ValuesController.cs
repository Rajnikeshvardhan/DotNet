using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //localhost:1234/api/values
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return Employee.GetAllEmployees();
        }
        //localhost:1234/api/values/123
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return Employee.GetSingleEmployee(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Employee obj)
        {
           
            Employee.Insert(obj);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee obj)
        {
            Employee.UpdateWithStoredProcedure(obj);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee.Delete(id);
        }
    }
}
