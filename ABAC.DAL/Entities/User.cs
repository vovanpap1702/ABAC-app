using System.Collections.Generic;

namespace ABAC.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Attribute> Attributes { get; set; }
    }
}
