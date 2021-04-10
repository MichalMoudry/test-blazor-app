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
                    keyvalue.Value.ForEach(i => i.Added = DateTime.Now);
                    keyvalue.Value.ForEach(i => i.Updated = i.Added);
                    _appDbContext.TaskGroupings.AddRange(keyvalue.Value);
                }
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<WorkflowTaskGrouping> GetWorkflowTaskGroupings(string workflowID) => _appDbContext.TaskGroupings.Where(i => i.WorkflowID.Equals(workflowID)).ToList();

        /// <summary>
        /// Method for removing a task grouping from db.
        /// </summary>
        /// <param name="taskID">ID of the task.</param>
        /// <returns>True if groupings were removed. False if operation failed.</returns>
        public async Task<bool> RemoveGrouping(string taskID)
        {
            try
            {
                _appDbContext.TaskGroupings.RemoveRange(_appDbContext.TaskGroupings.Where(i => i.TaskID.Equals(taskID)));
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