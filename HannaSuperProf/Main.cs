using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MySqlConnector;

namespace HannaSuperProf;

public class Main {
    public static void Start() {
        var users = ReadInCsvFile();
        var differences = compareDifferences(users, ConnectToDatabase());
        foreach (var user in users) {
            Console.WriteLine(user);
        }
    }

    private static MySqlConnection ConnectToDatabase() {
        var connectionString = "server=localhost;user id=username;password=password;database=mydatabase;";
        var connection = new MySqlConnection(connectionString);
        //check if connection is open
        return connection;
    }


    private static List<User> compareDifferences(List<User> users, MySqlConnection connection) {
        var usersWithDifferences = new List<User>();
        foreach (var user in users) {
            var query = $"SELECT * FROM mydatabase WHERE persID = {user.PersID}";
            var command = new MySqlCommand(query, connection);
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var date = reader.GetDateTime(2);
                var firstTime = reader.GetString(3);
                var secondTime = reader.GetString(4);
                var hour = reader.GetDouble(5);
                var kstCode = reader.GetString(6);
                var kst = reader.GetInt32(7);
                var sqlUser = new User(id, name, date, firstTime, secondTime, hour, kstCode, kst);
                if (user.Date != date) {
                    Console.WriteLine("Date is different");
                }

                if (user.FirstTime != firstTime) {
                    Console.WriteLine("FirstTime is different");
                }

                if (user.SecondTime != secondTime) {
                    Console.WriteLine("SecondTime is different");
                }

                if (user.Hour != hour) {
                    Console.WriteLine("Hour is different");
                }

                if (user.KstCode != kstCode) {
                    Console.WriteLine("KstCode is different");
                }

                if (user.Kst != kst) {
                    Console.WriteLine("Kst is different");
                }

                if (!user.compareUser(sqlUser))
                    usersWithDifferences.Add(sqlUser);
            }
        }

        return usersWithDifferences;
    }

    private static List<User> ReadInCsvFile() {
        //read in the config file under "data/file.csv"
        const string path = @"C:\Users\Carina\Downloads\Data.csv";
        var lines = File.ReadAllLines(path);
        return (from line in lines select line.Split(';') into parts let id = Convert.ToInt32(parts[0]) let name = parts[1] let dateString = parts[2].Split(".") let date = new DateTime(Convert.ToInt32(dateString[2]), Convert.ToInt32(dateString[1]), Convert.ToInt32(dateString[0])) let firstTime = parts[3] let secondTime = parts[4] let hour = Convert.ToDouble(parts[5].Replace(",", ".")) let kstCode = parts[6] let kst = Convert.ToInt32(parts[7]) select new User(id, name, date, firstTime, secondTime, hour, kstCode, kst)).ToList();
    }
}