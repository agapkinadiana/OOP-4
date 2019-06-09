using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using Configuration;
using lab8.View;


namespace lab8
{
    class SqlController
    {
        #region query
        private static string sqlExpressionDiscipline = "SELECT * FROM Discipline";
        private static string sqlExpressionLector = "SELECT * FROM Lector";
        private static string sqlExpressionCreateDB = "USE master; CREATE DATABASE userdb;";
        private static string sqlExpressionCreateTables = "USE userdb; CREATE table Discipline(id int primary key  identity(1,1),name nvarchar(50),speciality nvarchar(50),testing nvarchar(50),course int,semester int,amount_of_students int);CREATE table Lector(id int primary key identity(1,1) ,name_of_lector nvarchar(50),lectrum nvarchar(50),auditorium int);";
        #endregion

        #region connections
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static SqlConnection connection = new SqlConnection(connectionString);

        private static string _connectionString = ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;
        private static SqlConnection _connection = new SqlConnection(_connectionString);

        private static SqlDataAdapter dataAdapterDis = new SqlDataAdapter(sqlExpressionDiscipline, connection);
        private static SqlDataAdapter dataAdapterLect = new SqlDataAdapter(sqlExpressionLector, connection);

        private static DataSet dataSet = new DataSet();
        private static DataSet _dataSet = new DataSet();
        #endregion

        private static DbDataContext dataContext = new DbDataContext();


        #region open/close methods
        public static void OpenConnection()
        {
            try
            {
                connection.Open();
                MessageBox.Show("Есть подключение к БД");
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Создается БД");

                SqlCommand command = new SqlCommand(sqlExpressionCreateDB, _connection);
                SqlCommand _command = new SqlCommand(sqlExpressionCreateTables, _connection);

                _connection.Open();

                command.ExecuteNonQuery();
                _command.ExecuteNonQuery();

                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                connection.Close();
                MessageBox.Show("Подключение к БД закрыто");
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        public static void Read()
        {
            dataSet.Clear();
            _dataSet.Clear();

            DbDataContext.ClearCollections();

            dataAdapterDis.Fill(dataSet);
            dataAdapterLect.Fill(_dataSet);

            DataTable dt = dataSet.Tables[0];
            DataTable _dt = _dataSet.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var obj = new Discipline(
                    (int)row["id"],
                    (string)row["name"],
                    (string)row["speciality"],
                    (string)row["testing"],
                    (int)row["course"],
                    (int)row["semester"],
                    (int)row["amount_of_students"]
                    );
                dataContext.Disciplines.Add(obj);
            }

            foreach (DataRow row in _dt.Rows)
            {
                var obj = new Lector(
                    (int)row["id"],
                    (string)row["name_of_lector"],
                    (string)row["lectrum"],
                    (int)row["auditorium"]
                    );
                dataContext.Lectors.Add(obj);
            }
        }

        public static void Write(DataGrid disciplineGrid, DataGrid lectorGrid)
        {
            try
            {
                DataTable dt = dataSet.Tables[0];
                DataTable _dt = _dataSet.Tables[0];


                int i = 0, j = 0;

                foreach (Discipline dis in dataContext.Disciplines)
                {
                    if (dt.Rows.Count <= i)
                    {
                        dt.Rows.Add();//"id", "name", "speciality", "testing", "course", "semester", "amount_of_students");
                    }

                    dt.Rows[i]["id"] = dis.Id;
                    dt.Rows[i]["name"] = dis.Name;
                    dt.Rows[i]["speciality"] = dis.Speciality;
                    dt.Rows[i]["testing"] = dis.Testing;
                    dt.Rows[i]["course"] = dis.Course;
                    dt.Rows[i]["semester"] = dis.Semester;
                    dt.Rows[i]["amount_of_students"] = dis.AmountOfStudents;
                    i++;

                }

                foreach (Lector lect in dataContext.Lectors)
                {
                    if (_dt.Rows.Count <= j)
                    {
                        _dt.Rows.Add();
                    }
                    _dt.Rows[j]["id"] = lect.Id;
                    _dt.Rows[j]["name_of_lector"] = lect.NameOfLector;
                    _dt.Rows[j]["lectrum"] = lect.Lectrum;
                    _dt.Rows[j]["auditorium"] = lect.Auditorium;
                    j++;
                }

                SqlCommandBuilder com = new SqlCommandBuilder(dataAdapterDis);
                SqlCommandBuilder _com = new SqlCommandBuilder(dataAdapterLect);

                dataAdapterDis.Update(dataSet);
                dataAdapterLect.Update(_dataSet);
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteByID(DataGrid currentGrid)
        {
            int currentRowIndex = (int)currentGrid.Items.IndexOf(currentGrid.CurrentItem),
                id;
            string sqlExpressionDeleteRow = "DELETE FROM table WHERE id = value;";


            switch (currentGrid.Name)
            {
                case "disList":
                    sqlExpressionDeleteRow = sqlExpressionDeleteRow.Replace("table", "Discipline");

                    id = dataContext.Disciplines[currentRowIndex].Id;
                    sqlExpressionDeleteRow = sqlExpressionDeleteRow.Replace("value", id.ToString());
                    break;

                case "lectList":
                    sqlExpressionDeleteRow = sqlExpressionDeleteRow.Replace("table", "Lector");

                    id = dataContext.Lectors[currentRowIndex].Id;
                    sqlExpressionDeleteRow = sqlExpressionDeleteRow.Replace("value", id.ToString());
                    break;
            }

            try
            {
                SqlCommand command = new SqlCommand(sqlExpressionDeleteRow, connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Sort()
        {
            var elements = from elem in dataContext.Disciplines
                           orderby elem.AmountOfStudents descending
                           select elem;

            foreach (var el in elements)
            {
                MessageBox.Show(el.Id + " " + el.Name + " " + el.AmountOfStudents);
            }
        }
    }
}
