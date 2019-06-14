using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SchoolServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {

        [OperationContract]
        Student CreateStudent(string name, string surname, DateTime birthDay);
        [OperationContract]
        List<Student> GetAllStudents(int departmentId);
    }
}
