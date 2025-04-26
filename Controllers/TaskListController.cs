using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TaskList;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/TaskList")]
    [ApiController]

    public class TaskListController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TaskListController(ApplicationDBContext context){
           _context = context; 
        }

        [HttpGet]

        public async Task<IActionResult> GetAll(){
            var TaskLists = await _context.TaskList
            .ToListAsync();

            var TaskListDtos = TaskLists
            .Select(x => x.ToTaskListDto());

            return Ok(TaskListDtos); 
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id){
            var TaskList = await _context.TaskList.FindAsync(id);

            if(TaskList == null){
               return NotFound();
            }

            return Ok(TaskList.ToTaskListDto());

        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateTaskListDto TaskListDto){
            var TaskListModel = TaskListDto.ToTaskListFromCreateDto();

           await _context.TaskList.AddAsync(TaskListModel);
           await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = TaskListModel.Id}, TaskListModel.ToTaskListDto());

        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskListDto TaskListDto){
            var TaskListModel = await _context.TaskList.FirstOrDefaultAsync(x => x.Id == id); 

            if(TaskListModel == null){
                return NotFound();
            }

            TaskListModel.Name = TaskListDto.Name;
            TaskListModel.UserId = TaskListDto.UserId;
            TaskListModel.CreatedAt =  TaskListDto.CreatedAt;
            TaskListModel.UpdatedAt =  TaskListDto.UpdatedAt;

            await _context.SaveChangesAsync();

            return Ok(TaskListModel.ToTaskListDto());

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id){
            var TaskListModel = await _context.TaskList.FirstOrDefaultAsync(x => x.Id == id);

            if(TaskListModel == null){
               return NotFound();
            }

                  _context.TaskList.Remove(TaskListModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}