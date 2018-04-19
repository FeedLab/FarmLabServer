using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmLabService.Dal;
using FarmLabService.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace FarmLabService.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly FarmLabContext _context;

        public UserRepository(FarmLabContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> InsertAsync(UserItem item)
        {
            if (await DoesItemExistAsync(item.Email) == false)
            {
                _context.Users.Add(item);
                return await _context.SaveChangesAsync();
            }

            return -1;
        }

        public async Task<UserItem> GetByIdAsync(string id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(s => s.Email == id);
        }

        public async Task<bool> DoesItemExistAsync(string id)
        {
            return await _context.Users.AsNoTracking().AnyAsync(item => item.Email == id);
        }
    }
}
