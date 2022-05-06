using PrestoTraxSite.Models;

namespace PrestoTraxSite.Services.Business
{
    public class UserLogic
    {
        public void PopulateUserRecords(UserModel user, List<RecordModel> records)
        {
            user.OwnedDevices ??= new List<int>();
            user.UserRecords ??= new List<RecordModel>();
            
            for(int i = 0; i < records.Count; i++)
            {
                if (!user.OwnedDevices.Contains(records[i].DeviceId))
                {
                    user.OwnedDevices.Add(records[i].DeviceId);
                }
                if(!user.UserRecords.Contains(records[i]))
                {
                    user.UserRecords.Add(records[i]);
                }
            }
            //return user;
        }
    }
}
