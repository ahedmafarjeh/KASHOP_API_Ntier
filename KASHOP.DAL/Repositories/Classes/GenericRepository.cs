﻿using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repositories.Classes
{
    public class GenericRepository<T> : iGenericRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext context;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Add(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return context.Set<T>().ToList();
            }
            return context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public int Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public int Update(T entity)
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges();
        }
    }
}
