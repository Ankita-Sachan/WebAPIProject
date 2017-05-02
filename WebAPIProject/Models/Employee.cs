using System;
using System.Collections.Generic;

namespace WebAPIProject.Models
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}
