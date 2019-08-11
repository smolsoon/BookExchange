using System;

namespace BookExchange.Infrastructure.Messages 
{
    public partial class Reading 
    {
        public int Id { get; set; }
        public int? BaseId { get; set; }
        public double? Frequency { get; set; }
        public byte? Modulation { get; set; }
        public byte? Agc1 { get; set; }
        public byte? Agc2 { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}