using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SMS.DAL;

namespace SMS.BLL
{
    public class StudentBLL
    {
        StudentDAL dal = new StudentDAL();

        public DataTable GetAllStudents()
        {
            return dal.GetAllStudents();
        }

        public DataTable GetStudentById(int id)
        {
            return dal.GetStudentById(id);
        }

        public void CreateStudent(string name, int age, string className)
        {
            dal.InsertStudent(name, age, className);
        }

        public void UpdateStudent(int id, string name, int age, string className)
        {
            dal.UpdateStudent(id, name, age, className);
        }

        public void DeleteStudent(int id)
        {
            dal.DeleteStudent(id);
        }
    }
}