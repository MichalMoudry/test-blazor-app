using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class WorkflowTaskParameterOperations
    {
        private readonly AppDbContext _datacontext;

        public WorkflowTaskParameterOperations(AppDbContext dbContext)
        {
            _datacontext = dbContext;
        }

        public List<WorkflowTaskParameter> GetWorkflowTaskParameters(string taskID) => _datacontext.WorkflowTaskParameters.Where(i => i.TaskID.Equals(taskID)).ToList();

        public async Task<bool> AddParameters(List<WorkflowTaskParameter> parameters)
        {
            try
            {
                _datacontext.WorkflowTaskParameters.AddRange(parameters);
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveParameters(List<WorkflowTaskParameter> parameters)
        {
            try
            {
                _datacontext.WorkflowTaskParameters.RemoveRange(parameters);
                await _datacontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //TODO: Add editing of a range of parameters.
    }
}