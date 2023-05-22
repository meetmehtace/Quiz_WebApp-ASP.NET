using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Login : System.Web.UI.Page
    {
        String query = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Meet\\source\\repos\\WebApplication3\\WebApplication3\\App_Data\\quiz.mdf;Integrated Security=True";
        SqlConnection con;
        String sql;
        SqlCommand cmd;
        SqlDataReader reader;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(query);
            con.Open();

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
             String email, password;
              email=TextBox1.Text;
              password=TextBox2.Text;
              sql = "select * from Student where emailId='"+email+"' and password ='"+password+"'";
              cmd = new SqlCommand(sql, con);
              reader =cmd.ExecuteReader();    
              dt.Load(reader);
              if (dt.Rows.Count ==0)
              {
                  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong id & password')", true);
              }
              else
              {  
                  Session["Id"] = (int)dt.Rows[0]["Id"];
                  Session["EmailId"] = dt.Rows[0]["EmailId"].ToString();
                  Session["ErNumber"] = dt.Rows[0]["ErNumber"].ToString();
                  Response.Redirect("Home.aspx");
              }
        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            String ern, email, password;
            ern = TextBox3.Text;
            email = TextBox4.Text;
            password = TextBox5.Text;
            sql = "insert into Student values('" + ern + "','" + email + "','" + password + "')";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}