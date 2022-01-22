using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class InstrumentalDegreeWork : DegreeWorks
    {
        private String companyId;
        private String businessTutor;

        public InstrumentalDegreeWork(int correlativeNumber, string title, string observations, string creationDate, string councilNumber, string idInternTeacher, string idCouncil, string companyId, string businessTutor) : base(correlativeNumber, title, observations, creationDate, "Instrumental", councilNumber, idInternTeacher, idCouncil)
        {
            this.companyId = companyId;
            this.businessTutor = businessTutor;
        }

    }
}
