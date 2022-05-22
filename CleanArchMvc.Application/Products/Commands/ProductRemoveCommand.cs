using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product> //herança de IRequest pois para remover um produto eu não preciso nada além do Id do produto
    {
        public int Id { get; set; }
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
