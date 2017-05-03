using System;
using System.Collections.Generic;

namespace ClientApplication.Models
{
    public partial class Client
    {
        public Client()
        {
            this.Contacts = new List<Contact1>();
        }

        public int ID { get; set; }
        public string RegistrationID { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Contact1> Contacts { get; set; }
    }
}
