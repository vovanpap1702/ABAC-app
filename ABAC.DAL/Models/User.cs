using System;

namespace ABAC.DAL.Models
{
    using System.Collections.Generic;

    public class User
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Attribute> Attributes { get; set; }

    }
}
