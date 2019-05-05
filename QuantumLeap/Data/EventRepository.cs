using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using QuantumLeap.Models;

namespace QuantumLeap.Data
{
    public class EventRepository
    {

        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public Event AddEvent(string name, int eventDate, string eventLocation, string nameOfEvent)
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var newEvent = database.QueryFirstOrDefault<Event>(
                      @"Insert into Events(Name, EventDate, EventLocation, NameOfEvent)
                      Output inserted.*
                      Values(@Name, @EventDate, @EventLocation, @NameOfEvent)",
                      new { name, eventDate, eventLocation, nameOfEvent });

                if (newEvent != null)
                {
                    return newEvent;
                }
            }
            throw new System.Exception("No event found.");
        }

        public IEnumerable<Event> GetAllEvents()
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var sequelEvents = "Select * from Events";
                var events = database.Query<Event>(sequelEvents);
                return events;
            }
            throw new Exception("No event found.");
        }
    }
}
