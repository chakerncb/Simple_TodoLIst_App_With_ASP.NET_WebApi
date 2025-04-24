using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TasksController(ApplicationDBContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
             var task = _context.Tasks.Find(id);

               if(task == null){
                   return NotFound();
               }

             return Ok(task);
        }
        
    }
}