using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models.UserContacts
{
    public interface IUserContactRepository : IRepository<UserContact>
    {
    }
}
