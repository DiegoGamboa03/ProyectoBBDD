using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    public class Teachers
    {
        private string id;
        private string name;
        private string type;
        private string institution;
        private string direction;
        private string phoneNumber;


        public Teachers(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Teachers(string id, string name, string institution)
        {
            this.id = id;
            this.name = name;
            this.institution = institution;
        }

        public Teachers(string id, string name, string direction, string phoneNumber, string institution)
        {
            this.id = id;
            this.name = name;
            this.direction = direction;
            this.phoneNumber = phoneNumber;
            this.institution = institution;
        }

        public Teachers(string id, string name, string type, string institution, string direction, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.institution = institution;
            this.direction = direction;
            this.phoneNumber = phoneNumber;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Direction { get => direction; set => direction = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Institution { get => institution; set => institution = value; }
        public string Type { get => type; set => type = value; }
    }
}
