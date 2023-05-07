// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System;

namespace Registration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string username;
            string pw;
            string confirmpw;

            Console.WriteLine("Registration page\n");

            Console.WriteLine("Masukkan nama anda: ");
            name = Console.ReadLine();
            do
            {
                Console.WriteLine("Masukkan username anda: ");
                username = Console.ReadLine();
                if (checkUsername(username))
                {
                    Console.WriteLine("Username sudah ada, silahkan masukkan ulang.");
                }
            } while (checkUsername(username));


            Console.WriteLine("Masukkan password anda: ");
            pw = Console.ReadLine();

            do
            {
                Console.WriteLine("Konfirmasi password anda: ");
                confirmpw = Console.ReadLine();
                if (pw != confirmpw)
                {
                    Console.WriteLine("password tidak sama, silahkan masukkan ulang");
                }
                else
                {
                    
                }
            } while (pw != confirmpw);

            createAkun(name,username,pw);

            Console.WriteLine("Akun Berhasil dibuat!!!");
        }



        static bool checkUsername(string username)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ryans\OneDrive - Telkom University\Kuliah\Semester 6\Konstruksi Perangkat Lunak\Tubes\main\Registration\Database1.mdf"";Integrated Security=True");
            cn.Open();
            bool result;
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select * from UserDB where username='" + username + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                cn.Close();
                return true;
            }
            dr.Close();
            cn.Close();
            return false;

        }


        static void createAkun(string name, string username, string password)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ryans\OneDrive - Telkom University\Kuliah\Semester 6\Konstruksi Perangkat Lunak\Tubes\main\Registration\Database1.mdf"";Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("insert into UserDB values(@name,@username,@password)", cn);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            cmd.ExecuteNonQuery();
            cn.Close();
        }






    }
}






