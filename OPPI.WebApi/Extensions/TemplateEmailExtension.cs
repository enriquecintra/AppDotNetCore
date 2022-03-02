using OPPI.WebApi.Interfaces;
using RazorEngine;
using RazorEngine.Templating;
using System.IO;

namespace OPPI.WebApi.Extensions
{
    public static class TemplateEmailExtension
    {
        public static string ToEmail(this ITemplateEmail model, string templateFilePath)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(templateFilePath) || model == null) return result;

            if (File.Exists(templateFilePath))
            {
                string template = File.ReadAllText(templateFilePath);

                result = Engine.Razor.RunCompile(template, model.Id.ToString(), null, model);
            }
            return result;
        }
    }
}
