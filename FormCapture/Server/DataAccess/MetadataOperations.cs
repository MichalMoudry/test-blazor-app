using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class MetadataOperations
    {
        private readonly AppDbContext _dataContext;

        public MetadataOperations(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method for obtaining list of entity's metadata.
        /// </summary>
        /// <param name="appID">ID of a specific entity.</param>
        /// <returns>List of entity's metadata.</returns>
        public List<Metadata> GetEntitysMetadata(string entityID) => _dataContext.Metadata.Where(i => i.EntityID.Equals(entityID)).ToList();

        /// <summary>
        /// Method for adding new metadata to db.
        /// </summary>
        /// <param name="metadata">A new metadata entry.</param>
        /// <returns>True if entry was added. False if operation failed.</returns>
        public async Task<bool> AddMetadata(Metadata metadata)
        {
            try
            {
                _dataContext.Metadata.Add(metadata);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for removing metadata entry from db.
        /// </summary>
        /// <param name="metadata">A metadata entry.</param>
        /// <returns>True if entry was removed. False if operation failed.</returns>
        public async Task<bool> RemoveMetadata(Metadata metadata)
        {
            try
            {
                _dataContext.Metadata.Remove(metadata);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method for editing a metadata entry in db.
        /// </summary>
        /// <param name="metadata">A metadata entry.</param>
        /// <returns>True if entry was edited. False if operation failed.</returns>
        public async Task<bool> EditMetadata(Metadata newMetadata)
        {
            try
            {
                Metadata origMetadata = _dataContext.Metadata.SingleOrDefault(i => i.ID.Equals(newMetadata.ID));
                if (origMetadata == null)
                {
                    return false;
                }
                _dataContext.Entry(origMetadata).CurrentValues.SetValues(newMetadata);
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