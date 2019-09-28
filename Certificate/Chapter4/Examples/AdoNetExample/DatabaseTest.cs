using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Certificate.Chapter4.Examples.AdoNetExample
{
    public class DatabaseTest
    {
        public void  Select()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Person", connection);
                 connection.Open();
                SqlDataReader dataReader =  command.ExecuteReader();
                while ( dataReader.Read())
                {
                    string formatStringWithMiddleName = "Person({0}) is named {1} {2} {3}";
                    string formatStringWithoutMiddleName = "Person({0}) is named {1} {3}";
                    if ((dataReader["middlename"] == null))
                    {
                        Console.WriteLine(formatStringWithoutMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["lastname"]);
                   }
                    else
                    {
                        Console.WriteLine(formatStringWithMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["middlename"],
                        dataReader["lastname"]);
                   }
               }
                dataReader.Close();
           }
       }

        public void SelectMultipleResultSets()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Person; SELECT TOP 1 * FROM Person ORDER BY LastName", connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                ReadQueryResults(dataReader);
                dataReader.NextResult(); // Move to the next result set
                ReadQueryResults(dataReader);
                dataReader.Close();
            }

       }

        private static void ReadQueryResults(SqlDataReader dataReader)
        {
            while (dataReader.Read())
            {
                string formatStringWithMiddleName = "Person({0}) is named {1} {2} {3}";
                string formatStringWithoutMiddleName = "Person({0}) is named {1} {3}";
                if ((dataReader["middlename"] == null))
                {
                    Console.WriteLine(formatStringWithoutMiddleName,
                    dataReader["id"],
                    dataReader["firstname"],
                    dataReader["lastname"]);
                }
                else
                {
                    Console.WriteLine(formatStringWithMiddleName,
                    dataReader["id"],
                    dataReader["firstname"],
                    dataReader["middlename"],
                    dataReader["lastname"]);
                }
            }
        }

        public void Update()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Person SET FirstName ='John'", connection);
                 connection.Open();
                int numberOfUpdatedRows =  command.ExecuteNonQuery();
                Console.WriteLine("Updated {0} rows", numberOfUpdatedRows);
            }
        }

        public void Insert()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Person([FirstName], [LastName], [MiddleName]) VALUES(@firstName, @lastName, @middleName)",connection);
                connection.Open();
                command.Parameters.AddWithValue("@firstName", "John");
                command.Parameters.AddWithValue("@lastName", "Doe");
                command.Parameters.AddWithValue("@middleName", "Little");

                int insertedRow = command.ExecuteNonQuery();
                Console.WriteLine($"Inserted row: {insertedRow}");
            }
        }

        public void InsertTransaction()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

            using (TransactionScope transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(
                        @"INSERT INTO Person([FirstName], [LastName], [MiddleName])
                            VALUES('John', 'Doe', null)",connection);

                    SqlCommand command2 = new SqlCommand(
                        @"INSERT INTO Person([FirstName], [LastName], [MiddleName])
                            VALUES('Jane', 'Doe', null)",connection);

                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                }
                transactionScope.Complete();
            }
        }
    }
    
}
