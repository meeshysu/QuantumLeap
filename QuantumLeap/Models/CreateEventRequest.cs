using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Models
{
    public class CreateEventRequest
    {
        public string Name { get; set; }
        public int EventTime { get; set; }
        public string EventLocation { get; set; }
        public string NameOfEvent { get; set; }
    }
}
