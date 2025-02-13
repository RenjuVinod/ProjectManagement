﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Entities
{
    public class User : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual IEnumerable<Tasks> Tasks { get; set; }
    }
}
