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

        public DegreeWorks(int correlativeNumber, string title, String creationDate, String modality)
        {
            this.CorrelativeNumber = correlativeNumber;
            this.Title = title;
            this.CreationDate = creationDate;
            this.Modality = modality;
        }

        public DegreeWorks(int correlativeNumber, string title, string observations, string creationDate, string modality, string councilNumber, string idInternTeacher, string idCouncil)
        {
            this.CorrelativeNumber = correlativeNumber;
            this.Title = title;
            this.Observations = observations;
            this.CreationDate = creationDate;
            this.Modality = modality;
            this.CouncilNumber = councilNumber;
            this.IdInternTeacher = idInternTeacher;
            this.IdCouncil = idCouncil;
        }

        public int CorrelativeNumber { get => correlativeNumber; set => correlativeNumber = value; }
        public string Title { get => title; set => title = value; }
        public string Observations { get => observations; set => observations = value; }
        public string CreationDate { get => creationDate; set => creationDate = value; }
        public string Modality { get => modality; set => modality = value; }
        public string CouncilNumber { get => councilNumber; set => councilNumber = value; }
        public string IdInternTeacher { get => idInternTeacher; set => idInternTeacher = value; }
        public string IdCouncil { get => idCouncil; set => idCouncil = value; }
    }
}
