using Northwind.Bussiness.Abstract;
using Northwind.Bussiness.ValidationRules.FluentValidation;
using Northwind.Bussiness.ValidationTool;
using Northwind.Entities.Concerete;
using Nothwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Bussiness.Concerete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void Add(Product product)
        {
            ValidationTools.Validate(new ProductValidator(),product);
            _productDAL.Add(product);
        }

        public void Delete(Product product)
        {
            _productDAL.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDAL.GetAll();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return _productDAL.GetAll(p=>p.CategoryID == categoryId).ToList();
        }

        public List<Product> GetProductByProductName(string key)
        {
            return _productDAL.GetAll(p=>p.ProductName.ToLower().Contains(key.ToLower())).ToList();
        }

        public void Update(Product product)
        {
            _productDAL.Update(product);
        }
    }
}
