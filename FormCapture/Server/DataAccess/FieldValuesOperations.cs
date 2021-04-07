using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class FieldValuesOperations
    {
        private readonly AppDbContext _dataContext;

        public FieldValuesOperations(AppDbContext context)
        {
            _dataContext = context;
        }

        /// <summary>
        /// Method for adding new entries to FieldValues table.
        /// </summary>
        /// <param name="fieldValues">List of FieldValue instances.</param>
        /// <returns>True if entry was written into db. False if not.</returns>
        public async Task<bool> AddNewFieldValues(List<FieldValue> fieldValues)
        {
            try
            {
                _dataContext.FieldValues.AddRange(fieldValues);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<FieldValue> GetFilesFieldValues(string fileID) => _dataContext.FieldValues.Where(i => i.FileID.Equals(fileID)).ToList();

        public async Task<bool> RemoveRangeOfFieldValues(string queueID)
        {
            try
            {
                var files = _dataContext.ProcessedFiles.Where(i => i.QueueID.Equals(queueID)).ToList();
                List<FieldValue> fieldValues;
                foreach (var file in files)
                {
                    fieldValues = _dataContext.FieldValues.Where(i => i.FileID.Equals(file.ID)).ToList();
                    _dataContext.FieldValues.RemoveRange(fieldValues);
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