using Data.Interfaces;

namespace Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DatabaseContext dbConn;

        protected BaseRepository(DatabaseContext context)
        {
            dbConn = context;
        }


        /// <summary>
        /// Obter item do repositorio pelo identificador
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns>Retorna um item do repositorio pelo identificador</returns>
        public async Task<T> GetByIdAsync(long id) => await dbConn.FindAsync<T>(id);

        /// <summary>
        /// Inserir um item no repositório
        /// </summary>
        /// <param name="entity">Entidade do repositório</param>
        /// <returns>Retorna uma nova entidade</returns>
        public async Task<bool> InsertAsync(T entity)
        {
            await dbConn.AddAsync(entity);
            var result = await dbConn.SaveChangesAsync();

            if (result == 1)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Atualizar um item do repositório
        /// </summary>
        /// <param name="entity">Entidade do repositório</param>
        /// <returns>Retorna uma entidade atualizada</returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            dbConn.Update(entity);
            var result = await dbConn.SaveChangesAsync();

            if (result == 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deletar um item do repositório
        /// </summary>
        /// <param name="id">Chave de identificação da entidade</param>
        /// <returns>Retorna uma entidade atualizada</returns>
        public async Task<bool> DeleteAsync(T entity)
        {
            dbConn.Remove(entity);
            var result = await dbConn.SaveChangesAsync();

            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
