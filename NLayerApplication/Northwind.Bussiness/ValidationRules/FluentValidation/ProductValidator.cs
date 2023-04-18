using FluentValidation;
using Northwind.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiness.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(x=>x.ProductID).NotEmpty();
            RuleFor(x=>x.ProductName).NotEmpty();
            RuleFor(x=>x.CategoryID).NotEmpty();
            RuleFor(x=>x.QuantityPerUnit).NotEmpty();
            RuleFor(x=> x.UnitPrice).NotEmpty();
            RuleFor(x => x.ProductName).Must(StartWithA).WithMessage("Ürün ismi a ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
