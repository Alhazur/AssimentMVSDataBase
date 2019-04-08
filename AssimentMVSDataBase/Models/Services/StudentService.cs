using AssimentMVSDataBase.Database;
using AssimentMVSDataBase.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AssimentMVSDataBase.Models.Mock
{
    public class StudentService : IStudentService
    {
        readonly SchoolDbContext _schoolDbContext;

        public StudentService(SchoolDbContext schoolDbContext)//(klass Databas) 
        {
            _schoolDbContext = schoolDbContext;
        }

        public List<Student> AllStudents()
        {
            return _schoolDbContext.Students.Include(c => c.StudentsCourses).ToList();
        }

        public Student CreateStudent(string name, string phone, string location)
        {
            Student student = new Student() { Name = name, Phone = phone, Location = location };

            _schoolDbContext.Students.Add(student);
            _schoolDbContext.SaveChanges();
            return student;
        }

        public bool DeleteStudent(int id)
        {
            bool wasRemoved = false;

            Student student = _schoolDbContext.Students.SingleOrDefault(f => f.Id == id);

            if (student == null)
            {
                return wasRemoved;
            }

            _schoolDbContext.Students.Remove(student);
            _schoolDbContext.SaveChanges();
            return wasRemoved;
        }

        public Student FindStudent(int id)
        {
            return _schoolDbContext.Students.SingleOrDefault(f => f.Id == id);
        }

        public bool UpdateStudent(Student student)
        {
            bool wasUpdate = false;
            Student stud = _schoolDbContext.Students.SingleOrDefault(item => item.Id == student.Id);
            {
                if (stud != null)
                {
                    stud.Name = student.Name;
                    stud.Phone = student.Phone;
                    stud.Location = student.Location;

                    _schoolDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
