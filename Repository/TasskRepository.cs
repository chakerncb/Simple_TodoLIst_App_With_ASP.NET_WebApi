using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Tassk;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TasskRepository : ITasskRepository
    {
        private readonly ApplicationDBContext _context;
        public TasskRepository(ApplicationDBContext context)
        {
           _context = context;
        }
    
        public async Task<Tassk> CreateAsync(Tassk tasskModel)
        {
            await _context.Tasks.AddAsync(tasskModel);
            await _context.SaveChangesAsync();

            return tasskModel;
        }

        public async Task<Tassk?> DeleteAsync(int id)
        {
            var TasskModel = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
              
              if(TasskModel == null){
                    return null;
              }

                _context.Tasks.Remove(TasskModel);

              await _context.SaveChangesAsync();

            return TasskModel;
        }

        public async Task<List<Tassk>> GetAllAsync(QueryObject query)
        {
            var Tassks = _context.Tasks.AsQueryable();

            if(!string.IsNullOrEmpty(query.TaskName)){
                Tassks = Tassks.Where(x => x.Title.Contains(query.TaskName));
            }

            return await Tassks.ToListAsync();

        }

        public async Task<Tassk?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Tassk?> UpdateAsync(int id, UpdateTasskDto tasskDto)
        {
            var existingTassk = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingTassk == null){
                return null;
            }

            existingTassk.TaskListId = tasskDto.TaskListId;
            existingTassk.Title = tasskDto.Title;
            existingTassk.Description = tasskDto.Description;
            existingTassk.Deadline = tasskDto.Deadline;
            existingTassk.IsCompleted = tasskDto.IsCompleted;
            existingTassk.IsDeleted = tasskDto.IsDeleted;
            existingTassk.updatedAt = tasskDto.updatedAt;

            await _context.SaveChangesAsync();

            return existingTassk;
        }
    }
}