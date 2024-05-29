using Auction.Domain.Enums.UserEnums;
using Auction.Domain.Models.PaymentCards;
using Auction.Domain.Models.UserContacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Contracts.Users
{
    public class UserUpdateDto
    {
        public required string NickName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
