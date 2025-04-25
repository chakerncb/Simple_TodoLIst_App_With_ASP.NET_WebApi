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
                 Title = TasskModel.Title,
                 Description = TasskModel.Description,
                 Duration = TasskModel.Duration,
                 createdAt = TasskModel.createdAt,
                 updatedAt = TasskModel.updatedAt
            };

        }

        public static Tassk ToTasskFromCreateDto(this CreateTasskDto TasskDto){
            return new Tassk{
                 Title = TasskDto.Title,
                 Description = TasskDto.Description,
                 Duration = TasskDto.Duration,
                 createdAt = TasskDto.createdAt,
                 updatedAt = TasskDto.updatedAt,
                //  UserId = TasskDto.UserId
            };
        }

        public static Tassk ToTasskFromUpdateDto(this UpdateTasskDto TasskDto){
             return new Tassk{
                 Title = TasskDto.Title,
                 Description = TasskDto.Description,
                 Duration = TasskDto.Duration,
                //  createdAt = TasskDto.createdAt,
                 updatedAt = TasskDto.updatedAt,
                 UserId = TasskDto.UserId
            };
        }

    }
}