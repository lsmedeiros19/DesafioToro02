using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Position
    {
        [Key]
        public int cblc { get; set; }
        public double checkingAccountAmount { get; set; }
        public List<Equity> positions { get; set; }
        public double consolidated { get; set; }
    }
}
