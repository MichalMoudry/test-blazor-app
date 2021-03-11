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

        public List<Field> GetIdentifyingFields(List<Template> templates)
        {
            List<Field> fields = new List<Field>();
            foreach (var template in templates)
            {
                fields.Add(_appDbContext.Fields.SingleOrDefault(i => i.TemplateID.Equals(template.ID) && i.IsIdentifying == true));
            }
            return fields;
        }

        public Dictionary<string, List<Field>> GetNonIdentifyingFields(List<ProcessedFile> processedFiles)
        {
            if (processedFiles == null)
            {
                return null;
            }
            var res = new Dictionary<string, List<Field>>();
            foreach (var file in processedFiles)
            {
                res.Add(file.ID, _appDbContext.Fields.Where(i => i.IsIdentifying.Equals(false) && i.TemplateID.Equals(file.TemplateID)).ToList());
            }
            return res;
        }

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

        public async Task<bool> UpdateFields(List<Field> fields)
        {
            try
            {
                Field originalField;
                foreach (var field in fields)
                {
                    originalField = _appDbContext.Fields.SingleOrDefault(i => i.ID.Equals(field.ID));
                    if (originalField == null)
                    {
                        return false;
                    }
                    _appDbContext.Entry(originalField).CurrentValues.SetValues(field);
                }
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