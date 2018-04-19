using System.Threading.Tasks;
using FarmLabService.DataObjects;

namespace FarmLabService.Services
{
    public interface IUserRepository
    {
        Task<UserItem> GetByIdAsync(string id);

        Task<int> InsertAsync(UserItem item);

        Task<bool> DoesItemExistAsync(string id);

    }
}