using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using UniversityManagement.Domain.Utility;

namespace UniversityManagement.Domain.Entities
{
    public class Department
    {
        public Department(string name, string code)
        {
            Name = name;
            Code = code;
            
        }
        public long Id { get; private set; }
        public long UniversityId { get; private set; }
        public University University { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        private readonly List<Student> _students = new List<Student>();
        public virtual IReadOnlyList<Student> Students => _students.AsReadOnly();
       

        public void AddStudent(Student student)
        {
            if (_students.Count >=5)
            {
                throw new BusinessRuleValidationException("You cannot add more than 5 students in a department");
            }
            
            if (_students.Exists(x => x.Email == student.Email))
            {
                throw new BusinessRuleValidationException("student email already exists.");
            }
            _students.Add(student);
        }

        public void DeleteStudent(long id)
        {
            var student = _students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new BusinessRuleValidationException("No data found");
            }
            _students.Remove(student);
        }
        public void Update(long id,Student entry)
        {
            
            var student = _students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                throw new BusinessRuleValidationException("No data found");
            }
            student.UpdateStudent(entry);
            
        }
        
    }
}