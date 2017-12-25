
using System.Collections.Specialized;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormTest());

            string host = "http://redmine.binhanh.com.vn:89/redmine";
            string apiKey = "buVJbgHAfzFtfDpyQVuo";

            var manager = new RedmineManager(host, "admin", "admin^CMt3,$Dq>%:@GN/");

            var parameters = new NameValueCollection { { "status_id", "*" } };
            foreach (var issue in manager.GetObjectList<Issue>(parameters))
            {
                Console.WriteLine("#{0}: {1}", issue.Id, issue.Subject);
            }

            var parameters_custom_fields = new NameValueCollection { { "custom_field", "*" } };
            foreach (var issue in manager.GetObjectList<CustomField>(parameters_custom_fields))
            {
                Console.WriteLine("#{0}: {1}", issue.Id, issue.Values);
            }
            //List customFieldsList = mgr.getIssues(projectKey, queryId).get(0).getCustomFields();

            //for (CustomField customField in manager.)
            //{
            //    System.out.println(customField.getName());
            //    if (customField.getName().equalsIgnoreCase("MyDate"))
            //    {
            //        customField.setValue("2012-08-02");
            //    }
            //}

            //    CustomField ThuocNhom = new CustomField();
            //ThuocNhom.
            //Create a issue.
            var newIssue = new Issue {
                Subject = "test",
                Project = new IdentifiableName { Id = 1 }
                
            };
            manager.CreateObject(newIssue);
        }
    }
}
