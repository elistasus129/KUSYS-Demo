using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannot be blank");       
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannot be blank");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Birthday cannot be blank");
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("First Name must consist of at least 2 characters");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("Last Name must consist of at least 2 characters");

    }
    }
}
