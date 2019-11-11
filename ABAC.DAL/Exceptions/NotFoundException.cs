using System;

namespace ABAC.DAL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Requested entity not found.")
        {

        }
    }
}
