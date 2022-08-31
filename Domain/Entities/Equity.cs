using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Equity
    {
        /// <summary>
        /// Código do Ativo
        /// </summary>
        [Key]
        public string symbol { get; set; }
        /// <summary>
        /// Quantidade da Ativo
        /// </summary>
     
        public int amount { get; set; }

        /// <summary>
        /// Valor do Ativo
        /// </summary>
        public double currentPrice { get; set; }
    }
}
