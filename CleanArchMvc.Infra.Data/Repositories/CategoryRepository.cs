using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Category> Create(Category category)
        {
            try
            {
                _categoryContext.Add(category);
                await _categoryContext.SaveChangesAsync();
                return category;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Category> GetById(int? id)
        {
            try
            {
                return await _categoryContext.Categories.FindAsync(id);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                return await _categoryContext.Categories.ToListAsync();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public async Task<Category> Remove(Category category)
        {
            try
            {
                _categoryContext.Remove(category);
                await _categoryContext.SaveChangesAsync();
                return category;
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public async Task<Category> Update(Category category)
        {
            try
            {
                _categoryContext.Update(category);
                await _categoryContext.SaveChangesAsync();
                return category;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
