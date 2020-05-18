﻿using CP.BusinessLayer.Repository.Abstract.Basic;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Repository.Abstract
{
    public interface ICampProductRepository : IRepository<CampProduct>
    {
        List<CampProduct> GetCampProducts();
    }
}
