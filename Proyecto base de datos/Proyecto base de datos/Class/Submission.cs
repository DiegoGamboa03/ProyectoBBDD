using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class Submission
    {
        private List<Students> studentsIds;
        private int correlativeNumber;

        public Submission(List<Students> studentsIds, int correlativeNumber)
        {
            this.studentsIds = studentsIds;
            this.correlativeNumber = correlativeNumber;
        }

        public List<Students> StudentsIds { get => studentsIds; set => studentsIds = value; }
        public int CorrelativeNumber { get => correlativeNumber; set => correlativeNumber = value; }
    }
}
