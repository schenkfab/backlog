using System.Threading.Tasks;
using backlog.Entities;

namespace backlog.Repositories
{
    public interface IFollowRepository : IRepository<Follow>
    {
        Task<int> Unfollow(long id);
        Task<int> SyncBoardItems();
    }
}