using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSDataBase.Database;
using AssimentMVSDataBase.Models.Class;
using Microsoft.EntityFrameworkCore;

namespace AssimentMVSDataBase.Models.Interface
{
    public class AssignmentService : IAssignmentService
    {
        readonly SchoolDbContext _schoolDbContext;

        public AssignmentService(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public List<Assignment> AllAssignment()
        {
            return _schoolDbContext.Assignments.ToList();
        }

        public Assignment CreateAssignment(string title, string description)
        {
            Assignment assignment = new Assignment()
            {
                Title = title,
                Description = description
            };

            _schoolDbContext.Assignments.Add(assignment);
            _schoolDbContext.SaveChanges();
            return assignment;
        }

        public bool DeleteAssignment(int id)
        {
            bool wasRemoved = false;

            Assignment assignment = _schoolDbContext.Assignments.SingleOrDefault(gg => gg.AssignmentId == id);//Najti i ydalit

            if (assignment == null)
            {
                return wasRemoved;
            }

            _schoolDbContext.Assignments.Remove(assignment);
            _schoolDbContext.SaveChanges();

            return wasRemoved;
        }

        public Assignment FindAssignment(int id)
        {
            return _schoolDbContext.Assignments.SingleOrDefault(dd => dd.AssignmentId == id);
        }

        public bool UpdateAssignment(Assignment assignment)
        {
            bool wasUpdate = false;

            Assignment qqq = _schoolDbContext.Assignments.SingleOrDefault(yy => yy.AssignmentId == assignment.AssignmentId);//Najti i ydalit

            if (qqq != null)
            {
                return wasUpdate;
            }

            _schoolDbContext.Assignments.Remove(qqq);
            _schoolDbContext.SaveChanges();

            return wasUpdate;
        }

    }
}
