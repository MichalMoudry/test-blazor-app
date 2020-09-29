using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class FieldOperations
    {
        private readonly AppDbContext _appDbContext;

        public FieldOperations(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Field> GetTemplateFields(string templateID) => _appDbContext.Fields.Where(i => i.TemplateID.Equals(templateID)).ToList();

        public async Task<bool> AddFields(List<Field> fields)
        {
            try
            {
                _appDbContext.AddRange(fields);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveFields(List<Field> fields)
        {
            try
            {
                _appDbContext.RemoveRange(fields);
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