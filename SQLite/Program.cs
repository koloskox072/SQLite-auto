using System.Data.SqlClient;
using System.Data.SQLite;
using System.Runtime.CompilerServices;

namespace SQLite
{
    class Auto
    {
        public string marka, model, kolor;
        public int nr, przebieg, cena;
        public Auto(int nr, string marka, string model, string kolor, int przebieg, int cena) 
        {
            this.nr = nr;
            this.marka = marka;
            this.model = model;
            this.kolor = kolor;
            this.przebieg = przebieg;
            this.cena = cena;
        }
        public override string ToString()
        {
            return $"{nr}: {marka} {model} {kolor} {przebieg} {cena}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string connStr = "DataSource=baza.db";
            string q1 = "CREATE TABLE auto(nr INT, marka VARCHAR(20), model VARCHAR(20), kolor VARCHAR(20), przebieg INT, cena INT)";
            string q2 = "INSERT INTO auto VALUES(1, 'Porsche', '911 GT3 RS', 'Czerwony' , 12000 , 1200000)," +
                "(2, 'Fiat', 'Sciento', 'Czarny' , 120000 , 5000)," +
                "(3, 'BMW', '328i', 'Biały' , 100000 , 43000)";
            string q3 = "SELECT * FROM auto";
            SQLiteConnection conn = new SQLiteConnection(connStr);
            /*
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = q1;
            SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Close();
            conn.Close();
            */
            /*
            conn.Open();
            SQLiteCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = q2;
            SQLiteDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                Console.WriteLine(rdr2[0] + " " + rdr2[1] + " " + rdr2[2] + " " + rdr2[3] + " " +
                    rdr2[4] + " " + rdr2[5] + " " + rdr2[6]);
            }
            conn.Close();
            */
            conn.Open();
            SQLiteCommand cmd3 = conn.CreateCommand();
            

            string a="0", marka, model, kolor;
            int id, przebieg, cena;
            while (a != "5")
            {
                Console.WriteLine("Wybierz czynność:");
                Console.WriteLine();
                Console.WriteLine("1 - Wyświetl wszystko");
                Console.WriteLine("2 - Wyświetl auto(ID)");
                Console.WriteLine("3 - Dodaj auto");
                Console.WriteLine("4 - Usuń auto(ID)");
                Console.WriteLine("5 - Zakończ program");
                a = Console.ReadLine();
                Console.WriteLine();
                if (a == "1")
                {

                    cmd3.CommandText = q3;
                    SQLiteDataReader rdr3 = cmd3.ExecuteReader();
                    while (rdr3.Read())
                    {
                        Console.WriteLine(rdr3[0] + " " + rdr3[1] + " " + rdr3[2] + " " + rdr3[3] + " " +
                            rdr3[4] + " " + rdr3[5]);
                    }
                    rdr3.Close();
                    Console.WriteLine();
                }
                else if (a == "2")
                {
                    Console.WriteLine("Podaj ID auta:");
                    id = int.Parse(Console.ReadLine());
                    string q6 = $"SELECT * FROM auto WHERE nr={id}";
                    cmd3.CommandText = q6;
                    SQLiteDataReader rdr3 = cmd3.ExecuteReader();
                    while (rdr3.Read())
                    {
                        Console.WriteLine(rdr3[0] + " " + rdr3[1] + " " + rdr3[2] + " " + rdr3[3] + " " +
                            rdr3[4] + " " + rdr3[5]);
                    }

                    rdr3.Close();
                    Console.WriteLine();

                }
                else if (a == "3")
                {
                    Console.WriteLine("Podaj ID:");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj marke:");
                    marka = Console.ReadLine();
                    Console.WriteLine("Podaj model:");
                    model = Console.ReadLine();
                    Console.WriteLine("Podaj kolor:");
                    kolor = Console.ReadLine();
                    Console.WriteLine("Podaj przebieg:");
                    przebieg = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj cene:");
                    cena = int.Parse(Console.ReadLine());
                    string q4 = $"INSERT INTO auto VALUES({id}, '{marka}', '{model}', '{kolor}' , {przebieg} , {cena})";
                    cmd3.CommandText = q4;
                    SQLiteDataReader rdr3 = cmd3.ExecuteReader();
                    rdr3.Close();
                    Console.WriteLine("Pomyślnie dodano auto do bazy:)");
                    Console.WriteLine();
                }
                else if (a == "4")
                {
                    Console.WriteLine("Podaj ID auta ktore chcesz usunac: ");
                    id = int.Parse(Console.ReadLine());
                    string q5 = $"DELETE FROM `auto` WHERE nr={id}";
                    cmd3.CommandText = q5;
                    SQLiteDataReader rdr3 = cmd3.ExecuteReader();
                    rdr3.Close();
                    Console.WriteLine("Pomyslnie usunieto auto:)");
                    Console.WriteLine();
                }
                else if (a == "5");
                else Console.WriteLine("Wybierz numer od 1 - 5!");
                Console.WriteLine();
            }
            conn.Close();
        }
    }
}
