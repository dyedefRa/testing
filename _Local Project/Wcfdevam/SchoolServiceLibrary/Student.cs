using System;
using System.Runtime.Serialization;

namespace SchoolServiceLibrary
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public Status Statu { get; set; }
        public DateTime BirthDay { get; set; }

        //    [IgnoreDataMember]  bu , datayı nokta atışı ile gözüktürtme demek


        public enum Status
        {
            [EnumMember]
            Active,
            [EnumMember]
            Passive,
            [EnumMember]
            Deleted,
            None
        }
    }
}
