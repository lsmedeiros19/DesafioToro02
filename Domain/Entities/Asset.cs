using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Asset
    {
        /// <summary>
        /// Id do Ativo
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome do Ativo
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Valor do Ativo
        /// </summary>
        public float CurrentPrice { get; set; }

    }
}
