using Auction.Application.Contracts.UserContacts;
using Auction.Domain.Models.PaymentCards;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Contracts.Users
{
    public class UserResponseDto
    {
        public long Id { get; set; }    
        public required string NickName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public UserContact? Contact { get; set; }
        public UserRole Role { get; set; }
    }
}
