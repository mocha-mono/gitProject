using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMedical
{
    internal class PatientsDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=medical;";

        public List<Patient> GetAllPatients()
        {
            List<Patient> returnThese = new List<Patient>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM PATIENTS_TABLE", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Patient a = new Patient
                    {
                        ID = reader.GetInt32(0),
                        LastName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        MiddleName = reader.GetString(3),
                        SuffixName = reader.GetString(4),
                        BirthDate = reader.GetDateTime(5),
                        Address = reader.GetString(6),
                    };
                    returnThese.Add(a);

                }
            }
            connection.Close();

            return returnThese;
        }

        public List<Patient> SearchPatients(String searchPatient)
        {
            List<Patient> returnThese = new List<Patient>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            String searchWildPhrase ="%" + searchPatient + "%";

            MySqlCommand command = new MySqlCommand();
                command.CommandText = "SELECT ID, LastName, FirstName, MiddleName, SuffixName, BirthDate, Address FROM PATIENTS_TABLE WHERE LastName LIKE @search"; 
                command.Parameters.AddWithValue("@search", searchWildPhrase);
                command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Patient a = new Patient
                    {
                        ID = reader.GetInt32(0),
                        LastName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        MiddleName = reader.GetString(3),
                        SuffixName = reader.GetString(4),
                        BirthDate = reader.GetDateTime(5),
                        Address = reader.GetString(6),
                    };
                    returnThese.Add(a);

                }
            }
            connection.Close();

            return returnThese;
        }
    }
}
