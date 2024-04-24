using System.Text;
using System.Xml.Linq;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
                .AddJsonFile("user.json")
                .AddJsonFile("company.json")
                .AddXmlFile("company.xml")
                .AddIniFile("company.ini");

            builder.Services.Configure<User>(builder.Configuration);

            var app = builder.Build();

            app.MapGet("/user/", (IConfiguration appConfig) => {
                var user = appConfig.Get<User>();

                return user?.ToString();
            });

            app.MapGet("/company/", (IConfiguration appConfig) => {

                int microsoftEmployees = appConfig.GetValue<int>("Microsoft:Employees");
                int appleEmployees = appConfig.GetValue<int>("Apple:Employees");
                int googleEmployees = appConfig.GetValue<int>("Google:Employees");

                if (microsoftEmployees > appleEmployees && microsoftEmployees > googleEmployees)
                {
                    return $"Company with THE HIGHEST number of employees \n    Microsoft: {microsoftEmployees}";
                }
                if (appleEmployees > googleEmployees)
                {
                    return $"Company with THE HIGHEST number of employees:\n     Apple: {appleEmployees}";
                }
                return $"Company with THE HIGHEST number of employees: \n    Google: {googleEmployees}";
            });

            app.Run();
        }
    }
}