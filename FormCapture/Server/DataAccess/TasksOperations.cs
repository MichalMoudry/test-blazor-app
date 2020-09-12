using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class TasksOperations
    {
        private readonly AppDbContext _datacontext;

        /// <summary>
        /// Constructor for TasksOperations class.
        /// </summary>
        /// <param name="dataContext">Data context instance.</param>
        public TasksOperations(AppDbContext dataContext)
        {
            _datacontext = dataContext;
        }

        /// <summary>
        /// Method for obtaining list of user's workflow tasks.
        /// </summary>
        /// <param name="userID">ID of the user.</param>
        /// <returns>List of user's workflow tasks.</returns>
        public List<AppWorkflowTask> GetUserTasks(string userID) => _datacontext.WorkflowTasks.Where(i => i.UserID.Equals(userID)).ToList();

        /// <summary>
        /// Method for obtaining a specific task.
        /// </summary>
        /// <param name="taskID">ID of the task.</param>
        /// <returns>A specific workflow task.</returns>
        public AppWorkflowTask GetSpecificTask(string taskID) => _datacontext.WorkflowTasks.SingleOrDefault(i => i.ID.Equals(taskID));

        /// <summary>
        /// Method for adding a new workflow task to db.
        /// </summary>
        /// <param name="newTask">A new workflow task.</param>
        /// <returns>True if task was added. False if operation failed.</returns>
        public async Task<bool> AddTask(AppWorkflowTask newTask)
        {
            try
            {
                _datacontext.WorkflowTasks.Add(newTask);
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for removing a workflow task from db.
        /// </summary>
        /// <param name="task">Task that will be removed.</param>
        /// <returns>True if task was removed. False if operation failed.</returns>
        public async Task<bool> RemoveTask(AppWorkflowTask task)
        {
            try
            {
                _datacontext.Remove(task);
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for editing an app workflow task.
        /// </summary>
        /// <param name="newTask">New data.</param>
        /// <returns>True if entry was edited. False if operation failed.</returns>
        public async Task<bool> EditTask(AppWorkflowTask newTask)
        {
            try
            {
                //Trying to find original entry.
                AppWorkflowTask origTask = _datacontext.WorkflowTasks.SingleOrDefault(i => i.ID.Equals(newTask.ID));
                if (origTask == null)
                {
                    return false;
                }
                //Setting new values.
                _datacontext.Entry(origTask).CurrentValues.SetValues(newTask);
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