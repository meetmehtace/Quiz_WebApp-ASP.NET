<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous"/>
    <title>Quiz</title>
    
</head>
<body>

    <form id="form1" runat="server" >
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                 <div>
                    <section class="vh-100" style="background-color: #9A616D;">
                          <div class="container py-5 h-100">
                            <div class="row d-flex justify-content-center align-items-center h-100">
                              <div class="col col-xl-10">
                                <div class="card" style="border-radius: 1rem;">
                                  <div class="row g-0">
                                    <div class="col-md-6 col-lg-5 d-none d-md-block">
                                      <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img1.webp"
                                        alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
                                    </div>
                                    <div class="col-md-6 col-lg-7 d-flex align-items-center">
                                      <div class="card-body p-4 p-lg-5 text-black">

               

                 

                                          <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Sign into your account</h5>

                                          <div class="form-outline mb-4">
                      
                  
                                              <asp:TextBox ID="TextBox1" runat="server" type="email"  class="form-control form-control-lg"  >mmehta498@rku.ac.in</asp:TextBox>
                     
                      
                      
                                            <label class="form-label"  runat="server" for="form2Example17">Email</label>

                                          </div>

                                          <div class="form-outline mb-4">
                    
                                              <asp:TextBox ID="TextBox2" runat="server" type="password"  class="form-control form-control-lg" OnTextChanged="TextBox2_TextChanged">1234@</asp:TextBox>
                    

             
                                              <label class="form-label" for="form2Example27">Password</label>

                                          </div>

                                          <div class="pt-1 mb-4">
                                                <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-dark btn-lg btn-block" type="button" OnClick="Button1_Click"/>
                   
                                          </div>

                                        
                                          <p class="mb-5 pb-lg-2" style="color: #393f81;">Don't have an account? 
                      
                                              <asp:Button ID="Button2" runat="server" Text="Register Here " class="btn btn-dark btn-lg btn-block" OnClick="Button2_Click"/></p>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
</section>
        </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                  <div>
            <section class="vh-100" style="background-color: #9A616D;">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col col-xl-10">
        <div class="card" style="border-radius: 1rem;">
          <div class="row g-0">
            <div class="col-md-6 col-lg-5 d-none d-md-block">
              <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img1.webp"
                alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
            </div>
            <div class="col-md-6 col-lg-7 d-flex align-items-center">
              <div class="card-body p-4 p-lg-5 text-black">

               

                 

                  <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Sign into your account</h5>

                  <div class="form-outline mb-4">
                  
                      <asp:TextBox ID="TextBox3" runat="server" type="text"  class="form-control form-control-lg"></asp:TextBox>
                      
                    
                    <label class="form-label" for="form2Example17">Enrolment Number</label>
                  </div>

                  <div class="form-outline mb-4">
                    
                      <asp:TextBox ID="TextBox4" runat="server" type="email"  class="form-control form-control-lg"></asp:TextBox>
                    <label class="form-label" for="form2Example27">Email Id

                    </label>
                  </div>



                   <div class="form-outline mb-4">
                    
                      <asp:TextBox ID="TextBox5" runat="server" type="password"  class="form-control form-control-lg"></asp:TextBox>
                    <label class="form-label" for="form2Example27">Password</label>
                  </div>
                 

                  <div class="pt-1 mb-4">
                        <asp:Button ID="Button3" runat="server" Text="Sign" class="btn btn-dark btn-lg btn-block" type="button" OnClick="Button3_Click" />
                   
                  </div>

                  <a class="small text-muted" href="#!">Forgot password?</a>
                  <p class="mb-5 pb-lg-2" style="color: #393f81;">have an account? 
                      
                      <asp:Button ID="Button4" runat="server" Text="Login Here " class="btn btn-dark btn-lg btn-block" OnClick="Button4_Click" /></p>
              
              
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
        </div>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
