using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Entities;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
  [Route("[controller]")]
  public class ValuesController : Controller
  {
    // GET: api/<controller>
    [Authorize]
    [HttpGet("getLookupData")]
    public ActionResult Get()
    {
      return Json(
      new
      {
        countries = new[] {
            new {key = 1 , text = "Argentina", value = "Argentinaaaa"},
            new {key = 2 , text = "Uruguay", value = "Uruguayyyy"},
            //new {Id = 3 , name = "Paraguay", optional = "asdfasdf"},
            //new {Id = 4 , name = "Bolivia", optional = "vbnmvbmvbn"},
            //new {Id = 5 , name = "Venezuela", optional = "asdfasdf"},
            //new {Id = 6 , name = "Peru", optional = "vbnmvbmvbn"},
            //new {Id = 7 , name = "Ecuador", optional = "vbnmvbmvbn"},
            //new {Id = 8 , name = "Brazil", optional = "asdfasdf"},
            //new {Id = 9 , name = "Colombia", optional = "vbnmvbmvbn"},
          },
        cities = new[] {
            new {Id = 1 , name = "Buenos Aires", optional = "asdfasdf"},
            new {Id = 2 , name = "Montevideo", optional = "vbnmvbmvbn"}
          },
      }
      );
     // return Json(data);
     
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "value";
    }

    // POST api/<controller>
    [HttpPost("formpost")]
    public ActionResult Post([FromBody]Form formData)
    {
      try
      {
        if(formData.Quantity == 1)
        {
          throw new Exception("exeption thrown case 1");
        }
        else if(formData.Quantity == 2)
        {
          throw new Exception("exeption thrown case 2");
        }
        else
        {
          return Json("Todo Bien");
        }
    
      }
      catch(Exception ex)
      {
      //  string msg = ex.Message;
        return Json(ex);

      } 
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
