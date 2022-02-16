using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_base_de_datos.Class
{
    public class Students
    {
        private String id;
        private String name;
        private String personalEmail;
        private String ucabMail;
        private String phoneNumber;
        private String bonusAttribute;
        private bool haveDegreeWork;

        public Students()
        {
        }

        public Students(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Students(string id, string name, string personalEmail, string ucabMail, string phoneNumber, string bonusAttribute, bool haveDegreeWork)
        {
            this.Id = id;
            this.Name = name;
            this.PersonalEmail = personalEmail;
            this.UcabMail = ucabMail;
            this.PhoneNumber = phoneNumber;
            this.BonusAttribute = bonusAttribute;
            this.haveDegreeWork = haveDegreeWork;
        }

        public Students(string id, string name, string ucabEmail)
        {
            this.Id = id;
            this.name = name;
            this.ucabMail = ucabEmail;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string PersonalEmail { get => personalEmail; set => personalEmail = value; }
        public string UcabMail { get => ucabMail; set => ucabMail = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string BonusAttribute
        {
            get => bonusAttribute; set => bonusAttribute = value;
        }
    }
}
