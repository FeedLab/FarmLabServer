using System.Collections.Generic;
using FarmLabService.DataObjects;

namespace FarmLabService.Services
{
    public interface IUserRepository
    {
        IEnumerable<UserItem> All { get; }

        void Insert(UserItem item);

        bool DoesItemExist(string id);

    }
}