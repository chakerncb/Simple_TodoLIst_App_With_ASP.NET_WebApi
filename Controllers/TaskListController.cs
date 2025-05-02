using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TaskList;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/TaskList")]
    [ApiController]

    public class TaskListController : ControllerBase
    {
        private readonly ITasKListRepository _TaskListRepo;
        public TaskListController(ITasKListRepository TaskListRepo){
           _TaskListRepo = TaskListRepo;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAll(){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var TaskLists = await _TaskListRepo.GetAllAsync();

            var TaskListDtos = TaskLists
            .Select(x => x.ToTaskListDto());

            return Ok(TaskListDtos); 
        }


        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var TaskList = await _TaskListRepo.GetByIdAsync(id);

            if(TaskList == null){
               return NotFound();
            }

            return Ok(TaskList.ToTaskListDto());

        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateTaskListDto TaskListDto){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var TaskListModel = TaskListDto.ToTaskListFromCreateDto();

            await _TaskListRepo.CreateAsync(TaskListModel);

            return CreatedAtAction(nameof(GetById), new {id = TaskListModel.Id}, TaskListModel.ToTaskListDto());

        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTaskListDto TaskListDto){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var TaskListModel = await _TaskListRepo.UpdateAsync(id, TaskListDto); 

            if(TaskListModel == null){
                return NotFound();
            }

            return Ok(TaskListModel.ToTaskListDto());

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id){

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            
            var TaskListModel = await _TaskListRepo.DeleteAsync(id);

            if(TaskListModel == null){
                return NotFound();
            }

            return NoContent();
        }

    }
}