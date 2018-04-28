using System.Threading.Tasks;

namespace FarmLabService.Services
{
    public interface IUserRepository
    {
        //Task<UserItemXxxx> GetByIdAsync(string id);

        //Task<int> InsertAsync(UserItemXxxx itemXxxx);

        Task<bool> DoesItemExistAsync(string id);

    }
}