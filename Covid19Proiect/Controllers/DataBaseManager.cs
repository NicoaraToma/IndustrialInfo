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
        public void editUsers(string nume, string prenume, string CNP, string parola, string email, string numarTelefon)
        {
            conn.Open();
            string n, p, id, pass, mail, tel;

            n = nume;
            p = prenume;
            id = CNP;
            pass = parola;
            mail = email;
            tel = numarTelefon;

            string getId = "SELECT id FROM dbo.Users";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int userId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                userId = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Users SET Users.nume=n,  Users.prenume=p,  Users.CNP=id,  Users.parola=pass,  Users.email=mail,  Users.numarTelefon=tel " +
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

            v = varsta;
            g = gen;
            grs = grupaSanguina;
            bc = boliCronice;
            ac = anticorpi;
            simp = simptome;

            string getId = "SELECT id FROM dbo.ProfilMedical";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int pmId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                pmId = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.ProfilMedical SET ProfilMedical.varsta=v, ProfilMedical.gen=g, ProfilMedical.grupaSanguina=grs, ProfilMedical.boliCronice=bc,  ProfilMedical.anticorpi=ac,  ProfilMedical.simptome=simp" +
                "WHERE ProfilMedical.id=pmId";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteProfilMedical()
        {

            conn.Open();

            string getId = "SELECT id FROM dbo.ProfilMedical";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int pmId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                pmId = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.ProfilMedical WHERE ProfilMedical.id=pmId";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void getProgramare()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Programare";
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
        public void editProgramare(string idClinica, string dataVaccin, string dataRepel)
        {
            conn.Open();
            string idc, dv, dr;

            idc = idClinica;
            dv = dataVaccin;
            dr = dataRepel;

            string getId = "SELECT id FROM dbo.Programare";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int prId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                prId = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Programare SET Programare.idClinica=idc, Programare.dataVaccin=dv, Programare.dataRapel=dr" +
                "WHERE Programare.id=prId";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteProgramare()
        {

            conn.Open();

            string getId = "SELECT id FROM dbo.Programare";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int prId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                prId = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Programare WHERE Programare.id=prId";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void getStoc()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Stoc";
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
        public void editStoc(string idClinica, string stocAstraZeneca, string stocPfizer,string stocSputnik,string stocModerna)
        {
            conn.Open();
            string idc, saz, sp,ss,sm;

            idc = idClinica;
            saz = stocAstraZeneca;
            sp = stocPfizer;
            ss = stocSputnik;
            sm = stocModerna;

            string getId = "SELECT id FROM dbo.Stoc";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int stocId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                stocId = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Stoc SET Stoc.idClinica=idc, Stoc.stocAstraZeneca=asz, Stoc.stocPfizer=sp, Stoc.stocSputnik=ss, Stoc.stocModerna=sm" +
                "WHERE Stoc.id=stocId";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteStoc()
        {

            conn.Open();

            string getId = "SELECT id FROM dbo.Stoc";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int stocId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                stocId = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Stoc WHERE Stoc.id=stocId";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void getComentariu()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Comentariu";
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
        public void editComentariu(string idUser, string idPost, string text, string data, string likeCounter)
        {
            conn.Open();
            string idu, idp, t, d, lc;

            idu = idUser;
            idp = idPost;
            t = text;
            d = data;
            lc = likeCounter;

            string getId = "SELECT id FROM dbo.Comentariu";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int cmId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                cmId = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Comenatariu SET Comenatariu.idUser=idu, Comentariu.idPost=idp, Comentariu.text=t, Comentariu.data=d, Comentariu.likeCounter=lc" +
                "WHERE Comentariu.id=cmId";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteComentariu()
        {

            conn.Open();

            string getId = "SELECT id FROM dbo.Comentariu";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int cmId;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                cmId = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Comentariu WHERE Comentariu.id=cmId";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }
        public void getAdmin()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Admin";
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

        public void editAdmin(string isAdmin)
        {
            conn.Open();
            string isAd;

            isAd = isAdmin;

            string getId = "SELECT id FROM dbo.Admin";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int admid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                admid = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Admin SET Admin.isAdmin=isAd " +
                "WHERE Admin.id=admid";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();

        }

        public void deletAdmin()
        {
            conn.Open();

            string getId = "SELECT id FROM dbo.Admin";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int admid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                admid = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Admin WHERE Admin.id=admid";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }


        public void getVaccin()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Vaccin";
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

        public void editVaccin(string nume, string durataRapel, string cantitate, string contraindicatii, string alergii)
        {
            conn.Open();
            string n, dr, cant, contr, al;

            n = nume;
            dr = durataRapel;
            cant = cantitate;
            contr = contraindicatii;
            al = alergii;

            string getId = "SELECT id FROM dbo.Vaccin";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int vid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                vid = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Vaccin SET Vaccin.nume=n,  Vaccin.durataRapel=dr,  Vaccin.cantitate=cant, Vaccin.contraindicatii=contr, Vaccin.alergii=al " +
                "WHERE Vaccin.id=vid";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteVaccin()
        {
            conn.Open();

            string getId = "SELECT id FROM dbo.Vaccin";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int vid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                vid = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Vaccin WHERE Vaccin.id=vid";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }

        public void getClinica()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Clinica";
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

        public void editClinica(string nume, string adresa, string numarProgramari)
        {
            conn.Open();
            string n, adr, nrProg;

            n = nume;
            adr = adresa;
            nrProg = numarProgramari;

            string getId = "SELECT id FROM dbo.Clinica";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int cid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                cid = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Clinica SET Clinica.nume=n,  Clinica.adresa=adr, Clinica.numarProgramari=nrProg " +
                "WHERE Clinica.id=cid";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteClinica()
        {
            conn.Open();

            string getId = "SELECT id FROM dbo.Clinica";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int cid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                cid = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Clinica WHERE Clinica.id=cid";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }


        public void getPostare()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Postare";
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

        public void editPostare(string idUser, string titlu, string text, string data, string likeCounter)
        {
            conn.Open();
            string uid, tit, txt, dat, lc;

            uid = idUser;
            tit = titlu;
            txt = text;
            dat = data;
            lc = likeCounter;

            string getId = "SELECT id FROM dbo.Postare";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int postid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                postid = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Clinica SET Postare.idUser=uid, Postare.titlu=tit, Postare.text=txt, Postare.data=dat, Postare.likeCounter=lc " +
                "WHERE Postare.id=postid";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }

        public void deletePostare()
        {
            conn.Open();

            string getId = "SELECT id FROM dbo.Postare";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int postid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                postid = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Postare WHERE Postare.id=postid";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }

        public void getResure()
        {
            conn.Open();
            string query = "SELECT * FROM dbo.Resurse";
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

        public void editResurse(string link)
        {
            conn.Open();
            string lk;

            lk = link;

            string getId = "SELECT id FROM dbo.Resurse";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int resid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                resid = (int)getIdReader.GetValue(0);

            }
            string query = "UPDATE dbo.Resurse SET Resurse.link=lk" +
                "WHERE Resurse.id=resid";
            SqlCommand edit = new SqlCommand(query, conn);
            edit.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteResurse()
        {
            conn.Open();

            string getId = "SELECT id FROM dbo.Resurse";
            SqlCommand getIdCommand = new SqlCommand(getId, conn);
            int resid;
            SqlDataReader getIdReader;
            getIdReader = getIdCommand.ExecuteReader();

            while (getIdReader.Read())
            {
                resid = (int)getIdReader.GetValue(0);

            }
            string query = "DELETE FROM dbo.Resurse WHERE Resurse.id=resid";
            SqlCommand delete = new SqlCommand(query, conn);
            delete.ExecuteNonQuery();
            conn.Close();
        }

    }

}