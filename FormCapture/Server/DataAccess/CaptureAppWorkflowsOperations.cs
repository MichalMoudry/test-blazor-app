using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Method for adding a new row to CaptureAppWorkflows table.
        /// </summary>
        /// <param name="captureAppWorkflows">List of new rows that will be added.</param>
        /// <returns>True if row was added. False if not.</returns>
        public async Task<bool> AddCaptureAppWorkflow(List<CaptureAppWorkflows> captureAppWorkflows)
        {
            try
            {
                foreach (var captureAppWorkflow in captureAppWorkflows)
                {
                    if (!_datacontext.AppWorkflows.Contains(captureAppWorkflow))
                    {
                        _datacontext.AppWorkflows.Add(captureAppWorkflow);
                    }
                }
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for obtaining list of CaptureAppWorkflow instances.
        /// </summary>
        /// <param name="appID">ID of a capture app.</param>
        /// <returns>List of CaptureAppWorkflow instances</returns>
        public List<CaptureAppWorkflows> GetCaptureAppWorkflows(string appID) => _datacontext.AppWorkflows.Where(i => i.AppID.Equals(appID)).ToList();

        /// <summary>
        /// Method for removing a row in CaptureAppWorkflows table.
        /// </summary>
        /// <param name="captureAppWorkflows">List of rows that will be removed.</param>
        /// <returns>True if row was removed. False if not.</returns>
        public async Task<bool> RemoveCaptureAppWorkflow(List<CaptureAppWorkflows> captureAppWorkflows)
        {
            try
            {
                _datacontext.AppWorkflows.RemoveRange(captureAppWorkflows);
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}