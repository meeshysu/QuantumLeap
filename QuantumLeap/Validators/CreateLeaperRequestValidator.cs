using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuantumLeap.Models;

namespace QuantumLeap
{
    public class CreateLeaperRequestValidator
    {
        public bool Validate(CreateLeaperRequest requestToValidate)
        {
            return (string.IsNullOrEmpty(requestToValidate.Name));
        }
    }
}
