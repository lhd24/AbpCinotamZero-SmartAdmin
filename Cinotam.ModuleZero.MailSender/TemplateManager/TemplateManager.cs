﻿using Cinotam.ModuleZero.MailSender.TemplateManager.Templates;
using System;
using System.Collections.Generic;
using System.Web.Hosting;

namespace Cinotam.ModuleZero.MailSender.TemplateManager
{
    public class TemplateManager : ITemplateManager
    {
        public string GetContent(TemplateType type, string user, string content)
        {
            switch (type)
            {
                case TemplateType.Welcome:
                    return GetTextFromFile(new WelcomeTemplate(user, content, false));
                case TemplateType.NotificationUserChangePassword:
                    return GetTextFromFile(new ChangePasswordTemplate(user, content));
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public string GetContent(TemplateType type, IDictionary<int, string> arguments)
        {
            throw new NotImplementedException();
        }

        private string GetTextFromFile(Template template)
        {
            try
            {
                var localPath = HostingEnvironment.MapPath(template.TemplateRoute);
                if (localPath != null)
                {
                    var text = System.IO.File.ReadAllText(localPath);
                    var format = string.Format(text, template.User, template.Content);
                    return format;
                }
                return template.Content;
            }
            catch (Exception)
            {
                return template.Content;
            }
        }
    }
}