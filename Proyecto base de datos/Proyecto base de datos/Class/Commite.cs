using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class Commite
    {
        String commiteID;
        DateTime commiteDate;

        public Commite(string commiteID, DateTime commiteDate)
        {
            this.commiteID = commiteID;
            this.commiteDate = commiteDate;
        }

        public string CommiteID { get => commiteID; set => commiteID = value; }
        public DateTime CommiteDate { get => commiteDate; set => commiteDate = value; }
    }
}
