﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSDataBase.Models.Class;

namespace AssimentMVSDataBase.Models.Interface
{
    public class AssignmentService : IAssignmentService
    {
        public List<Assignment> AllAssignment()
        {
            throw new NotImplementedException();
        }

        public Assignment CreateAssignment(string name, int price, string details)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAssignment(int id)
        {
            throw new NotImplementedException();
        }

        public Assignment FindAssignment(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAssignment(Assignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}
