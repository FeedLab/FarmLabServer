using System;

namespace FarmLabService.Model
{
    public class UserInfoXxxx
    {
       // public UserInfoXxxx(UserItemXxxx user)
        //{
        //    UserIdentifier = user.Email;

        //    //if (user.Farms != null)
        //    //{
        //    //    FarmId = user.Farms.Id;
        //    //    FarmName = user.Farms.FarmName;
        //    //    FarmCreated = user.Farms.CreateDate;
        //    //}
        //}

        public string UserIdentifier { get; set; }

        public Guid FarmId { get; set; }

        public string FarmName { get; set; }

        public DateTime FarmCreated { get; set; }
    }
}
