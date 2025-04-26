using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TaskList;
using api.Models;

namespace api.Mappers
{
    public static class TaskListMappers
    {

        public static TaskListDto ToTaskListDto(this TaskList TaskListModel){
            return new TaskListDto{
                Id = TaskListModel.Id,
                Name = TaskListModel.Name,
                UserId = TaskListModel.UserId,
                CreatedAt = TaskListModel.CreatedAt,
                UpdatedAt = TaskListModel.UpdatedAt
            };

        }

        public static TaskList ToTaskListFromCreateDto(this CreateTaskListDto TaskListDto){
            return new TaskList{
                Name = TaskListDto.Name,
                UserId = TaskListDto.UserId,
                CreatedAt = TaskListDto.CreatedAt,
                UpdatedAt = TaskListDto.UpdatedAt
            };
        
        }

        public static TaskList ToTaskListFromUpdateDto(this UpdateTaskListDto TaskListDto){
            return new TaskList{
                Name = TaskListDto.Name,
                UserId = TaskListDto.UserId,
                CreatedAt = TaskListDto.CreatedAt,
                UpdatedAt = TaskListDto.UpdatedAt
            };
        
        }
    }
}