using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static SchoolServiceLibrary.Student;

namespace SchoolServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in both code and config file together.
    public class StudentService : IStudentService
    {
        public Student CreateStudent(string name, string surname, DateTime birthDay)
        {
            Random r = new Random();
            Student student = new Student()
            {
                Number = r.Next(1, 100),
                Name = name,
                Surname = surname,
                BirthDay = birthDay,
                Statu=Status.Active
            };


            return student;
        }

        public List<Student> GetAllStudents(int departmentId)
        {
            return new List<Student>()
          {
              new Student() { Number=15 , BirthDay=new DateTime(1955,5,13), Name="Ali",Surname="Yılmaz",Statu=Status.Active },
              new Student() { Number=40 , BirthDay=new DateTime(1985,8,1), Name="Hakan",Surname="Yılmaz",Statu=Status.Active }
          };
        }
    }
}
