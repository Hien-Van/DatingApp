using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public ValuesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var value = await dataContext.Values.ToListAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = dataContext.Values.FirstOrDefault(x => x.Id == id);
            return Ok(value);
        }
    }
}