using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Tassk;
using api.Mappers;
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
            var tasks = _context.Tasks.ToList()
            .Select(s => s.ToTasskDto() );
            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id){
             var task = _context.Tasks.Find(id);

               if(task == null){
                   return NotFound();
               }

             return Ok(task.ToTasskDto());
        }


        [HttpPost]

        public IActionResult Create([FromBody] CreateTasskDto TasskDto){
            var TasskModel = TasskDto.ToTasskFromCreateDto();
            _context.Tasks.Add(TasskModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = TasskModel.Id}, TasskModel.ToTasskDto());
        }


        [HttpPut]
        [Route("{id:int}")]

        public IActionResult update([FromRoute] int id, [FromBody] UpdateTasskDto TasskDto){

            var TasskModel = _context.Tasks.FirstOrDefault(x => x.Id == id);

            if(TasskModel == null){
                return NotFound();
            }

            TasskModel.TaskListId = TasskDto.TaskListId;
            TasskModel.Title = TasskDto.Title;
            TasskModel.Description = TasskDto.Description;
            TasskModel.Deadline = TasskDto.Deadline;
            TasskModel.IsCompleted = TasskDto.IsCompleted;
            TasskModel.IsDeleted = TasskDto.IsDeleted;
            TasskModel.updatedAt = TasskDto.updatedAt;

            _context.SaveChanges();

            return Ok(TasskModel.ToTasskDto());

        }
        
    }


}