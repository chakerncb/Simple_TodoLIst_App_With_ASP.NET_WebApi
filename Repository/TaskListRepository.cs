using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TaskList;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TaskListRepository : ITasKListRepository
    {
        private readonly ApplicationDBContext _context;
        public TaskListRepository(ApplicationDBContext context){
           _context = context; 
        }

        public async Task<TaskList> CreateAsync(TaskList TaskListModel)
        {
            await _context.TaskList.AddAsync(TaskListModel);
            await _context.SaveChangesAsync();
            return TaskListModel;
        }

        public async Task<TaskList?> DeleteAsync(int id)
        {
            var TaskListModel = await _context.TaskList.FirstOrDefaultAsync(x => x.Id == id);

            if(TaskListModel == null){
               return null;
            }

                  _context.TaskList.Remove(TaskListModel);
            await _context.SaveChangesAsync();
            return TaskListModel;
        }

        public async Task<List<TaskList>> GetAllAsync()
        {
            return await _context.TaskList.ToListAsync();
        }

        public async Task<TaskList?> GetByIdAsync(int id)
        {
            return await _context.TaskList.FindAsync(id);
        }

        public async Task<bool> TaskListExists(int id)
        {
            return await _context.TaskList.AnyAsync(x => x.Id == id);
        }

        public async Task<TaskList?> UpdateAsync(int id, UpdateTaskListDto TaskListDto)
        {
            var existingTaskList = await _context.TaskList.FirstOrDefaultAsync(x => x.Id == id); 

            if(existingTaskList == null){
                return null;
            }

            existingTaskList.Name = TaskListDto.Name;
            existingTaskList.UserId = TaskListDto.UserId;
            existingTaskList.CreatedAt =  TaskListDto.CreatedAt;
            existingTaskList.UpdatedAt =  TaskListDto.UpdatedAt;

            await _context.SaveChangesAsync();

            return existingTaskList;
        }
    }
}