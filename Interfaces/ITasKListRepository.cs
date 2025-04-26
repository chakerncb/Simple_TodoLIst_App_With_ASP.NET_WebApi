using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TaskList;
using api.Models;

namespace api.Interfaces
{
    public interface ITasKListRepository
    {
        Task<List<TaskList>> GetAllAsync();
        Task<TaskList?> GetByIdAsync(int id);
        Task<TaskList> CreateAsync(TaskList TaskListModel);
        Task<TaskList?> UpdateAsync(int id , UpdateTaskListDto TaskListDto);
        Task<TaskList?> DeleteAsync(int id);

    }
}