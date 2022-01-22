using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    public class ExperimentalDegreeWork : DegreeWorks
    {
        private String endorsedTeacher;

        public ExperimentalDegreeWork(int correlativeNumber, string title, string observations, string creationDate, string councilNumber, string idInternTeacher, string idCouncil, String endorsedTeacher) : base(correlativeNumber,title,observations,creationDate,"Experimental",councilNumber,idInternTeacher,idCouncil)
        {
            this.endorsedTeacher = endorsedTeacher;
        }

        public string EndorsedTeacher { get => endorsedTeacher; set => endorsedTeacher = value; }
    }
}
