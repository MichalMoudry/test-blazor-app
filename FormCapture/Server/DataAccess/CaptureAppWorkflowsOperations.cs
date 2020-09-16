using FormCapture.Shared.DbModels;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class CaptureAppWorkflowsOperations
    {
        private readonly AppDbContext _datacontext;

        public CaptureAppWorkflowsOperations(AppDbContext dataContext)
        {
            _datacontext = dataContext;
        }

        /// <summary>
        /// Method for obtaining list of CaptureAppWorkflow instances.
        /// </summary>
        /// <param name="appID">ID of a capture app.</param>
        /// <returns>List of CaptureAppWorkflow instances</returns>
        public List<CaptureAppWorkflows> GetCaptureAppWorkflows(string appID) => _datacontext.AppWorkflows.Where(i => i.AppID.Equals(appID)).ToList();

        /// <summary>
        /// Method for adding a new row to CaptureAppWorkflows table.
        /// </summary>
        /// <param name="captureAppWorkflows">New row that will be added.</param>
        /// <returns>True if row was added. False if not.</returns>
        public async Task<bool> AddCaptureAppWorkflows(CaptureAppWorkflows captureAppWorkflows)
        {
            try
            {
                _datacontext.AppWorkflows.Add(captureAppWorkflows);
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}