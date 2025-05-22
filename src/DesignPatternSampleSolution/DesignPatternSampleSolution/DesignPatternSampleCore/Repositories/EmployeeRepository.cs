using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DesignPatternSampleCore.Models;
using DesignPatternSampleCore.Singleton;

namespace DesignPatternSampleCore.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll()
        {
            var employees = new List<Employee>();
            using (var conn = DatabaseConnectionManager.Instance.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT Id, FirstName, LastName, Department, HireDate FROM Employees";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var emp = new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Department = reader.GetString(3),
                            HireDate = reader.GetDateTime(4)
                        };
                        employees.Add(emp);
                    }
                }
            }
            return employees;
        }

        public Employee GetById(int id)
        {
            Employee emp = null;
            using (var conn = DatabaseConnectionManager.Instance.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"SELECT Id, FirstName, LastName, Department, HireDate 
                                    FROM Employees
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        emp = new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Department = reader.GetString(3),
                            HireDate = reader.GetDateTime(4)
                        };
                    }
                }
            }
            return emp;
        }

        public void Add(Employee employee)
        {
            using (var conn = DatabaseConnectionManager.Instance.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"INSERT INTO Employees (FirstName, LastName, Department, HireDate)
                                    VALUES (@FirstName, @LastName, @Department, @HireDate)";
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee employee)
        {
            using (var conn = DatabaseConnectionManager.Instance.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"UPDATE Employees
                                    SET FirstName = @FirstName, LastName = @LastName,
                                        Department = @Department, HireDate = @HireDate
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@HireDate", employee.HireDate);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseConnectionManager.Instance.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = @"DELETE FROM Employees WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
