﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace jqueryByKudvenkat
{
    

    public partial class GetHelpTextInXml : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HelpText));
            xmlSerializer.Serialize(Response.OutputStream, GetHelpTextByKey(Request["HelpTextKey"]));

        }

        private HelpText GetHelpTextByKey(string key)
        {
            HelpText helpText = new HelpText();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetHelpTextByKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@HelpTextKey", key);
                cmd.Parameters.Add(parameter);
                con.Open();
                helpText.Text = cmd.ExecuteScalar().ToString();
                helpText.Key = key;
            }

            return helpText;
        }
    }
}