using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using LoadBL.Entities;
using LoadBL.Interfaces;

namespace LoadBL.Models
{
    public class LoadDao : ILoadDao
    {
        public Load Get(int id)
        {
            // Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                // Открываем соединение 
                conn.Open();
                // Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    // Задаем текст команды
                    cmd.CommandText = "SELECT LoadId,Teacher, Subject, [Group], HousPlan, HousActuality,Type FROM Load WHERE LoadId = @id";
                    // Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    // Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : LoadLoad(dataReader);
                    } 
                }
            }
        }        

        public IList<Load> GetAll()
        {
            IList<Load> loads = new List<Load>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT LoadId,Teacher, Subject, [Group], HousPlan, HousActuality,Type FROM Load";
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            loads.Add(LoadLoad(dataReader));
                        }
                    }
                }
            }
            return loads;
        }

        public void Add(Load load)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Load (Teacher, Subject, [Group], HousPlan, HousActuality,Type) " +
                        "VALUES (@Teacher, @Subject, @Group, @HousPlan, @HousActuality, @Type)";
                    cmd.Parameters.AddWithValue("@Teacher", load.Teacher);
                    cmd.Parameters.AddWithValue("@Subject", load.Subject);
                    cmd.Parameters.AddWithValue("@Group", load.Group);
                    cmd.Parameters.AddWithValue("@HousPlan", load.HousPlan);                    
                    cmd.Parameters.AddWithValue("@Type", load.Type);
                    object actuality = load.HousActuality.HasValue ? 
                        (object)load.HousActuality.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@HousActuality", actuality);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Load load)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Load SET Teacher = @Teacher, Subject = @Subject, [Group] = @Group, " +
                        "HousPlan = @HousPlan, HousActuality = @HousActuality, Type = @Type WHERE LoadId = @Id";
                    cmd.Parameters.AddWithValue("@Teacher", load.Teacher);
                    cmd.Parameters.AddWithValue("@Subject", load.Subject);
                    cmd.Parameters.AddWithValue("@Group", load.Group);
                    cmd.Parameters.AddWithValue("@HousPlan", load.HousPlan);
                    cmd.Parameters.AddWithValue("@Type", load.Type);
                    cmd.Parameters.AddWithValue("@Id", load.LoadId);
                    object actuality = load.HousActuality.HasValue ?
                        (object)load.HousActuality.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@HousActuality", actuality);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Load WHERE LoadId = @Id";

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            } 
        }

        private static Load LoadLoad(SqlDataReader reader)
        {
            // Создаем пустой объект
            Load load = new Load
            {
                // Заполняем поля объекта в соответствии с названиями полей результирующего
                // набора данных 
                LoadId = reader.GetInt32(reader.GetOrdinal("LoadId")),
                HousPlan = Convert.ToInt32(reader["HousPlan"])
            };
            // Помните, что у вас поле HousActuality может иметь значение NULL? 
            // Следующие три строки корректно обрабатывают этот случай
            object actuality = reader["HousActuality"];
            // Проверка
            if (actuality != DBNull.Value)
                load.HousActuality = Convert.ToInt32(actuality);
            load.Teacher = reader.GetString(reader.GetOrdinal("Teacher"));
            load.Subject = reader.GetString(reader.GetOrdinal("Subject"));
            load.Group = reader.GetString(reader.GetOrdinal("Group"));
            load.Type = reader.GetString(reader.GetOrdinal("Type"));
            return load;
        }

        /// <summary>
        ///  Возвращает строку подключения к базе
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Load"].ConnectionString;
        }

        /// <summary>
        ///  Возвращает объект подключения к базе
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}
