using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Tassk;
using api.Interfaces;
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
        private readonly ITasskRepository _tasskRepository;
        public TasksController(ApplicationDBContext context, ITasskRepository tasskRepository)
        {
           _tasskRepository = tasskRepository;
           _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var tasks = await _tasskRepository.GetAllAsync();

            var taskDtos = tasks.Select(s => s.ToTasskDto());
            
            return Ok(taskDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
             var task = await _tasskRepository.GetByIdAsync(id);

               if(task == null){
                   return NotFound();
               }

             return Ok(task.ToTasskDto());
        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateTasskDto TasskDto){
            var TasskModel = TasskDto.ToTasskFromCreateDto();

            await _tasskRepository.CreateAsync(TasskModel);

            return CreatedAtAction(nameof(GetById), new {id = TasskModel.Id}, TasskModel.ToTasskDto());
        }


        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> update([FromRoute] int id, [FromBody] UpdateTasskDto TasskDto){

            var TasskModel = await _tasskRepository.UpdateAsync(id, TasskDto);

            if(TasskModel == null){
                return NotFound();
            }

            return Ok(TasskModel.ToTasskDto());

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id){
            
            var TasskModel = await _tasskRepository.DeleteAsync(id);

            if(TasskModel == null){
                return NotFound();
            }

            return NoContent();
        }
        
    }


}