using Auction.Application.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Services
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
    }
}
