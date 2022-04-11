using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace ATM
{
    internal class BankController
    {
        public static string dbString = "Data Source=database.sqlite3";
        public static SQLiteConnection myConnection;

        public static void CreateTable()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");

                myConnection.Open();
                string table = "CREATE TABLE Accounts (id INTEGER PRIMARY KEY AUTOINCREMENT, cardNumber TEXT, pinNumber TEXT, bankBalance TEXT);";
                SQLiteCommand command = new SQLiteCommand(table, myConnection);
                command.ExecuteNonQuery();
                myConnection.Close();

                using (var con = new SQLiteConnection(dbString))
                {
                    using (var cmd = con.CreateCommand())
                    {
                        con.Open();
                        cmd.CommandText = "INSERT INTO Accounts (cardNumber, pinNumber, bankBalance) VALUES (@cardNumber, @pinNumber, @bankBalance)";
                        cmd.Parameters.AddWithValue("@cardNumber", "5450878657260454");
                        cmd.Parameters.AddWithValue("@pinNumber", "1234");
                        cmd.Parameters.AddWithValue("@bankBalance", "2000");
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
        public static bool CheckCardNumber(string cardNum)

        {
            using (var con = new SQLiteConnection(dbString))
            {
                using (var cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM Accounts WHERE cardNumber=(@cardNumber)";
                    cmd.Parameters.AddWithValue("@cardNumber", cardNum);
                    cmd.ExecuteNonQuery();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}

