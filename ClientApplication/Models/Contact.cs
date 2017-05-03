using System;
using System.Collections.Generic;

namespace ClientApplication.Models
{
    public partial class Contact
    {
        public int ContactID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> Age { get; set; }
    }
}
