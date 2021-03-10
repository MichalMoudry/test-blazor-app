using FormCapture.Shared.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class WorkflowOperations
    {
        private readonly AppDbContext _dataContext;

        public WorkflowOperations(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method for adding a new workflow to db.
        /// </summary>
        /// <param name="appID">New app workflow.</param>
        /// <returns>True if entry was added. False if not.</returns>
        public async Task<bool> AddWorkflow(Workflow workflow)
        {
            try
            {
                _dataContext.Workflows.Add(workflow);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for deleting an app workflow from db.
        /// </summary>
        /// <param name="appID">An app workflow.</param>
        /// <returns>True if entry was deleted. False if not.</returns>
        public async Task<bool> DeleteWorkflow(Workflow workflow)
        {
            try
            {
                _dataContext.Workflows.Remove(workflow);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for updating an app workflow in db.
        /// </summary>
        /// <param name="appID">An app workflow.</param>
        /// <returns>True if entry was edited. False if not.</returns>
        public async Task<bool> EditWorkflow(Workflow newWorkflow)
        {
            try
            {
                var origWorkflow = _dataContext.Workflows.SingleOrDefault(i => i.ID.Equals(newWorkflow.ID));
                if (origWorkflow == null)
                {
                    return false;
                }
                _dataContext.Entry(origWorkflow).CurrentValues.SetValues(newWorkflow);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for obtaining a single instance of AppWorkflow class.
        /// </summary>
        /// <param name="workflowID">ID of the workflow.</param>
        /// <returns>A single instance of AppWorkflow class.</returns>
        public Workflow GetAppWorkflow(string workflowID) => _dataContext.Workflows.SingleOrDefault(i => i.ID.Equals(workflowID));

        /// <summary>
        /// Method for obtaining list of user's workflows.
        /// </summary>
        /// <param name="userID">ID of the user.</param>
        /// <returns>List of user's workflows.</returns>
        public List<Workflow> GetUsersAppWorkflows(string userID) => _dataContext.Workflows.Where(i => i.UserID.Equals(userID)).ToList();
    }
}