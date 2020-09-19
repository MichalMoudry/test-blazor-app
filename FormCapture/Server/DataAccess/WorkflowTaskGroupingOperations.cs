using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class WorkflowTaskGroupingOperations
    {
        private readonly AppDbContext _appDbContext;

        public WorkflowTaskGroupingOperations(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<WorkflowTaskGrouping> GetWorkflowTaskGroupings(string workflowID) => _appDbContext.TaskGroupings.Where(i => i.WorkflowID.Equals(workflowID)).ToList();

        /// <summary>
        /// Method for adding a new task grouping to db.
        /// </summary>
        /// <param name="taskGroupings">Dictionary of new task groupings.</param>
        /// <returns>True if groupings were added. False if operation failed.</returns>
        public async Task<bool> AddGrouping(Dictionary<string, List<WorkflowTaskGrouping>> taskGroupings)
        {
            try
            {
                foreach (var keyvalue in taskGroupings)
                {
                    foreach (WorkflowTaskGrouping grouping in keyvalue.Value)
                    {
                        grouping.Added = DateTime.Now;
                        grouping.Updated = grouping.Added;
                        _appDbContext.TaskGroupings.Add(grouping);
                    }
                }
                await _appDbContext.SaveChangesAsync();
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
        public async Task<bool> RemoveGrouping(Dictionary<string, List<WorkflowTaskGrouping>> taskGroupings)
        {
            try
            {
                foreach (var keyvalue in taskGroupings)
                {
                    foreach (WorkflowTaskGrouping grouping in keyvalue.Value)
                    {
                        _appDbContext.TaskGroupings.Remove(grouping);
                    }
                }
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