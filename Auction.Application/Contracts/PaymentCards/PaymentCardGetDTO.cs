using Auction.Domain.Models.PaymentCards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Application.Contracts.PaymentCards
{
    public class PaymentCardGetDTO
    {

        public string CardNumber { get; set; } = string.Empty;
    
        public string ExpiryDate { get; set; } = string.Empty;

        public PaymentCardType CardType { get; set; }

    }
}
