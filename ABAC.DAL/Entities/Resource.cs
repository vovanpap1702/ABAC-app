using System.Collections.Generic;

namespace ABAC.DAL.Entities
{
    public class Resource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public IDictionary<string, string> Attributes { get; set; }
    }
}