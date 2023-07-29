using FluentValidation;
using Okusana.Constants;
using Okusana.DTOs.Concrete.User;
using Okusana.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okusana.Validation.Validations.UserValidation
{
    public class DeleteUserDTOValidation : AbstractValidator<DeleteUserDTO>
    {
        public DeleteUserDTOValidation()
        {
            RuleFor(e => e.Id).IdValidation();
        }
    }
}
