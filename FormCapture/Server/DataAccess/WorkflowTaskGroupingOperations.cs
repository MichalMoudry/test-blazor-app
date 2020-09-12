using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class WorkflowTaskGroupingOperations
    {
        private readonly AppDbContext _dataContext;

        public WorkflowTaskGroupingOperations(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method for obtaining task groupings for a specific task group.
        /// </summary>
        /// <param name="groupID">ID of the group.</param>
        /// <returns>List of groupings for a specific task group.</returns>
        public List<AppWorkflowTaskGrouping> GetGroupsTaskGroupings(string groupID) => _dataContext.WorkflowTaskGrouping.Where(i => i.AppWorkflowTaskGroupID.Equals(groupID)).ToList();

        /// <summary>
        /// Method for adding a new task grouping to db.
        /// </summary>
        /// <param name="taskGroupings">Dictionary of new task groupings.</param>
        /// <returns>True if groupings were added. False if operation failed.</returns>
        public async Task<bool> AddGrouping(Dictionary<string, List<AppWorkflowTaskGrouping>> taskGroupings)
        {
            try
            {
                foreach (var keyvalue in taskGroupings)
                {
                    foreach (AppWorkflowTaskGrouping grouping in keyvalue.Value)
                    {
                        grouping.Added = DateTime.Now;
                        grouping.Updated = grouping.Added;
                        _dataContext.WorkflowTaskGrouping.Add(grouping);
                    }
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
        /// Method for removing a task grouping from db.
        /// </summary>
        /// <param name="taskGroupings">Dictionary of new task grouping.</param>
        /// <returns>True if groupings were removed. False if operation failed.</returns>
        public async Task<bool> RemoveGrouping(Dictionary<string, List<AppWorkflowTaskGrouping>> taskGroupings)
        {
            try
            {
                foreach (var keyvalue in taskGroupings)
                {
                    foreach (AppWorkflowTaskGrouping grouping in keyvalue.Value)
                    {
                        _dataContext.WorkflowTaskGrouping.Remove(grouping);
                    }
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