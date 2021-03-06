﻿using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Data.Repositories
{
    public static class RepositoryManager
    {

        public static RepositoryDepartment RepositoryDepartment = new RepositoryDepartment();
        public static RepositoryEmployee RepositoryEmployee = new RepositoryEmployee();
        public static RepositoryDepartmentsOverview RepositoryDepartmentsOverview = new RepositoryDepartmentsOverview();


        public static void ExecuteSqlCommand(Action<SqlCommand> executeAction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = connection;
                            executeAction.Invoke(command);
                        }
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine($"Error happend during  Execution \n Error info:{e.Message}\n{e.StackTrace}");
                        //logger 
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error happend during  Connecting \n Error info:{e.Message}\n{e.StackTrace}");
            }
        }



    }
}
