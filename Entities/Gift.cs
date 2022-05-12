using System;
using System.Collections.Generic;

namespace Entities
{
    public class Gift
    {
        public Guid Id { get; set; }
        public ICollection<User> Users { get; set; } // first user is those who sends gift, and second is the receiver
    }
}
