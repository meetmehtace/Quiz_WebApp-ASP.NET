<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication3.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
    <style type="text/css">
        body {
            background-color: #331B3F;
            color: #ACC7B4;
        }

        .auto-style1 {
            color: #000000;
        }

        .container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            width: 700px;
        }
    </style>
</head>
<body>
     
    <form id="form1" runat="server">
        <div>
            <center>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                       

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
                       <div style="display: flex;
    justify-content: center;
    align-items: center;
    margin-top:40vh;
    width:400px;">
                        <div class="input-group input-group-lg">
                            <span class="input-group-text" id="inputGroup-sizing-lg">Enter AccessCode To Joint</span>
                           
                        <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                        </div>
                     </div>
                         
                        <br>
                        <br></br>
                        <asp:Button ID="Button1" runat="server" class="btn btn-light" OnClick="Button1_Click" Text="Join" />
                        </br>
                          
                    </asp:View>
                    <asp:View ID="View3" runat="server">

                      
                      <div style="display: flex;
    justify-content: center;
    align-items: center;
    margin-top:40vh;
    width:400px;">
                      
                        <h1><asp:Label ID="Label6" class="label other" runat="server" Text="Label">Number of Mcq : </asp:Label>
                        <asp:Label ID="Label1" class="label other" runat="server" Text="Label"></asp:Label></h1>
                          </div>
                      
                        <h1> <asp:Label ID="Label7" class="label other"  runat="server" Text="Label">Time for Quiz :  </asp:Label>
                         <asp:Label ID="Label2" class="label other" runat="server" Text="Label"></asp:Label></h1
                            </br>
                        <br>
                        
                       
                        <asp:Button ID="Button2" runat="server" class="btn btn-light" OnClick="Button2_Click" Text="Start" />
                     
                       

                    </asp:View>
                    <asp:View ID="View2" runat="server">
               
                       
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <div style="border: 2px dotted;border-color: #96D4D4;border-radius: 10px;">

         <h3> Timmer : <asp:Label ID="lblTime" runat="server" /></h3>
                        <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000" OnTick="GetTime" />
        </div>
                        
               </ContentTemplate>
</asp:UpdatePanel>       

                      <div style="display: flex;
    justify-content: center;
    align-items: center;
    margin-top:30vh;
    width:400px;">
                             

                          
                        <h3>
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </h3>
                        </div>


                       <br />


                     

                        <table style="justify-content: center;
    align-items: center;">
                         <tr>
                        <td align="left"><asp:RadioButton  class="r" ID="RadioButton1" runat="server"  GroupName="a" Font-Size="Large" /></td>
                        </tr>
                            <tr>
                        <td align="left" ><asp:RadioButton class="r"  ID="RadioButton2" runat="server"  GroupName="a" Font-Size="Large"/></td>
                        </tr>
                        <tr>
                        <td align="left" ><asp:RadioButton class="r"  ID="RadioButton3"  runat="server" GroupName="a" Font-Size="Large"/></td>
                        </tr>
                        <tr>
                        <td align="left" ><asp:RadioButton class="r"  ID="RadioButton4"  runat="server" GroupName="a" Font-Size="Large"/></td>
                         </tr>
                       
                       
                 
                        </table>
                        <br>
                        </br>
                        <asp:Button ID="Button3" class="btn btn-light" runat="server" OnClick="Button3_Click" Text="Next" />
                       
                       
                   
                        
                    </asp:View>
                    <asp:View ID="View4" runat="server">
                        

                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />

                         <div  style="border: 2px dotted;border-color: #96D4D4;border-radius: 10px;">
                                <h1>Your Quiz Complete </h1>
                             </div>
                        <br>
                         <br>
                         <div >
                              <table style="border: 2px dotted;border-color: #96D4D4;border-radius: 10px;">
                     
                      <tr> 
                          <td align="left">      <h1>  Enrolment No.    </h1> </td> 
                          <td align="left" style="padding-left: 30px;" >      <h1>    <asp:Label ID="Label14" runat="server" Text="Label" ></asp:Label>  </h1> </td> 

                      </tr> 
                      <tr> 
                          <td align="left">      <h1>  Total Questions    </h1> </td> 
                          <td align="left" style="padding-left: 30px;">      <h1>    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>   </h1> </td> 
                      </tr> 
                      <tr> 
                          <td align="left">      <h1>   Correct Answer   </h1>  </td> 
                          <td align="left" style="padding-left: 30px;" >      <h1>   <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>   </h1> </td> 
                      </tr> 
                     
                      
                                   </table >
                             </div>
                    </asp:View>
                    <asp:View ID="View5" runat="server">
                        <asp:GridView ID="GridView1" runat="server">

                        </asp:GridView>
                    </asp:View>
                </asp:MultiView>
                                
            </center>
        </div>
    </form>
</body>
</html>
