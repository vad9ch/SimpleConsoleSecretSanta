using System;
using System.Collections.Generic;

namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Gift> Gifts { get; set; }
    }
}
