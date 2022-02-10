using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    public class Commite
    {
        String commiteID;
        DateTime commiteDate;
        String stDate;

        public Commite(string commiteID, DateTime commiteDate)
        {
            this.commiteID = commiteID;
            this.commiteDate = commiteDate;
            this.stDate = commiteDate.ToString("dd-MM-yyyy");
        }

        public string CommiteID { get => commiteID; set => commiteID = value; }
        public DateTime CommiteDate { get => commiteDate; set => commiteDate = value; }
        public string StDate { get => stDate; set => stDate = value; }
    }
}
