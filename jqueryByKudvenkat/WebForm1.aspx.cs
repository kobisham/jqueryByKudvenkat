using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace jqueryByKudvenkat
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // From .NET to JSON
            //Employee employee1 = new Employee
            //{
            //    FirstName = "kobi",
            //    LastName = "shamir",
            //    Gender = "male",
            //    Salary = 40000
            //};

            //Employee employee2 = new Employee
            //{
            //    FirstName = "Sarit",
            //    LastName = "Levi",
            //    Gender = "female",
            //    Salary = 35000
            //};

            //List<Employee> listEmployee = new List<Employee>();
            //listEmployee.Add(employee1);
            //listEmployee.Add(employee2);

            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //string JSONString=javaScriptSerializer.Serialize(listEmployee);

            //Response.Write(JSONString);

            // From JSON to .NET
            string jsonString = "[{\"FirstName\":\"kobi\",\"LastName\":\"shamir\",\"Gender\":\"male\",\"Salary\":40000},{\"FirstName\":\"Sarit\",\"LastName\":\"Levi\",\"Gender\":\"female\",\"Salary\":35000}] ";

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<Employee> listEmployee= (List<Employee>)javaScriptSerializer.Deserialize(jsonString,typeof(List<Employee>));

            foreach(Employee emp in listEmployee)
            {
                Response.Write("First Name:<strong>" + emp.FirstName + "</strong></br>");
                Response.Write("Last Name:<strong>" + emp.LastName + "</strong></br>");
                Response.Write("Gender:<strong>" + emp.Gender + "</strong></br>");
                Response.Write("Salary:<strong>" + emp.Salary + "</strong></br></br>");

            }

        }
    }
}