using System;
using System.Threading.Tasks;
using FarmLabService.Dal;
using FarmLabService.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace FarmLabService.Services
{
    public class UserRepository //: IUserRepository
    {
        private readonly FarmLabContext _context;

        public UserRepository(FarmLabContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<SessionItem> CreateSessionAndAssociateUserAsync(UserItem item)
        {
            var userItem = await GetByIdAsync(item.Email) ?? await CreatetUserAsync(item);

            var session = new SessionItem
            {
                IsValid = true,
                Id = 0,
                LastActivity = DateTime.UtcNow,
                SessionKey = Guid.NewGuid(),
                User = userItem
            };

            await _context.Session.AddAsync(session);
            await _context.SaveChangesAsync();

            return session;
        }

        public async Task<UserItem> GetUserAsync(UserItem item)
        {
            var userItem = await GetByIdAsync(item.Email);

            if (userItem == null)
            {
                return await CreatetUserAsync(item);
            }

            return userItem;
        }

        public async Task<UserItem> CreatetUserAsync(UserItem item)
        {
            await _context.User.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        //public async Task<int> InsertAsync(UserItemXxxx itemXxxx)
        //{
        //    if (await DoesItemExistAsync(itemXxxx.Email) == false)
        //    {
        //        _context.Users.Add(itemXxxx);
        //        return await _context.SaveChangesAsync();
        //    }

        //    return -1;
        //}

        public async Task<UserItem> GetByIdAsync(string id)
        {
            return await _context.User.AsNoTracking().SingleOrDefaultAsync(s => s.Email == id);
        }

        //public async Task<bool> DoesItemExistAsync(string id)
        //{
        //    return await _context.Users.AsNoTracking().AnyAsync(item => item.Email == id);
        //}
    }
}
