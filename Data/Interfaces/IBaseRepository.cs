namespace Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Obter item do repositorio pelo identificador
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns>Retorna um item do repositorio pelo identificador</returns>
        Task<T> GetByIdAsync(long id);

        ///// <summary>
        ///// Inserir um item no repositório
        ///// </summary>
        ///// <param name="entity">Entidade do repositório</param>
        ///// <returns>Retorna true se obteve sucesso na operação e false se não.</returns>
        Task<bool> InsertAsync(T entity);

        ///// <summary>
        ///// Atualizar um item do repositório
        ///// </summary>
        ///// <param name="entity">Entidade do repositório</param>
        ///// <returns>Retorna uma entidade atualizada</returns>
        Task<bool> UpdateAsync(T entity);

        ///// <summary>
        ///// Deletar um item do repositório
        ///// </summary>
        ///// <param name="entity">Entidade do repositório</param>
        ///// <returns>Retorna true se obteve sucesso na operação e false se não.</returns>
        Task<bool> DeleteAsync(T entity);
    }
}
