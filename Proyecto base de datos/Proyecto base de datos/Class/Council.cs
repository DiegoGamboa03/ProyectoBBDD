using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class Council
    {
        String councilID;
        DateTime councilDate;

        public Council(string councilID, DateTime councilDate)
        {
            this.councilID = councilID;
            this.councilDate = councilDate;
        }

        public string CouncilID { get => councilID; set => councilID = value; }
        public DateTime CouncilDate { get => councilDate; set => councilDate = value; }
    }
}
