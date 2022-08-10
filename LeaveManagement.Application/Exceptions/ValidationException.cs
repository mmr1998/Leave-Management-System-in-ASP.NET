using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> errors { get; set; } = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }
        }
    }
}
