using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht {
    // Klasse Bid aangemaakt op de database
    internal class Bid {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int UserId { get; set; }
        public decimal BidOnShoe { get; set; }
    }
}
