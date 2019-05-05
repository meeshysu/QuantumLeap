using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;

namespace QuantumLeap.Data
{
    public class LeaperRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public Leaper AddLeaper(string name, decimal budget)
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var newLeaper = database.QueryFirstOrDefault<Leaper>(
                    @"Insert into Leapers(Name, BudgetAmount)
                    Output inserted.*
                    Values(@name, @budget)",
                    new {name, budget});

                if (newLeaper != null)
                {
                    return newLeaper;
                }
            }
            throw new System.Exception("No leaper found.");
        }

        public IEnumerable<Leaper> GetAllLeapers()
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var sequelLeapers = "Select * from Leapers";
                var leapers = database.Query<Leaper>(sequelLeapers);
                return leapers;
            }
            throw new Exception("No leapers found.");
        }
    }
}
