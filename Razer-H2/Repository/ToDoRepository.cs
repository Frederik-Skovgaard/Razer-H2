using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Razer_H2.Modul;
using System.Data;


namespace Razer_H2.Repository
{
    public class ToDoRepository : IToDoRepository
    {

        internal static IConfigurationRoot configuration { get; set; }
        static string connectionString;

        SqlConnection sql = new SqlConnection(connectionString);

        public static void SetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            configuration = builder.Build();
            connectionString = configuration.GetConnectionString("TodoDatabase");
        }


        private List<ToDo> toDosList = new List<ToDo>();
        private ToDo toDos = null;

        private List<Contact> contactsList = new List<Contact>();
        private Contact contact = null;


        /// <summary>
        /// Create new ToDo
        /// </summary>
        /// <param name="desc"></param>
        public void CreateToDo(ToDo toDo)
        {
            sql.Open();

            SqlCommand createTodo = new SqlCommand("Create", sql);
            createTodo.CommandType = CommandType.StoredProcedure;

            createTodo.Parameters.AddWithValue("@description", toDo.TaskDescription);
            createTodo.Parameters.AddWithValue("@status", toDo.IsCompleted);

            createTodo.Parameters.AddWithValue("@Priority", toDo.Priority);

            createTodo.ExecuteNonQuery();

            sql.Close();
        }

        /// <summary>
        /// Delete ToDo
        /// </summary>
        /// <param name="id"></param>
        public void DeleteToDo(ToDo toDo)
        {
            sql.Open();

            SqlCommand deleteTodo = new SqlCommand("Delete", sql);
            deleteTodo.CommandType = CommandType.StoredProcedure;

            deleteTodo.Parameters.AddWithValue("@id", toDo.Todo_ID);


            deleteTodo.ExecuteNonQuery();

            sql.Close();
        }

        /// <summary>
        /// Read all ToDo's
        /// </summary>
        public List<ToDo> ReadAllToDo()
        {
            if (toDosList.Count != 0)
            {
                toDosList.Clear();
            }


            sql.Open();

            SqlCommand readAlle = new SqlCommand("ReadAll", sql);
            readAlle.CommandType = CommandType.StoredProcedure;


            using (SqlDataReader read = readAlle.ExecuteReader())
            {
                while (read.Read())
                {
                    toDos = new ToDo
                    {
                        Todo_ID = read.GetInt32(0),
                        CreatedTime = read.GetDateTime(1),
                        TaskDescription = read.GetString(2),
                        Priority = read.GetInt32(3),
                        IsCompleted = read.GetBoolean(4)

                    };

                    toDosList.Add(toDos);
                }
            };
             
             
            sql.Close();
             
            return toDosList;
        }

        /// <summary>
        /// Update ToDo
        /// </summary>
        /// <param name="id"></param>
        public void UpdateToDo(ToDo obj)
        {
            sql.Open();

            SqlCommand update = new SqlCommand("Update", sql);
            update.CommandType = CommandType.StoredProcedure;

            update.Parameters.AddWithValue("@id", obj.Todo_ID);

            update.Parameters.AddWithValue("@description", obj.TaskDescription);
            update.Parameters.AddWithValue("@status", obj.IsCompleted);

            update.Parameters.AddWithValue("@Priority", obj.Priority);  

            update.ExecuteNonQuery();

            sql.Close();
        }

        /// <summary>
        /// Find ToDo with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDo FindToDo(int id)
        {
            sql.Open();

            SqlCommand findById = new SqlCommand("GetByID", sql);
            findById.CommandType = CommandType.StoredProcedure;

            findById.Parameters.AddWithValue("@id", id);


            using (SqlDataReader read = findById.ExecuteReader()) {
                while (read.Read())
                {
                    toDos = new ToDo
                    {
                        Todo_ID = read.GetInt32(0),
                        CreatedTime = read.GetDateTime(1),
                        TaskDescription = read.GetString(2),
                        Priority = read.GetInt32(3),
                        IsCompleted = read.GetBoolean(4)
                    };

                }
            }
           
            sql.Close();

            return toDos;
        }


        //Contact CRUD

        public void CreateContact(Contact obj)
        {
            sql.Open();

            SqlCommand create = new SqlCommand("CreateContact", sql);
            create.CommandType = CommandType.StoredProcedure;

            create.Parameters.AddWithValue("@email", obj.Email);
            create.Parameters.AddWithValue("@phone", obj.Phone);
            create.Parameters.AddWithValue("@f_Name", obj.FirstName);
            create.Parameters.AddWithValue("@m_Name", obj.MiddleName);
            create.Parameters.AddWithValue("@l_Name", obj.LastName);

            create.ExecuteNonQuery();

            sql.Close();
        }

        public void DeleteContact(Contact obj)
        {
            sql.Open();

            SqlCommand deleteTodo = new SqlCommand("DeleteContact", sql);
            deleteTodo.CommandType = CommandType.StoredProcedure;

            deleteTodo.Parameters.AddWithValue("@id", obj.Contact_ID);


            deleteTodo.ExecuteNonQuery();

            sql.Close();
        }

        public List<Contact> ReadAllContacts()
        {
            if (toDosList.Count != 0)
            {
                toDosList.Clear();
            }


            sql.Open();

            SqlCommand readAlle = new SqlCommand("GetAllContacts", sql);
            readAlle.CommandType = CommandType.StoredProcedure;


            using (SqlDataReader read = readAlle.ExecuteReader())
            {
                while (read.Read())
                {
                    contact = new Contact
                    {
                        Contact_ID = read.GetInt32(0),
                        Email = read.GetString(1),
                        Phone = read.GetInt32(2),
                        FirstName = read.GetString(3),
                        MiddleName = read.GetString(4),
                        LastName = read.GetString(5)
                    };

                    contactsList.Add(contact);
                }
            };


            sql.Close();

            return contactsList;
        }

        public void UpdateContact(Contact obj)
        {
            sql.Open();

            SqlCommand update = new SqlCommand("UpdateContact", sql);
            update.CommandType = CommandType.StoredProcedure;

            update.Parameters.AddWithValue("@id", obj.Contact_ID);

            update.Parameters.AddWithValue("@email", obj.Email);
            update.Parameters.AddWithValue("@phone", obj.Phone);

            update.Parameters.AddWithValue("@f_Name", obj.FirstName);
            update.Parameters.AddWithValue("@m_Name", obj.MiddleName);
            update.Parameters.AddWithValue("@l_Name", obj.LastName);

            update.ExecuteNonQuery();

            sql.Close();
        }
    }
}
