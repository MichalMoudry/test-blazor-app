using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class WorkflowGroupOperations
    {
        private readonly AppDbContext _dataContext;

        /// <summary>
        /// Constructor for WorkflowGroupOperations class.
        /// </summary>
        /// <param name="dataContext">Data context instance.</param>
        public WorkflowGroupOperations(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method for obtaining list of groups in a workflow.
        /// </summary>
        /// <param name="workflowID">ID of the workflow.</param>
        /// <returns>List of groups in a workflow.</returns>
        public List<AppWorkflowGroup> GetWorkflowGroups(string workflowID) => _dataContext.WorkflowGroups.Where(i => i.AppWorkflowID.Equals(workflowID)).ToList();

        /// <summary>
        /// Method for adding a new workflow group to db.
        /// </summary>
        /// <param name="groups">List of new workflow groups.</param>
        /// <returns>True if groups were added. False if operation failed.</returns>
        public async Task<bool> AddGroup(List<AppWorkflowGroup> groups)
        {
            try
            {
                foreach (AppWorkflowGroup group in groups)
                {
                    _dataContext.WorkflowGroups.Add(group);
                }
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for removing a workflow group from db.
        /// </summary>
        /// <param name="groups">List of workflow groups.</param>
        /// <returns>True if groups were removed. False if operation failed.</returns>
        public async Task<bool> RemoveGroup(List<AppWorkflowGroup> groups)
        {
            try
            {
                foreach (AppWorkflowGroup group in groups)
                {
                    _dataContext.WorkflowGroups.Remove(group);
                }
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for editing an already existing workflow group.
        /// </summary>
        /// <param name="newGroups">New data.</param>
        /// <returns>True if entry was edited. False if not.</returns>
        public async Task<bool> EditGroup(List<AppWorkflowGroup> newGroups)
        {
            try
            {
                AppWorkflowGroup origGroup;
                foreach (AppWorkflowGroup newGroup in newGroups)
                {
                    origGroup = _dataContext.WorkflowGroups.SingleOrDefault(i => i.ID.Equals(newGroup.ID));
                    if (origGroup == null)
                    {
                        return false;
                    }
                    _dataContext.Entry(origGroup).CurrentValues.SetValues(newGroup);
                }
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}