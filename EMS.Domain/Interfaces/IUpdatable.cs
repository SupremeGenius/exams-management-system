using System.Threading.Tasks;

namespace EMS.Domain
{
    public interface IUpdatable<TEntity>
    {
        void Update(TEntity updatedEntity);
    }
}
