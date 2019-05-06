using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace QuantumLeap.Data
{
    public class LeapRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public Leap AddLeap(decimal cost, int leaperId, int leapeeId, int eventId)
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var randomLeaper = database.QueryFirstOrDefault<Leap>(
                                                                      @"select top 1 id, name, budgetamount
                                                                      from Leapers l
                                                                      order by newid()");

                var randomLeapee = database.QueryFirstOrDefault<Leap>(
                                                                      @"select top 1 id, name, age, gender
                                                                      from Leapees le
                                                                      order by newid()");

                var randomEvent = database.QueryFirstOrDefault<Leap>(
                                                                      @"select top 1 dateadd(day, rand() * datediff(day, @datestart, @dateend), @datestart)
                                                                      from Events e");
            }
            throw new System.Exception("Leap didn't work.");
        }   
    }
}
