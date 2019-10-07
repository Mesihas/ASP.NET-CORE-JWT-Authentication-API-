using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Entities;
using WebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// netsh http add urlacl url=http://10.0.1.109:49786/ user=\Everyone
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
            new {key = 3 , text = "Paraguay", value = "asdfasdf"},
            new {key = 4 , text = "Bolivia", value = "vbnmvbmvbn"},
            new {key = 5 , text = "Venezuela", value = "asdfasdf"},
            new {key = 6 , text = "Peru", value = "vbnmvbmvbn"},
            new {key = 7 , text = "Ecuador", value = "vbnmvbmvbn"},
            new {key = 8 , text = "Brazil", value = "asdfasdf"},
            new {key = 9 , text = "Colombia", value = "vbnmvbmvbn"},
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
