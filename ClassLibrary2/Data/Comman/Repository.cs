﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentingHouseSystem.Infrastructure.Data.Comman
{
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
