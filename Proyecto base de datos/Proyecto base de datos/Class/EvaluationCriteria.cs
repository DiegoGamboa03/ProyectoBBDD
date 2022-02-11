using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class EvaluationCriteria
    {
        string id;
        string description;
        int topNote;
        string status;

        public EvaluationCriteria(string id, string description, int topNote, string status)
        {
            this.id = id;
            this.description = description;
            this.topNote = topNote;
            this.status = status;
        }

        public string Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public int TopNote { get => topNote; set => topNote = value; }
        public string Status { get => status; set => status = value; }
    }
}
