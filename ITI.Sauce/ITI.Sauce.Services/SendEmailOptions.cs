using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Sauce.Services
{
    public class SendEmailOptions
    {
        public SendEmailOptions()
        {
            ToEmails = new List<string>();
        }
        public string? Subject { get; set; }
        public string? FromEmail { get; set; }
        public string? FromEmailDisplayName { get; set; }
        public string? Body { get; set; }
        public List<string>? ToEmails { get; set; }
        public bool IsBodyHTML { get; set; }

        public static string GenerateBodyFromTemplate(string templateName, Dictionary<string, string> placeHoldresValues)
        {
            string templateBody = File.ReadAllText($"EmailTemplates/{templateName}.html");
            foreach (var pair in placeHoldresValues)
            {
                templateBody = templateBody.Replace(pair.Key, pair.Value);
            }
            return templateBody;
        }


    }
}
