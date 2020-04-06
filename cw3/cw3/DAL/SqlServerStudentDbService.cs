using cw3.DAL;
using cw3.DTOs.Requests;
using cw3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Wyklad5.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {

        public SqlServerStudentDbService(/*.. */ )
        {

        }

        public void EnrollStudent(EnrollStudentRequest request)
        {
            //DTOs - Data Transfer Objects
            //Request models
            //==mapowanie==
            //Modele biznesowe/encje (entity)
            //==mapowanie==
            //Response models

            var st = new Student();
            st.FirstName = request.FirstName;
            st.LastName = request.LastName;
            st.IndexNumer = request.IndexNumber;
            st.BirthDate = request.Birthdate;
            st.StudiesName = request.Studies;
            st.Semester = request.Semester;

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18840;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    //1. Czy studia istnieja?
                    com.CommandText = "select IdStudies from studies where name=@studiesName";
                    com.Parameters.AddWithValue("studiesName", request.Studies);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        tran.Rollback();
                        
                    }
                    int idstudies = (int)dr["IdStudies"];

                    //x. Dodanie studenta
                    com.CommandText = "Select IdEnrollment FROM Enrollments where semester=1 AND idStudy=@idstudy";
                    com.Parameters.AddWithValue("idStudy", idstudies);
                    dr = com.ExecuteReader();
                    if(!dr.Read())
                    {
                        com.CommandText = "Insert INTO Enrollemnts (StartDate, Semester, IdStudy) Values (@date,1,@idstudy)";
                        com.Parameters.AddWithValue("date",DateTime.Now);
                        com.CommandText = "Select IdEnrollment FROM Enrollments";
                        dr = com.ExecuteReader();

                    }
                    //...
                    com.ExecuteNonQuery();

                    tran.Commit();

                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }

        }

        public void PromoteStudents(PromoteStudentRequest promRequest)
        {
           
        }

        public void PromoteStudents(int semester, string studies)
        {
            throw new NotImplementedException();
        }
    }
}
