using System;
using FarmLabService.DataObjects;

namespace FarmLabService.Model
{
    public class UserInfo
    {
        public UserInfo(UserItem user)
        {
            UserIdentifier = user.Email;

            //if (user.Farm != null)
            //{
            //    FarmId = user.Farm.Id;
            //    FarmName = user.Farm.FarmName;
            //    FarmCreated = user.Farm.CreateDate;
            //}
        }

        public string UserIdentifier { get; set; }

        public Guid FarmId { get; set; }

        public string FarmName { get; set; }

        public DateTime FarmCreated { get; set; }
    }
}
