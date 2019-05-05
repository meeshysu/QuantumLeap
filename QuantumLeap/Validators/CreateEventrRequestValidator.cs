using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuantumLeap.Models;

namespace QuantumLeap.Validators
{
    public class CreateEventRequestValidator
    {
        public bool Validate(CreateEventRequest requestToValidate)
        {
            return (string.IsNullOrEmpty(requestToValidate.Name)
                   || string.IsNullOrEmpty(requestToValidate.EventLocation));
        }
    }
}
