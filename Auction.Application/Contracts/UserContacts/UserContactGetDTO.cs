using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Contracts.UserContacts
{
    public class UserContactGetDTO
    {
        public string? PhoneNumber { get; set; }

        public string? Telegram { get; set; } 

        public string? Instagram { get; set; }

        public string? City { get; set; } 

        public string? Country { get; set; }
    }
}
