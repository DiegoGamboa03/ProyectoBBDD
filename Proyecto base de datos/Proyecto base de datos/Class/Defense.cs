using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class Defense
    {
        private String idStudent;
        private String defenseCode;
        private String finalNote;
        private DateTime presentationDate; //Aqui se guarda la fecha y hora de la presentacion

        public Defense(string idStudent, string defenseCode, string finalNote, DateTime presentationDate)
        {
            this.idStudent = idStudent;
            this.defenseCode = defenseCode;
            this.finalNote = finalNote;
            this.presentationDate = presentationDate;
        }

        public string IdStudent { get => idStudent; set => idStudent = value; }
        public string DefenseCode { get => defenseCode; set => defenseCode = value; }
        public string FinalNote { get => finalNote; set => finalNote = value; }
        public DateTime PresentationDate { get => presentationDate; set => presentationDate = value; }
    }
}
