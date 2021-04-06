using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class QueueOperations
    {
        private readonly AppDbContext _dataContext;

        public QueueOperations(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method for add a new entry to db table with queues.
        /// </summary>
        /// <param name="queue">A new entry.</param>
        /// <returns>True if entry was added to db. False if not.</returns>
        public async Task<bool> AddQueue(Queue queue)
        {
            try
            {
                if (queue == null)
                {
                    return false;
                }
                _dataContext.Queue.Add(queue);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for deleting an entry from db with queues.
        /// </summary>
        /// <param name="queue">An entry that will be deleted.</param>
        /// <returns>True if the entry was deleted. False if not.</returns>
        public async Task<bool> DeleteQueue(Queue queue)
        {
            try
            {
                if (queue == null)
                {
                    return false;
                }
                _dataContext.Queue.Remove(queue);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditQueue(Queue newQueue)
        {
            try
            {
                var originalQueue = _dataContext.Queue.SingleOrDefault(i => i.ID.Equals(newQueue.ID));
                if (originalQueue == null)
                {
                    return false;
                }
                _dataContext.Entry(originalQueue).CurrentValues.SetValues(newQueue);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for obtaining list app's queues.
        /// </summary>
        /// <param name="appID">ID of the specific queue.</param>
        /// <returns>List app's queues.</returns>
        public List<Queue> GetAppsQueues(string appID) => _dataContext.Queue.Where(i => i.AppID.Equals(appID)).ToList();

        /// <summary>
        /// Method for obtaining a specific queue.
        /// </summary>
        /// <param name="queueID">ID of the specific queue.</param>
        /// <returns>A specific queue.</returns>
        public Queue GetQueue(string queueID) => _dataContext.Queue.SingleOrDefault(i => i.ID.Equals(queueID));
    }
}