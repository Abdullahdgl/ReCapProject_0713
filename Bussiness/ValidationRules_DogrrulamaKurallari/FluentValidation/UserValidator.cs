using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.ValidationRules_DogrrulamaKurallari.FluentValidation
{
	public class UserValidator :AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(u => u.FirstName).NotEmpty();
			RuleFor(u => u.FirstName).MinimumLength(3);
			RuleFor(u => u.LastName).NotEmpty();
			RuleFor(u => u.Email).EmailAddress();
		}
	}
}
