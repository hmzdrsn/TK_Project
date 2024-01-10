using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Repositories;
using TK_Project.Persistance.Context;

namespace TK_Project.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<T> AddAsync(T entity)
        {
            Table.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteByIDAsync(int id)
        {
            var data = Table.Find(id);
            Table.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
