using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Tassk;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ITasskRepository
    {
        Task<List<Tassk>> GetAllAsync(QueryObject query);
        Task<Tassk?> GetByIdAsync(int id);
        Task<Tassk> CreateAsync(Tassk tasskModel);
        Task<Tassk?> UpdateAsync(int id , UpdateTasskDto tasskDto);
        Task<Tassk?> DeleteAsync(int id);
        
    }
}