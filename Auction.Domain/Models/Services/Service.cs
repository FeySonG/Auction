﻿using Auction.Domain.Abstractions;
using Auction.Domain.Models.UserContacts;
using Auction.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models.Services
{
    public class Service : Entity
    {

        public required long UserId { get; set; }

        public required string ServiceName { get; set; }

        public required string Description { get; set; }

        public decimal Price { get; set; }

        public ServiceCategory? Category { get; set; }
       
        public DateTime DateAdded { get; set; }
    }
}
