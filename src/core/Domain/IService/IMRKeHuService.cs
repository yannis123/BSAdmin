﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IMRKeHuService
    {
        List<MRKeHu> GetKeHuList();
    }
}
