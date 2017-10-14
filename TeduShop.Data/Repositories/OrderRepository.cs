﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {

    }

    public class OrderRepository : IRepositoryBase<Order>, IOrderRepository
    {
        protected OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
