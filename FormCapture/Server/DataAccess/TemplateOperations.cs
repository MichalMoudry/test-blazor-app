using FormCapture.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.DataAccess
{
    public class TemplateOperations
    {
        private readonly AppDbContext _appDbContext;

        public TemplateOperations(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

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
                _appDbContext.Templates.Remove(template);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTemplates(List<Template> templates)
        {
            try
            {
                if (templates == null)
                {
                    return false;
                }
                _appDbContext.Templates.RemoveRange(templates);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Template> GetAppsTemplates(string appID)
        {
            var templates = _appDbContext.Templates.Where(i => i.AppID.Equals(appID)).OrderBy(i => i.Added).ToList();
            templates.ForEach(i => i.Image = null);
            return templates;
        }

        public Template GetTemplate(string templateID) => _appDbContext.Templates.SingleOrDefault(i => i.ID.Equals(templateID));

        public async Task<bool> UpdateTemplate(Template newTemplate)
        {
            try
            {
                var originalTemplate = _appDbContext.Templates.SingleOrDefault(i => i.ID.Equals(newTemplate.ID));
                if (originalTemplate == null)
                {
                    return false;
                }
                _appDbContext.Entry(originalTemplate).CurrentValues.SetValues(newTemplate);
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