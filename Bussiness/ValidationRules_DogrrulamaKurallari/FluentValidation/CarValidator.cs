using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.ValidationRules_DogrrulamaKurallari.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.CarName).NotEmpty();
			RuleFor(c => c.CarName).MinimumLength(2);
			RuleFor(C => C.DailyPrice).NotEmpty();
			RuleFor(c => c.DailyPrice).GreaterThan(0);
			RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.CarId == 1);
			RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Ürünler A Harfi İle Başlamalıdır.");

		}

		private bool StartWithA(string arg)
		{
			return arg.StartsWith("A");
		}
	}
}
