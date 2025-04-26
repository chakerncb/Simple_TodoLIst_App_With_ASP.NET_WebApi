using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Tassk;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll(){
            var tasks = await _context.Tasks.ToListAsync();

            var taskDtos = tasks.Select(s => s.ToTasskDto());
            
            return Ok(taskDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
             var task = await _context.Tasks.FindAsync(id);

               if(task == null){
                   return NotFound();
               }

             return Ok(task.ToTasskDto());
        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateTasskDto TasskDto){
            var TasskModel = TasskDto.ToTasskFromCreateDto();
            await _context.Tasks.AddAsync(TasskModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = TasskModel.Id}, TasskModel.ToTasskDto());
        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpdateTasskDto TasskDto){

            var TasskModel = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

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

            await _context.SaveChangesAsync();

            return Ok(TasskModel.ToTasskDto());

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id){
            var TasskModel = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
              
              if(TasskModel == null){
                    return NotFound();
              }

                    _context.Tasks.Remove(TasskModel);

              await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }


}