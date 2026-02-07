using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace Lab6
{
    public class Student
{
    public int StudentId { get; set; }
    public string Imie { get; set; } = "";
    public string Nazwisko { get; set; } = "";
    public List<Ocena> Oceny { get; set; } = new();
}

public class Ocena
{
    public int OcenaId { get; set; }
    public double Wartosc { get; set; }
    public string Przedmiot { get; set; } = "";
    public int StudentId { get; set; }
}

public class Program
{
    public static void Main()
    {
        string connectionString = "Data Source=10.200.2.28;" +
                                  "Initial Catalog=studenci_71445;" +
                                  "Integrated Security=True;" +
                                  "Encrypt=True;" +
                                  "TrustServerCertificate=True";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Połączono z bazą.");

                WyswietlStudentow(connection);
            }
        }
        catch (Exception exc)
        {
            Console.WriteLine("Wystąpił błąd: " + exc.Message);
        }
    }

    public static void WyswietlStudentow(SqlConnection connection)
    {
        string query = "SELECT student_id, imie, nazwisko FROM student";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["student_id"]}: {reader["imie"]} {reader["nazwisko"]}");
                }
            }
        }
    }
}
}
