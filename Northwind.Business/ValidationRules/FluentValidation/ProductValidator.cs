using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş Olamaz :)");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Birim Fiyat Sıfırdan Büyük Olmalı :)");
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0).WithMessage("Stok Adedi 0'dan küçük olamaz :)");
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2).WithMessage(" Condiments Kategorisindeki Ürünlerin Birim Fiyatı 10'dan Büyük Olmalı:)");
        }  
    }
}
