﻿using E_Commerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Repositories
{
    //constraint class
    public interface IRepository<T> where T : BaseEntity
    {
       DbSet<T> Table {  get; }
    }
}
