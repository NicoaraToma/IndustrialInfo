using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Covid19Proiect.Controllers
{
    public class DataBaseManager
    {
        SqlConnection conn;
        string connectionString = @"Data Source=DESKTOP-PB2NTIE; Initial Catalog= Hospital; User ID=DESKTOP-PB2NTIE\mihaidurus; Password=";
        public DataBaseManager()
        {
            conn = new SqlConnection(connectionString);
        }
        public void getUsers()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Users";
            SqlCommand command;
            SqlDataReader dataReader;
            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();
            string output = "";
            while (dataReader.Read())
            {
                output += dataReader.GetValue(0);
            }
            conn.Close();
        }
        public void editUsers(string nume, string prenume, string CNP, string parola, string email, string nrTelefon)
        {
            conn.Open();
            string n, p, id, pass, mail, tel;

            n = nume;
            p = prenume;
            id = CNP;
            pass = parola;
            mail = email;
            tel = nrTelefon;

            string getId = "SELECT id FROM dbo.Users";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int userId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                userId = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Users SET Users.nume=n,  Users.prenume=p,  Users.CNP=id,  Users.parola=pass,  Users.email=mail,  Users.nrTelefon=tel " +
                "WHERE Users.id=userId";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();

            }
        public void deleteUsers()
        {

            conn.Open();
           
            string getId = "SELECT id FROM dbo.Users";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int userId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                userId = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Users WHERE Users.id=userId";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void getMedicalProfile()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.ProfilMedical";
            SqlCommand command;
            SqlDataReader dataReader;
            command = new SqlCommand(query, conn);
            dataReader = command.ExecuteReader();
            string output = "";
            while (dataReader.Read())
            {
                output += dataReader.GetValue(0);
            }
            conn.Close();
        }
        public void editMedicalProfile(string varsta, string gen, string grupaSanguina, string boliCronice, string anticorpi, string simptome)
        {
            conn.Open();
            string v, g, grs, bc, ac, simp;

             = nume;
            p = prenume;
            id = CNP;
            pass = parola;
            mail = email;
            tel = nrTelefon;

            string getId = "SELECT id FROM dbo.ProfilMedical";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int userId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                userId = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Users SET Users.nume=n,  Users.prenume=p,  Users.CNP=id,  Users.parola=pass,  Users.email=mail,  Users.nrTelefon=tel " +
                "WHERE Users.id=userId";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }
    }
       
}