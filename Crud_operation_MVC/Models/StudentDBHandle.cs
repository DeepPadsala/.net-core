using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Crud_operation_MVC.Models;
namespace Crud_operation_MVC.Models
{
    public class StudentDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["StudentConn"].ToString();
            con = new SqlConnection(constring); 
        }

        //insert
        public bool AddStudnet(StudentModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewStudent1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", smodel.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", smodel.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", smodel.LastName);
            cmd.Parameters.AddWithValue("@Email", smodel.Email);
            cmd.Parameters.AddWithValue("@BirthDate", smodel.BirthDate);
            cmd.Parameters.AddWithValue("@Coursrname", smodel.Coursrname);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }else
            {
                return false;
            }
        }
        //update 
        public bool UpdateDetails(StudentModel smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudentDetails1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", smodel.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", smodel.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", smodel.LastName);
            cmd.Parameters.AddWithValue("@Email", smodel.Email);
            cmd.Parameters.AddWithValue("@BirthDate", smodel.BirthDate);
            cmd.Parameters.AddWithValue("@Coursrname", smodel.Coursrname);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        //Delete
        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent1", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        public List<StudentModel> GetStudent()
        {
            connection();
            List<StudentModel> studentlist = new List<StudentModel>();
            SqlCommand cmd = new SqlCommand("GetStudentDetails1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                studentlist.Add(
                    new StudentModel
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        MiddleName = Convert.ToString(dr["MiddleName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Email = Convert.ToString(dr["Email"]),
                        BirthDate = Convert.ToString(dr["BirthDate"]),
                        Coursrname = Convert.ToString(dr["Coursrname"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
            });
            }
            return studentlist;
        }
    }
}