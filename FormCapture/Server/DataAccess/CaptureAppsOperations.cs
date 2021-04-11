using FormCapture.Shared.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class CaptureApplicationsOps
    {
        private readonly AppDbContext _dataContext;

        public CaptureApplicationsOps(AppDbContext context)
        {
            _dataContext = context;
        }

        /// <summary>
        /// Method for adding a new entry to db table with capture applications.
        /// </summary>
        /// <param name="application">Entry data as a instance of CaptureApplication class.</param>
        /// <returns>True if entry was written into db. False if not.</returns>
        public async Task<bool> AddNewApplication(CaptureApplication application)
        {
            try
            {
                _dataContext.CaptureApplications.Add(application);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for deleting a capture app and associated entries from db.
        /// </summary>
        /// <param name="app">Capture app that will be deleted.</param>
        /// <returns>True if entries were delete. False if not.</returns>
        public async Task<bool> DeleteApp(CaptureApplication app)
        {
            try
            {
                _dataContext.CaptureApplications.Remove(app);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for editing already exiting capture app.
        /// </summary>
        /// <param name="newApp">Instance of a CaptureApp class with new data.</param>
        /// <returns>True if app was edited. False if not.</returns>
        public async Task<bool> EditApplication(CaptureApplication newApp)
        {
            try
            {
                var origApp = _dataContext.CaptureApplications.SingleOrDefault(i => i.ID.Equals(newApp.ID));
                if (origApp == null)
                {
                    return false;
                }
                _dataContext.Entry(origApp).CurrentValues.SetValues(newApp);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for obtaining single instance of CaptureApplication class.
        /// </summary>
        /// <param name="appID">ID of wanted app.</param>
        /// <returns>Single instance of CaptureApplication class or null.</returns>
        public CaptureApplication GetCaptureApplication(string appID) => _dataContext.CaptureApplications.SingleOrDefault(i => i.ID.Equals(appID));

        /// <summary>
        /// Method for obtaining list of user's applications where they are a admin.
        /// </summary>
        /// <param name="userID">ID of a specific user.</param>
        /// <returns>List of user's applications where they are a admin.</returns>
        public List<CaptureApplication> GetUsersCaptureApplications(string userID) => _dataContext.CaptureApplications.Where(i => i.UserID.Equals(userID)).ToList();
    }
}