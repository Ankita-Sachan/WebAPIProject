using System;
using System.Collections.Generic;

namespace ClientApplication.Models
{
    public partial class Contact1
    {
        public int ContactID { get; set; }
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Phoneno { get; set; }
        public int Age { get; set; }
        public virtual Client Client { get; set; }
    }
}
