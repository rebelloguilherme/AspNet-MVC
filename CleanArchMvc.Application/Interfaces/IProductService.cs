using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetById(int? id);
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int? id);

    }
}
