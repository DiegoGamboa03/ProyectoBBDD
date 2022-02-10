using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class CriteriaClass
    {
        string criteriaCode;
        string criteriaDesc;
        string criteriaStatus;

        public CriteriaClass(string CriteriaCode, string CriteriaDesc, string CriteriaStatus)
        {
            this.criteriaCode = CriteriaCode;
            this.criteriaDesc = CriteriaDesc;
            this.criteriaStatus = CriteriaStatus;
        }

        public string CriteriaCode { get => criteriaCode; set => criteriaCode = value; }
        public string CriteriaDesc { get => criteriaDesc; set => criteriaDesc = value; }
        public string CriteriaStatus { get => criteriaStatus; set => criteriaStatus = value; }
    }
}
