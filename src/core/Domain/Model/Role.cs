﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Model
{
   public  class Role
    {
       public Guid Id { get; set; }
       public string RoleName { get; set; }
       public DateTime CreateTime { get; set; }
    }
}
