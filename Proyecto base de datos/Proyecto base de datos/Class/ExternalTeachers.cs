using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    class ExternalTeachers : Teachers
    {
        public ExternalTeachers(string id, string name, string direction, string phoneNumber, string institution) : base(id, name, direction, phoneNumber, institution)
        {
        }
    }
}
