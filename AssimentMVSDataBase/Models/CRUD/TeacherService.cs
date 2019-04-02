using AssimentMVSDataBase.Database;
using AssimentMVSDataBase.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Mock
{
    public class TeacherService : ITeacherService
    {
        readonly SchoolDbContext _schoolDbContext;

        public TeacherService(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public List<Teacher> AllTeacher()
        {
            return _schoolDbContext.Teacher.ToList();
        }

        public Teacher CreateTeacher(string name, string description)
        {
            Teacher teacher = new Teacher() { Name = name, Description = description };

            _schoolDbContext.Teacher.Add(teacher);
            _schoolDbContext.SaveChanges();
            return teacher;
        }

        public bool DeleteTeacher(int id)
        {
            bool wasRemoved = false;

            Teacher teacher = _schoolDbContext.Teacher.SingleOrDefault(teachers => teachers.Id == id);

            if (teacher == null)
            {
                return wasRemoved;
            }

            _schoolDbContext.Teacher.Remove(teacher);
            _schoolDbContext.SaveChanges();
            return wasRemoved;
        }

        public Teacher FindTeacher(int id)
        {
            return _schoolDbContext.Teacher.SingleOrDefault(teachers => teachers.Id == teachers.Id);

        }

        public bool UpdateTeacher(Teacher teacher)
        {
            bool wasUpdate = false;
            Teacher stud = _schoolDbContext.Teacher.SingleOrDefault(teachers => teachers.Id == teachers.Id);
            {
                if (stud == null)
                {
                    stud.Name = teacher.Name;
                    stud.Description = teacher.Description;

                    _schoolDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
