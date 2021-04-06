using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class UserAppsOperations
    {
        private readonly AppDbContext _appDbContext;

        public UserAppsOperations(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<bool> AddUserApps(List<UserApps> userApps)
        {
            try
            {
                if (userApps == null)
                {
                    return false;
                }
                if (userApps.Count <= 0)
                {
                    return false;
                }
                _appDbContext.UserApps.AddRange(userApps);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<UserApps> GetAppUserIDs(string appID) => _appDbContext.UserApps.Where(i => i.ApplicationID.Equals(appID)).ToList();

        public List<UserApps> GetUserAppIDs(string userID) => _appDbContext.UserApps.Where(i => i.UserID.Equals(userID)).ToList();

        public async Task<bool> RemoveUserApps(List<UserApps> userApps)
        {
            try
            {
                if (userApps == null)
                {
                    return false;
                }
                if (userApps.Count <= 0)
                {
                    return false;
                }
                _appDbContext.UserApps.RemoveRange(userApps);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}