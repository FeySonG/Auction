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
        public  string PhoneNumber { get; set; } = "string";

        public string? Telegram { get; set; } = "string";

        public string? Instagram { get; set; } = "string";

        public string? City { get; set; } = "string";

        public string? Country { get; set; } = "string";
    }
}
