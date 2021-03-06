﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using QuantumLeap.Models;

namespace QuantumLeap.Data
{
    public class LeapRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public Leaper GetRandomLeaper()
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var randomLeaper = database.QueryFirstOrDefault<Leaper>(
                                                                      @"select top 1 id, name, budgetamount
                                                                      from Leapers l
                                                                      order by newid()");

                return randomLeaper;
            }
        } 

        public Leapee GetRandomLeapee()
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var randomLeapee = database.QueryFirstOrDefault<Leapee>(
                                                                      @"select top 1 id, name, age, gender
                                                                      from Leapees le
                                                                      order by newid()");
                return randomLeapee;
            }
        }

        public Event GetRandomEvent()
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var randomEvent = database.QueryFirstOrDefault<Event>(
                                                                     @"select top 1 dateadd(day, rand() * datediff(day, @datestart, @dateend), @datestart) as RandomEvent, lp.Name as LeaperName, lps.Name as LeapeeName
                                                                     from Events e
                                                                     join Leapers lp
                                                                     on lp.Name = e.Name
                                                                     join Leapees lps
                                                                     on e.Id = lps.Id");

                return randomEvent;
            }
        }

        public Event RetrieveEventAndLeaperInfo()
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var retrieveDataBasedOnEvent = database.QueryFirstOrDefault<Event>(
                                                                                    @"select top 1 e.NameOfEvent, e.EventLocation, lpr.Name as LeaperName, lps.Name as LeapeesName, e.EventDate, lpr.BudgetAmount
                                                                                    from Leapers lpr
                                                                                    join Events e
                                                                                    on e.Name = lpr.Name
                                                                                    join Leapees lps
                                                                                    on e.Id = lps.Id");
                return retrieveDataBasedOnEvent;
            }
        }

        public Leap RetrieveUpdatedBudgetFromLeap(int leaperId, int leapeeId, int eventId, decimal cost)
        {
            using (var database = new SqlConnection(ConnectionString))
            {
                var retrieveUpdatedBudget = @"Insert into Leap (LeaperId, LeapeeId, EventId, Cost)
                                             Output inserted.*
                                             Values (@leaperId, @leapeeId, @eventId, @cost";
                                             var newOperator = new { leaperId, leapeeId, eventId, cost };
                                             var newLeap = database.QueryFirstOrDefault<Leap>(retrieveUpdatedBudget, newOperator);

                if (newLeap != null)
                {
                    var updateLeapers = @"update Leapers 
                                        set BudgetAmount = BudgetAmount - @newCost
                                        where id = @updatedLeaper";
                                        
                    var updateOperator = new { leaperId, cost };
                    var updateLeaper = database.Execute(updateLeapers, updateOperator);
                }
                return newLeap;
            }
        }
    }
}


                                                                     



//var insertLeap = database.QueryFirstOrDefault<Leap>(
//                                                      @"Insert into Leap(leaperId, leapeeId, eventId, cost)
//                                                                      output inserted.*
//                                                                      values(@leaperId, @eventId, @leapeeId, @cost)");