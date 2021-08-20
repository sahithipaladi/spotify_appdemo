/*
 * project = Testing the sql commands by using database 
 * Author = sahithi paladi
 * Created Date = 19/08/2021
 */ 

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;


namespace DatabaseAutomationTesting
{
    [TestClass]
    public class TestingSqlCommands
    {
        public static string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = spotify_appdemo";
        //creating sql connection
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        [TestMethod]
        public void InsertRecord_InDatabase()
        {
            using (this.sqlConnection)
            {
                this.sqlConnection.Open();


                SqlCommand insertCommand1 = new SqlCommand("INSERT INTO  SpotifyTable ( FirstName, LastName,Age,Country,PhoneNumber,Email) VALUES (@0,@1,@2,@3,@4,@5)", this.sqlConnection);

                //performing insert command
                insertCommand1.Parameters.Add(new SqlParameter("0", "likitha"));
                insertCommand1.Parameters.Add(new SqlParameter("1", "k"));
                insertCommand1.Parameters.Add(new SqlParameter("2", 22));
                insertCommand1.Parameters.Add(new SqlParameter("3", "IN"));
                insertCommand1.Parameters.Add(new SqlParameter("4", 889786574));
                insertCommand1.Parameters.Add(new SqlParameter("5", "likitha@gmail.com"));
                int rows = insertCommand1.ExecuteNonQuery();
                Assert.AreEqual(1, rows);
            }
        }
        [TestMethod]
        public void RetriveingDataFromDataBase()
        {
            using (this.sqlConnection)
            {
                this.sqlConnection.Open();
                //retriveing records from database using selectcommand
                string query = @"select * from SpotifyTable";
                SqlCommand selectCommand = new SqlCommand(query, this.sqlConnection);

                SqlDataReader reader;
                reader = selectCommand.ExecuteReader();
                Assert.AreEqual(7, reader.VisibleFieldCount);
            }
        }
    }
}
       
           
    
