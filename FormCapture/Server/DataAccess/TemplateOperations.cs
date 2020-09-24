using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.DataAccess
{
    public class TemplateOperations
    {
        private readonly AppDbContext _appDbContext;

        public TemplateOperations(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Template> GetAppsTemplates(string appID) => _appDbContext.Templates.Where(i => i.AppID.Equals(appID)).OrderBy(i => i.Added).ToList();

        public Template GetTemplate(string templateID) => _appDbContext.Templates.SingleOrDefault(i => i.ID.Equals(templateID));

        public async Task<bool> AddTemplate(Template template)
        {
            try
            {
                if (template == null)
                {
                    return false;
                }
                _appDbContext.Templates.Add(template);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTemplate(Template template)
        {
            try
            {
                if (template == null)
                {
                    return false;
                }
                //TODO: Add removal of fields.
                _appDbContext.Templates.Remove(template);
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