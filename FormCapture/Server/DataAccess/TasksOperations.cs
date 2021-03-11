using FormCapture.Shared.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// Method for adding a new workflow task to db.
        /// </summary>
        /// <param name="newTask">A new workflow task.</param>
        /// <returns>True if task was added. False if operation failed.</returns>
        public async Task<bool> AddTask(WorkflowTask newTask)
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
        /// Method for editing an app workflow task.
        /// </summary>
        /// <param name="newTask">New data.</param>
        /// <returns>True if entry was edited. False if operation failed.</returns>
        public async Task<bool> EditTask(WorkflowTask newTask)
        {
            try
            {
                //Trying to find original entry.
                var origTask = _datacontext.WorkflowTasks.SingleOrDefault(i => i.ID.Equals(newTask.ID));
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

        /// <summary>
        /// Method for obtaining a specific task.
        /// </summary>
        /// <param name="taskID">ID of the task.</param>
        /// <returns>A specific workflow task.</returns>
        public WorkflowTask GetSpecificTask(string taskID) => _datacontext.WorkflowTasks.SingleOrDefault(i => i.ID.Equals(taskID));

        /// <summary>
        /// Method for obtaining a list of task specified in a list of task groupings.
        /// </summary>
        /// <param name="groupings">List of task groupings.</param>
        /// <returns>A list of task specified in a list of task groupings.</returns>
        public List<WorkflowTask> GetTasksFromGrouping(List<WorkflowTaskGrouping> groupings)
        {
            var tasks = new List<WorkflowTask>();
            WorkflowTask task;
            foreach (var grouping in groupings)
            {
                task = _datacontext.WorkflowTasks.SingleOrDefault(i => i.ID.Equals(grouping.TaskID));
                if (task != null && !tasks.Contains(task))
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }

        /// <summary>
        /// Method for obtaining list of user's workflow tasks.
        /// </summary>
        /// <param name="userID">ID of the user.</param>
        /// <returns>List of user's workflow tasks.</returns>
        public List<WorkflowTask> GetUserTasks(string userID) => _datacontext.WorkflowTasks.Where(i => i.UserID.Equals(userID)).ToList();

        /// <summary>
        /// Method for removing a workflow task from db.
        /// </summary>
        /// <param name="task">Task that will be removed.</param>
        /// <returns>True if task was removed. False if operation failed.</returns>
        public async Task<bool> RemoveTask(WorkflowTask task)
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
    }
}