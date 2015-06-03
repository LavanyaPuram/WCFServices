using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in both code and config file together.
    public class EmployeeService : IEmployeeService
    {

        public Employee GetEmployee(int Id)
        {
            Employee employee = new Employee();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_GetEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@Id", Id);
            cmd.Parameters.Add(p);
            if(con.State!=ConnectionState.Open)
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                employee.Id = Convert.ToInt32(dr["Id"]);
                employee.Name = dr["Name"].ToString();
                employee.Gender = dr["Gender"].ToString();
                employee.DOB = Convert.ToDateTime(dr["DOB"]);
            }
            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_SaveEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@Id",employee.Id),
               new SqlParameter("@Name",employee.Name),
               new SqlParameter("@Gender",employee.Gender),
               new SqlParameter("@DOB",employee.DOB)
            };
            cmd.Parameters.AddRange(p);
            if (con.State != ConnectionState.Open)
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void UpdateEmployee(Employee employee)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] p = new SqlParameter[]
            {
               new SqlParameter("@Id",employee.Id),
               new SqlParameter("@Name",employee.Name),
               new SqlParameter("@Gender",employee.Gender),
               new SqlParameter("@DOB",employee.DOB)
            };
            cmd.Parameters.AddRange(p);
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void DeleteEmployee(int Id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p = new SqlParameter("@Id", Id);
            cmd.Parameters.Add(p);
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
