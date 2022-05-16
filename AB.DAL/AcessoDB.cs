using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AB.DAL
{
    public class AcessoDB
    {
        private static SqlConnection GetDbConnection()
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["conexaoClienteSQLServer"].ConnectionString;
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static IDataReader ExecuteReader(string sql)
        {
            IDataReader reader = null;
            using (SqlConnection connection = GetDbConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        reader = command.ExecuteReader();
                    }
                }
                catch
                {
                    throw;
                }
                return reader;
            }
        }
        public static int ExecuteNonQuery(string sql)
        {
            int i = -1;
            using (SqlConnection connection = GetDbConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        i = command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    throw;
                }
                return i;
            }
        }
               
        public static DataSet ExecuteDataSet(string sql)
        {
            DataSet ds = null;
            using (SqlConnection connection = GetDbConnection())
            {
                try
                {
                    using (SqlCommand Command = new SqlCommand(sql, connection))
                    {
                        ds = ExecuteDataSet();
                    }
                }
                catch
                {
                    throw;
                }
                return ds;
            }
        }
        public static DataSet ExecuteDataSet()
        {
            SqlDataAdapter da = null;
            IDbCommand cmd = new SqlCommand();
            DataSet ds = null;
            try
            {
                da = new SqlDataAdapter();
                da.SelectCommand = (SqlCommand)cmd;
                ds = new DataSet();
                da.Fill(ds);
            }
            catch
            {
                throw;
            }
            return ds;
        }
        public static DataTable GetDataTable(string sql, string[] parameterNames, string[] parameterVals)
        {
            using (SqlConnection connection = GetDbConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, connection))
                {
                    DataTable table = new DataTable();
                    FillParameters(da.SelectCommand, parameterNames, parameterVals);
                    da.Fill(table);
                    return table;
                }
            }
        }
        public static DataTable GetDataTable(string sql)
        {
            using (SqlConnection connection = GetDbConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, connection))
                {
                    DataTable table = new DataTable();
                    da.Fill(table);
                    return table;
                }
            }
        }
        public static string SelectScalar(string sql, string[] parameterNames, string[] parameterVals)
        {
            using (SqlConnection connection = GetDbConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    FillParameters(command, parameterNames, parameterVals);
                    return Convert.ToString(command.ExecuteScalar());
                }
            }
        }
        public static string SelectScalar(string sql)
        {
            using (SqlConnection connection = GetDbConnection())
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    return Convert.ToString(command.ExecuteScalar());
                }
            }
        }
        public static int CRUD(string sql, string[] parameterNames, string[] parameterVals)
        {
            try
            {
                using (SqlConnection connection = GetDbConnection())
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        FillParameters(command, parameterNames, parameterVals);
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void FillParameters(SqlCommand command, string[] parameterNames, string[] parameterVals)
        {
            try
            {
                if (parameterNames != null)
                {
                    for (int i = 0; i <= parameterNames.Length - 1; i++)
                    {
                        command.Parameters.AddWithValue(parameterNames[i], parameterVals[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

