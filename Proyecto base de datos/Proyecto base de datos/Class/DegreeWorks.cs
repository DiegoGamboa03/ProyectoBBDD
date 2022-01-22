using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    public class DegreeWorks
    {
        private int correlativeNumber;
        private String title;
        private String observations;
        private String creationDate;
        private String modality;
        private String councilNumber;
        private String idInternTeacher;
        private String idCouncil;
  
        public DegreeWorks(int correlativeNumber, string title, string observations, string creationDate, string modality, string councilNumber, string idInternTeacher, string idCouncil)
        {
            this.correlativeNumber = correlativeNumber;
            this.title = title;
            this.observations = observations;
            this.creationDate = creationDate;
            this.modality = modality;
            this.councilNumber = councilNumber;
            this.idInternTeacher = idInternTeacher;
            this.idCouncil = idCouncil;
        }
    }
}
