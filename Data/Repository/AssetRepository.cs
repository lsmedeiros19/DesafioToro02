using Data.Interfaces;
using Domain.Entities;

namespace Data.Repository
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        public AssetRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
