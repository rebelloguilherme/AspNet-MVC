using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                _productContext.Add(product);
                await _productContext.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }


        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                return await _productContext.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        public async Task<Product> GetByIdAsync(int? id)
        {
                //aqui retorno o produto e a categoria o qual este produto esta relacionado
                //utilizando carregamento adiantado ou eager loading
                return await _productContext.Products.Include(c => c.Category)
                             .SingleOrDefaultAsync(p => p.Id == id);            
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            try
            {
                 _productContext.Remove(product);
                 await _productContext.SaveChangesAsync();
                 return product;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                _productContext.Update(product);
                await _productContext.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
