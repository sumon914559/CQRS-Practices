using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityManagement.Domain.Utility;

namespace UniversityManagement.Domain.Entities
{
    public class University
    {
        public University(string name)
        {
            Name = name;
        }
        public long Id { get; private set; }
        public string Name { get; private set; }
        private readonly List<Department> _department = new List<Department>();
        public virtual IReadOnlyList<Department> Departments => _department.AsReadOnly();

        public void AddDepartment(Department department)
        {

            if (_department.Count >=5)
            {
                throw new BusinessRuleValidationException("You cannot add more than 5 departments in a university");
            }
            if (_department.Exists(x => x.Code == department.Code))
            {
                throw new BusinessRuleValidationException("Department code already exists.");
            }
            if (_department.Exists(x => x.Name == department.Name))
            {
                throw new BusinessRuleValidationException("Department name already exists.");
            }
        }
    }
}