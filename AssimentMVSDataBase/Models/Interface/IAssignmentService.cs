using AssimentMVSDataBase.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Interface
{
    public interface IAssignmentService
    {
        Assignment CreateAssignment(Assignment assignment, int courseId);

        List<Assignment> AllAssignment();

        Assignment FindAssignment(int id);

        bool UpdateAssignment(Assignment assignment);

        bool DeleteAssignment(int id);
    }
}
