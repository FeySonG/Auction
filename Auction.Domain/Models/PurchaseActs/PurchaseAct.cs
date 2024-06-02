using Auction.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Models.PurchaseActs
{
    public class PurchaseAct : Entity
    {
        public required long LotId { get; set; }

        public required long BuyerId { get; set; }

        public required long SellerId { get; set; }

        public required decimal Price { get; set; }

        public DateTime TransactionDate { get; set; }

        public PurchaseStatus Status { get; set; } = PurchaseStatus.InProgress;
    }
}
