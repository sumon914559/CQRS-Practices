using System.Collections.Generic;
using UniversityManagement.Domain.Utility;

namespace UniversityManagement.Domain.Entities
{
    public class Student
    {
        public Student(string name, string email)
        {
            if (!HelperFunctions.EmailIsValid(email))
            {
                new BusinessRuleValidationException("Invalid Email Format");
            }
            Name = name;
            Email = email;
        }
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public long DepartmentId { get; private set; }
        public Department Department { get; private set; }

        public void UpdateStudent(Student entry)
        {
            this.Email = entry.Email;
            this.Name = entry.Name;
        }
        
        
    }
}