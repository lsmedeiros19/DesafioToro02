namespace Domain.Entities
{
    public class User
    {
        /// <summary>
        /// Id do Cliente
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Código CBLC do Cliente
        /// </summary>
        public long CBLC { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CPF / CNPJ do Cliente
        /// </summary>
        public long CpfCnpj { get; set; }

        /// <summary>
        /// Saldo do Cliente
        /// </summary>
        public double checkingAccountAmount { get; set; }

        /// <summary>
        /// Valor Consolidado
        /// </summary>
        public double Consolidated { get; set; }

        /// <summary>
        /// Lista de Posição do Cliente
        /// </summary>
        public List<Position> Positions { get; set; }
    }
}