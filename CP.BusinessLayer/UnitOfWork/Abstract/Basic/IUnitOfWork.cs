﻿using CP.BusinessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.UnitOfWork.Abstract.Basic
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}