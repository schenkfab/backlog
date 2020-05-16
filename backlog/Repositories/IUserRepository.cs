using System.Threading.Tasks;
using backlog.Entities;

namespace backlog.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserBySub(string sub, bool isTracking = false);
        Task<BoardItem> UpdateBoardItemStatus(long itemId, int statusId);
        Task<bool> UserSubExists(string sub, bool isTracking = false);
    }
}