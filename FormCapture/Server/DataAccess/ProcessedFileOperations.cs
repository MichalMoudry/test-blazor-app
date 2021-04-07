using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class ProcessedFileOperations
    {
        private readonly AppDbContext _dataContext;

        public ProcessedFileOperations(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method for adding a new entry to db table with processed files.
        /// </summary>
        /// <param name="files">Entry data as a list of instances of ProcessedFile class.</param>
        /// <returns>True if entry was written into db. False if not.</returns>
        public async Task<bool> AddNewFile(List<ProcessedFile> files)
        {
            try
            {
                foreach (ProcessedFile file in files)
                {
                    _dataContext.ProcessedFiles.Add(file);
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
        /// Method for removing an entry from db table with processed files.
        /// </summary>
        /// <param name="queueID">Entries that will be deleted.</param>
        /// <returns>True if entry was removed from db. False if not.</returns>
        public async Task<bool> DeleteFile(string queueID)
        {
            try
            {
                _dataContext.RemoveRange(GetQueueFiles(queueID));
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for obtaining list of files in a specific batch.
        /// </summary>
        /// <param name="queueID">ID of the batch.</param>
        /// <returns>List of files in a specific batch.</returns>
        public List<ProcessedFile> GetQueueFiles(string queueID) => _dataContext.ProcessedFiles.Where(i => i.QueueID.Equals(queueID)).ToList();
    }
}