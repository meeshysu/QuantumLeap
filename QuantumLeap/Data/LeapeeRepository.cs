using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace QuantumLeap.Data
{
    public class LeapeeRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";


        public Leapee AddLeapee(string name, int age, string gender)
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var newLeapee = database.QueryFirstOrDefault<Leapee>(
                    @"Insert into Leapees(Name, Age, Gender)
                    Output inserted.*
                    Values(@name, @age, @gender)",
                    new { name, age, gender });

                if (newLeapee != null)
                {
                    return newLeapee;
                }
            }
            throw new System.Exception("No leapee found.");
        }

        public IEnumerable<Leapee> GetAllLeapees()
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var sequelLeapees = "Select * from Leapees";
                var leapees = database.Query<Leapee>(sequelLeapees);
                return leapees;
            }
            throw new Exception("No leapees found.");
        }
    }
}
