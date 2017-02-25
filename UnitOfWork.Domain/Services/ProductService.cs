using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Domain.Entities;
using UnitOfWork.Domain.Helpers;
using UnitOfWork.Domain.Repositories;

namespace UnitOfWork.Domain.Services
{
    public interface IProductService
    {
        IList<Product> GetAll();
        Product GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);


        /// <summary>
        /// Get full list of products
        /// </summary>
        /// <returns></returns>
        IList<Product> GetAllProducts();


        /// <summary>
        /// Get Product By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(int id);

        Product CreateProduct(string name);
    }

    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
       
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAll()
        {
           return _productRepository
               .GetAll()
               .ToList();
            
        }


        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.SqlQuery<Product>("exec dbo.GetProductById " + id);
        }

        public Product CreateProduct(string name)
        {
            return _productRepository.SqlQuery<Product>("exec dbo.CreateProduct " + name);
        }

        public IList<Product> GetAllProducts()
        {
            return _productRepository.SqlQueryList<Product>("exec dbo.GetAllProducts");

        }
    }
}
