using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

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

        public async Task<bool> RemoveRangeOfFieldValues(List<FieldValue> fieldValues)
        {
            try
            {
                _dataContext.FieldValues.RemoveRange(fieldValues);
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