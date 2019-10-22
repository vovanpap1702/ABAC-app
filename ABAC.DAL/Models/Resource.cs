namespace ABAC.DAL.Models
{
    using System.Collections.Generic;

    public class Resource
    {
        public string ResourceId { get; set; }

        public string Name { get; set; }

        public List<Attribute> Attributes { get; set; }
    }
}