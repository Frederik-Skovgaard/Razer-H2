using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razer_H2.Modul
{
    public class Contact
    {
        public Contact()
        {

        }
        public Contact(int id, string email, int phone, string fName, string mName, string lName)
        {
            Contact_ID = id;
            Email = email;
            Phone = phone;
            FirstName = fName;
            MiddleName = mName;
            LastName = lName;
        }

        public int Contact_ID { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
