using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    
    public partial class Home : System.Web.UI.Page
    {
        int quizId = 0;
        String query = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Meet\\source\\repos\\WebApplication3\\WebApplication3\\App_Data\\quiz.mdf;Integrated Security=True";
        SqlConnection con;
        String sql;
        SqlCommand cmd;
        SqlDataReader reader;
        DataTable dt = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Id"] == null) Response.Redirect("Login.aspx");
            con = new SqlConnection(query);
            con.Open();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String acccessCode = TextBox1.Text;
            sql = "select * from AccessCode where AccessCode='" + acccessCode + "'";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            dt.Load(reader);
            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong AccessCode')", true);
            }
            else
            {
                int accessCodeId = Convert.ToInt16(dt.Rows[0]["Id"]);
                sql = "select * from QuizDetail where AccessCodeId='" + accessCodeId + "'";
                cmd = new SqlCommand(sql, con);
                
                reader = cmd.ExecuteReader();
                dt= new DataTable();
                dt.Load(reader);
                if (dt.Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong AccessCode')", true);
                }
                else
                {
                    quizId = (int)dt.Rows[0]["Id"];
                    Session["quizId"] = quizId;
                    Session["quifId"]= (int)dt.Rows[0]["Id"];

                    int NumberOfMcq = (int)dt.Rows[0]["NumberOfMcq"];
                    int TimeForExam = (int)dt.Rows[0]["TimeForExam"];
                    Session["NumberOfMcq"] = NumberOfMcq;
                    Session["TimeForExam"] = TimeForExam;
                    Session["m"] = TimeForExam;
                    Label1.Text = NumberOfMcq.ToString();
                    Label2.Text=TimeForExam.ToString();
                    int sid = (int)Session["Id"];
                    int t = (int)dt.Rows[0]["Id"];
                    sql = "select * from StudentQuiz where StudentId='" + sid + "' and Quizid='" + t + "'";
                    cmd = new SqlCommand(sql, con);
                    reader = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(reader);
                    
                    if (dt.Rows.Count >= 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('your are allready taken')", true);
                        Button1.Enabled = false;
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 1;
                    }
                }
            }
            
        }

        protected void QuizMcq(int row )
        {
              
            int co = (int)Session["co"];
            if (row < co)
            {
                dt =(DataTable) Session["reader"];
                Label3.Text = " ("+(row + 1).ToString()+") ";
                Session["QuestionsId"] = (int)dt.Rows[row]["Id"];
                Label4.Text = dt.Rows[row]["Question"].ToString();

                RadioButton1.Text = dt.Rows[row]["Options_A"].ToString();
                RadioButton2.Text = dt.Rows[row]["Options_B"].ToString();
                RadioButton3.Text = dt.Rows[row]["Options_C"].ToString();
                RadioButton4.Text = dt.Rows[row]["Options_D"].ToString();

                row++;
            }
         
            if (row == co)
            {
                Button3.Text = "Submit";
            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {

            int a = 0;

            if (RadioButton1.Checked) a = 1;
            if (RadioButton2.Checked) a = 2;
            if (RadioButton3.Checked) a = 3;
            if (RadioButton4.Checked) a = 4;
            if (a == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select options')", true);
            }
            else
            {

                int sid = (int)Session["Id"];
                quizId = (int)Session["quizId"];
                int qid = (int)Session["QuestionsId"];
                sql = "insert into StudentQuizAns values('" + sid + "','" + quizId + "','"+qid+"','"+a+"')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                RadioButton1.Checked = false;
                RadioButton2.Checked = false;
                RadioButton3.Checked = false;
                RadioButton4.Checked = false;
                if (Button3.Text == "Submit")
                {
                    //checking ans    where QuizId='" + quizId+
                    Label14.Text = Session["ErNumber"].ToString();
                    Label11.Text = Session["NumberOfMcq"].ToString();
                    sql = "select QuizAnswer.Id from QuizAnswer inner join  StudentQuizAns ON QuizAnswer.QuizQuesionsID=StudentQuizAns.QuestionsId and  StudentQuizAns.AnswerId = QuizAnswer.QuizAnswerId where StudentQuizAns.StudentId='" + sid+ "' and StudentQuizAns.StudentQuizid='"+quizId+"'";
                    cmd = new SqlCommand(sql, con);
                    reader = cmd.ExecuteReader();
                    DataTable dt2 = new DataTable();
                    dt2.Load(reader);
                    Timer1.Enabled= false;
                    if (dt2.Rows.Count >= 1)
                    {
                        Label12.Text = dt2.Rows.Count.ToString();
                       
                        MultiView1.ActiveViewIndex = 3;
                    }
                    else
                    {
                        Label12.Text = dt2.Rows.Count.ToString();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have 0 marks ')", true);
                      
                        MultiView1.ActiveViewIndex = 3;
                    }
                      
                }
                else
                {
                   
                    QuizMcq(1);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int h, m, s;
            m=Convert.ToInt16(Session["m"]);
            s = m * 60;
            s += 0;
            h = (s / 60) / 60;
            m = (s / 60) - (h * 60);
            s = s - ((h * 60 * 60) + (m * 60));
            Session["h"] = h;
            Session["m"] = m;
            Session["s"] = s;
            Timer1.Enabled = true;
            quizId = (int)Session["quizId"];

            sql = "select * from QuizMcq where QuizId='" + quizId + "'";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Quiz')", true);
            }
            else
            {
                int co = dt.Rows.Count;
                Session["co"] = co;
                Session["reader"] = dt;
                int sid = (int)Session["Id"];
                int quifId = (int)Session["quifId"];

                sql = "insert into StudentQuiz values('"+sid+"','"+quifId+"')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                QuizMcq(0);
            }

            MultiView1.ActiveViewIndex = 2;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void GetTime(object sender, EventArgs e)
        {
            int h, m, s;
            h = Convert.ToInt16(Session["h"]);
            m = Convert.ToInt16(Session["m"]);
            s = Convert.ToInt16(Session["s"]);
            lblTime.Text = " "+h+" : "+m+" : "+s+" ";
            if(s>0)
            {
                Session["s"] = (s-1);
            }
            else if(s<=0)
            {
                Session["s"] = 60;
                Session["m"] = (m-1);
                if(m<=0)
                {
                    Session["h"] = (h-1);
                    Session["m"] = 60;
                    if (h<=0 && m<=0 && s<=0)
                    {
                        marks();
                        Timer1.Enabled=false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('time up')", true);
                    }
                }

            }
        }
        protected void marks()
        {

            int sid = (int)Session["Id"];
            quizId = (int)Session["quizId"];
            Label14.Text = Session["ErNumber"].ToString();
            Label11.Text = Session["NumberOfMcq"].ToString();
            sql = "select QuizAnswer.Id from QuizAnswer inner join  StudentQuizAns ON QuizAnswer.QuizQuesionsID=StudentQuizAns.QuestionsId and  StudentQuizAns.AnswerId = QuizAnswer.QuizAnswerId where StudentQuizAns.StudentId='" + sid + "' and StudentQuizAns.StudentQuizid='" + quizId + "'";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(reader);
            if (dt2.Rows.Count >= 1)
            {
                Label12.Text = dt2.Rows.Count.ToString();
                MultiView1.ActiveViewIndex = 3;
            }
            else
            {
                Label12.Text = dt2.Rows.Count.ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('you have 0 marks ')", true);
                MultiView1.ActiveViewIndex = 3;
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int sid = (int)Session["Id"];
            sql = "select * from StudentQuiz where StudentId='"+sid +"'";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(reader);
            GridView1.DataSource= dt2;
            GridView1.DataBind();
            MultiView1.ActiveViewIndex= 4;
        }
    }
}