using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    public class Council
    {
        String councilID;
        DateTime councilDate;
        String stDate;

        public Council(string councilID, DateTime councilDate)
        {
            this.councilID = councilID;
            this.councilDate = councilDate;
            this.stDate = councilDate.ToString("dd-mm-yyyy");
        }

        public string CouncilID { get => councilID; set => councilID = value; }
        public DateTime CouncilDate { get => councilDate; set => councilDate = value; }
        public string StDate { get => stDate; set => stDate = value; }
    }
}
