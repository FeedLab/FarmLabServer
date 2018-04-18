using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmLabService.Dal;
using FarmLabService.DataObjects;

namespace FarmLabService.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly FarmLabContext _context;
        private readonly List<UserItem> _list = new List<UserItem>();

        public UserRepository(FarmLabContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Insert(UserItem item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<UserItem> All
        {
            get { return _context.Users; }
        }

        public bool DoesItemExist(string id)
        {
            return _context.Users.Any(item => item.Email == id);
        }
    }
}
