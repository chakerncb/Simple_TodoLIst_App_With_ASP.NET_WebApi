using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Tassk;
using api.Models;

namespace api.Mappers
{
    public static class TasskMappers
    {
        
        public static TasskDto ToTasskDto(this Tassk TasskModel){
            return new TasskDto{
                 Id = TasskModel.Id,
                 TaskListId = TasskModel.TaskListId,
                 Title = TasskModel.Title,
                 Description = TasskModel.Description,
                 Deadline = TasskModel.Deadline,
                 IsCompleted = TasskModel.IsCompleted,
                 IsDeleted = TasskModel.IsDeleted,
                 createdAt = TasskModel.createdAt,
                 updatedAt = TasskModel.updatedAt
            };

        }

        public static Tassk ToTasskFromCreateDto(this CreateTasskDto TasskDto){
            return new Tassk{
                 TaskListId = TasskDto.TaskListId,
                 Title = TasskDto.Title,
                 Description = TasskDto.Description,
                 Deadline = TasskDto.Deadline,
                 IsCompleted = TasskDto.IsCompleted,
                 IsDeleted = TasskDto.IsDeleted,
                 createdAt = TasskDto.createdAt,
                 updatedAt = TasskDto.updatedAt,
            };
        }

        public static Tassk ToTasskFromUpdateDto(this UpdateTasskDto TasskDto){
             return new Tassk{
                 TaskListId = TasskDto.TaskListId,
                 Title = TasskDto.Title,
                 Description = TasskDto.Description,
                 Deadline = TasskDto.Deadline,
                 IsCompleted = TasskDto.IsCompleted,
                 IsDeleted = TasskDto.IsDeleted,
                 createdAt = TasskDto.createdAt,
                 updatedAt = TasskDto.updatedAt,
            };
        }

    }
}