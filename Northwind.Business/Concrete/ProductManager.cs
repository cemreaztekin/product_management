using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAcccess.Abstract;
using Northwind.DataAcccess.Concrete;
using Northwind.DataAcccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
              return _productDal.GetAll();
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }

        void IProductService.Delete(Product product)
        {
            _productDal.Delete(product);
        }

        List<Product> IProductService.GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        List<Product> IProductService.GetProductsByProductName(string ProductName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(ProductName.ToLower()));
        }
    }
}
