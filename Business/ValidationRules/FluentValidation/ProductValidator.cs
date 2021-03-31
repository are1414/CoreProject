using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).MinimumLength(5);
            RuleFor(p => p.ProductName).NotEmpty();

            //Minimn 0 girilebilir
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            
            //Categori id 1 olanın min degeri 10 olabilir
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            // fluente olmayan validasyon elle yapabilisz StartWithA mesela 
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır.");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
