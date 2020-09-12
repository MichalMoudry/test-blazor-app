using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class BatchOperations
    {
        private readonly AppDbContext _dataContext;

        public BatchOperations(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method for obtaining list of user's batches.
        /// </summary>
        /// <param name="userID">ID of a specific user.</param>
        /// <returns>List of user's batches.</returns>
        public List<Batch> GetUsersBatches(string userID) => _dataContext.Batches.Where(i => i.UserID.Equals(userID)).ToList();

        /// <summary>
        /// Method for obtaining list of app's batches.
        /// </summary>
        /// <param name="appID">ID of a specific app.</param>
        /// <returns>List of app's batches.</returns>
        public List<Batch> GetAppsBatches(string appID) => _dataContext.Batches.Where(i => i.AppID.Equals(appID)).ToList();

        /// <summary>
        /// Method for obtaining a specific batch.
        /// </summary>
        /// <param name="batchID">ID of the batch.</param>
        /// <returns>Specific batch.</returns>
        public Batch GetBatch(string batchID) => _dataContext.Batches.SingleOrDefault(i => i.ID.Equals(batchID));

        /// <summary>
        /// Method for adding a new entry to db table with batches.
        /// </summary>
        /// <param name="application">Entry data as a instance of Batch class.</param>
        /// <returns>True if entry was written into db. False if not.</returns>
        public async Task<bool> AddNewBatch(Batch batch)
        {
            try
            {
                _dataContext.Batches.Add(batch);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for deleting a batch and associated entries from db.
        /// </summary>
        /// <param name="app">Batch that will be deleted.</param>
        /// <returns>True if batch were delete. False if not.</returns>
        public async Task<bool> DeleteBatch(Batch batch)
        {
            try
            {
                _dataContext.Batches.Remove(batch);
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