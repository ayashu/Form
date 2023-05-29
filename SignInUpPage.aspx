<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInUpPage.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignInUpPage</title>
    <%--<link rel="stylesheet" href="StyleSheet1.css" />--%>
    
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" />
    <link rel="stylesheet" href="StyleSheet2.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
    <script src="~/lib/query/dist/jquery.js"></script>
    <script src="~/lib/query/dist/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#closed").click(function () {
                $("#closed").hide();
                $("#password").attr("type", "password");
            });
        });
        
        function addClass() {
            const sign_up_btn = document.querySelector("#Button3");
            const container = document.querySelector(".container");
            sign_up_btn.addEventListener('click', () => {
                container.classList.add('sign-up-mode');
                document.getElementById("form1").reset();
            });
        }
        function removeClass() {
            const sign_up_btn = document.querySelector("#Button2");
            const container = document.querySelector(".container");
            sign_up_btn.addEventListener('click', () => {
                container.classList.remove('sign-up-mode');
                document.getElementById("form1").reset();
            });
        }
        function validation() {
            var img = document.forms["form1"]["Fileupload1"];
            var validExt = [".jpg", ".png", ".bmp", ".gif"];
            if (img.value != '') {
                var img_ext = img.value.substring(img.value.lastIndexOf('.') + 1);
                var result = validExt.includes(img_ext);
                if (result == false) {
                    document.getElementById('Label2').innerHTML = 'Not a valid extension';
                    return false;
                }
                else {
                    if (img.files[0].size > 51200) {
                        document.getElementById('Label2').innerHTML = 'Choose a 50kb file';
                        return false;
                    }
                }
            }
            else {
                document.getElementById('Label2').innerHTML = 'No image selected';
                return false;
            }
            return true;
        }
        function confirm() {
            var confirm_value = document.createelement("input");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("are you sure you want to delete this row?")) {
                confirm_value.value = "yes";
            } else {
                confirm_value.value = "no";
            }
            document.forms[0].appendchild(confirm_value);
        }
        function getImagePreview(input) {
            // var result = validation()
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //if (result == true) {
                    $('#Image1').attr('src', e.target.result)
                        .width(100)
                        .height(70);
                }
                //}
                reader.readAsDataURL(input.files[0]);
            }
            //}
            function openCalendar() {
                var cal = document.getElementById("<%=Calendar1.ClientID %>");
                if (cal.style.visibility == "true") {
                    cal.style.visibility = "false";
                    return false;
                }
                else {
                    cal.style.visibility = "true";
                    return true;
                }
            }
        }
    </script>

    <style type="text/css">
        .auto-style8 {
            font-size: 21px;
            width: 80px;
            height: 101px;
        }

        .auto-style9 {
            width: 173px;
            height: 101px;
        }
    </style>
</head>
<body>
    <div class="container" id="divContainer">
        <div class="formcontainer">
            <form id="form1" runat="server" class="signinup-form">

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <div class="panels-container">
                    <div class="panel left-panel">
                        <div class="content">
                            <h3>New here??</h3>
                            <br />
                            <asp:Button runat="server" CssClass="loginbtn" ID="Button3" Text="Sign Up" OnClick="Button3_Click" CausesValidation="false" OnClientClick="addClass(); return false " />

                        </div>
                        <asp:Image ID="Image7" runat="server" CssClass="Leftpanelimg" ImageUrl="https://internationalenterprisegroup.com/wp-content/uploads/2020/11/bottom-img-1-768x627.png" />

                    </div>

                    <div class="panel right-panel">
                        <div class="content">
                            <h3>One of us</h3>
                            <br />
                            <asp:Button runat="server" CssClass="loginbtn" ID="Button2" Text="Sign In" OnClick="Button2_Click" CausesValidation="false" OnClientClick="removeClass();  return false" />
                        </div>
                        <asp:Image ID="Image6" runat="server" CssClass="Rightpanelimg" ImageUrl="https://cdni.iconscout.com/illustration/premium/thumb/sign-up-page-1886582-1598253.png" />

                    </div>
                </div>

                <div class="signin-signin">

                    <table class="signintable">
                        <tr>
                            <td colspan="2">
                                <div align="center" class="title">
                                    Sign in
                                </div>
                            </td>
                        </tr>
                        <tr class="inputfield">
                            <td>
                                <asp:Image ID="imgname" runat="server" CssClass="img" ImageUrl="https://dentalevdashboard.medusindhvb.com/DevD/img/usericon.png" />
                            </td>
                            <td>
                                <asp:TextBox ID="Textname" runat="server" CssClass="textbox" placeholder="Username(email)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="inputfield">
                            <td>
                                <asp:Image ID="imgpass" runat="server" CssClass="img" ImageUrl="https://cdn2.iconfinder.com/data/icons/app-types-in-grey/512/lock_512pxGREY.png" />
                            </td>
                            <td>
                                <asp:TextBox ID="Textpass" runat="server" CssClass="textbox" placeholder="Password" TextMode="Password"></asp:TextBox>
<%--                                <i id="open" class="fa-solid fa-eye " style="float:right;margin-top:-30px;margin-right: -80px;cursor:pointer;" ></i>--%>
                                <i id="closed" class="fa fa-eye-slash " style="float:right;margin-top:-30px;margin-right: -80px;display:none;cursor:pointer;" ></i>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label5" runat="server" ForeColor="Maroon" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="LoginButton" runat="server" class="loginbtn" Text="Login" OnClick="LoginButton_Click" CausesValidation="false" />
                            </td>
                        </tr>

                    </table>
                </div>

                <div class="signup-signup">

                    <table class="signuptable">
                        <tr>
                            <td colspan="2" align="center">
                                <div align="center" class="title">
                                    Sign Up 
                                </div>
                            </td>
                        </tr>

                        <tr class="inputfield1">
                            <td>
                                <asp:Image ID="Image2" runat="server" CssClass="img" ImageUrl="https://dentalevdashboard.medusindhvb.com/DevD/img/usericon.png" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textboxreg" placeholder="Username"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Name missing" ForeColor="Red" SetFocusOnError="True" Font-Size="10">Name missing</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Invalid name" ForeColor="Red" ValidationExpression="[a-zA-Z]*$" Font-Size="10">Invalid name</asp:RegularExpressionValidator>
                            </td>
                        </tr>

                        <tr class="inputfield11">
                            <td class="calenderimg">
                                <asp:ImageButton ID="ImageButton2" CssClass="calenderimg" runat="server" ImageUrl="https://th.bing.com/th/id/R.f81e214105d61276be3d772037669498?rik=wZlR1S66H8L4uw&riu=http%3a%2f%2ficons.iconarchive.com%2ficons%2fpaomedia%2fsmall-n-flat%2f512%2fcalendar-icon.png&ehk=V7%2bBUpaKm7g0qHpRT7raWGlRTf%2bi2Sw5CwurGpCURBA%3d&risl=&pid=ImgRaw&r=0" ImageAlign="AbsBottom" Width="48px" CausesValidation="False" OnClick="ImageButton1_Click" OnClientClick="ImageButton1_Click;return false;" />
                                <asp:Calendar ID="Calendar1" runat="server" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" OnSelectionChanged="Calendar1_SelectionChanged" CaptionAlign="Top">
                                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                    <WeekendDayStyle BackColor="#CCCCFF" />
                                </asp:Calendar>
                            </td>


                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxreg" placeholder="dd/mm/yyyy" MaxLength="10">
                                </asp:TextBox>


                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Size="10" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Dob missing" ForeColor="Red" SetFocusOnError="True">Dob missing</asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBox2" Font-Size="10" Display="Dynamic" ErrorMessage="Invalid dob" ForeColor="Red" ValidationExpression="^(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ID="RegularExpressionValidator2">Invalid dob</asp:RegularExpressionValidator>

                            </td>
                        </tr>

                        <tr class="inputfield12">
                            <td class="auto-style2">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textboxreg">
                                    <asp:ListItem Value="0">--Select Course--</asp:ListItem>
                                    <asp:ListItem>Science</asp:ListItem>
                                    <asp:ListItem>Arts</asp:ListItem>
                                    <asp:ListItem>Commerce</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Font-Size="10" ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="Course Missing" ForeColor="Red" InitialValue="0" SetFocusOnError="True">Course Missing</asp:RequiredFieldValidator>
                            </td>

                        </tr>

                        <tr>

                            <td colspan="2">
                                <div class="radio">
                                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Gender" Text="Male" CssClass="gender" />
                                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Gender" Text="Female" CssClass="gender" />
                                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Gender" Text="Others" CssClass="gender" />
                                </div>

                                <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" Font-Size="10" ErrorMessage="Gender missing" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate">Gender missing</asp:CustomValidator>
                            </td>
                        </tr>

                        <tr class="inputfield11">

                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="textboxreg" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Font-Size="10" ControlToValidate="DropDownList2" Display="Dynamic" ErrorMessage="State Missing" ForeColor="Red" InitialValue="0" SetFocusOnError="True">State Missing</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr class="inputfield12">
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="textboxreg">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Font-Size="10" ControlToValidate="DropDownList3" Display="Dynamic" ErrorMessage="District Missing" ForeColor="Red" InitialValue="0" SetFocusOnError="True">District Missing</asp:RequiredFieldValidator>

                            </td>
                        </tr>




                        <tr class="inputfield1">
                            <td>
                                <asp:Image ID="Image4" runat="server" CssClass="addressimg" ImageUrl="https://www.pngkey.com/png/full/648-6483874_phone-phone-icon-grey-png.png" />
                            </td>
                            <td class="auto-style5">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="textboxreg" placeholder="Mobile number" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Size="10" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Mobile no missing" ForeColor="Red" SetFocusOnError="True">Mobile no missing</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Font-Size="10" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Invalid mobile number" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^([7-9]{1})([0-9]{9})$">Invalid mobile number</asp:RegularExpressionValidator>
                            </td>
                        </tr>

                        <tr class="inputfield1">
                            <td>
                                <asp:Image ID="Image5" runat="server" CssClass="addressimg" ImageUrl="https://openclipart.org/image/2400px/svg_to_png/216531/Mail-Icon-White-on-Grey.png" />

                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="textboxreg" placeholder="Email"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Font-Size="10" ControlToValidate="TextBox4" ErrorMessage="Email missing" ForeColor="Red" SetFocusOnError="True" Display="Dynamic">email missing</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBox4" Font-Size="10" Display="Dynamic" ErrorMessage="Invalid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid email</asp:RegularExpressionValidator>
                                <asp:Label ID="Label6" runat="server" EnableTheming="False" ForeColor="#990000" Font-Size='10' Display="dynamic"></asp:Label>

                            </td>
                        </tr>

                        <tr class="inputfield1">
                            <td class="text1">AADHAR</td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="textboxreg" placeholder="E.g.347278942565"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Font-Size="10" ControlToValidate="TextBox5" ErrorMessage="Aadhar missing" ForeColor="Red" SetFocusOnError="True" Display="Dynamic">Aadhar missing</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBox5" Font-Size="10" Display="Dynamic" ErrorMessage="Invalid aadhar" ForeColor="Red" ValidationExpression="[0-9]{4}[0-9]{4}[0-9]{4}$">Invalid aadhar</asp:RegularExpressionValidator>
                                <asp:Label ID="Label3" runat="server" EnableTheming="False" ForeColor="#990000" Font-Size='10' Display="dynamic"></asp:Label>

                            </td>
                        </tr>

                        <tr class="inputfield11">

                            <td class="auto-style2">
                                <asp:TextBox ID="textbox8" runat="server" CssClass="textboxreg" placeholder="Enter captcha"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="textbox8" Display="Dynamic" ErrorMessage="Captcha missing" Font-Size="10pt" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:Label ID="Label4" runat="server" Font-Size="10pt" ForeColor="#990000"></asp:Label>
                            </td>
                        </tr>
                        <tr class="inputfield15">
                            <td>
                                <BotDetect:WebFormsCaptcha ID="bot1" runat="server"></BotDetect:WebFormsCaptcha>
                            </td>
                        </tr>

                        <tr class="inputfield14">
                            <td class="text1">Upload Image
                            </td>
                            <td class="textbox">
                                <asp:FileUpload runat="server" ID="FileUpload1" onchange="getImagePreview(this)" />

                                <asp:Label ID="Label2" runat="server" EnableTheming="False" ForeColor="#990000" Font-Size='10'></asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Font-Size="10" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="Image missing" ForeColor="Red">
                        Image missing
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr class="inputfield13">
                            <td>
                                <asp:Image ID="Image1" runat="server" Width="1" Height="1" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Up" CssClass="loginbtn" />

                                <br />
                                <asp:Label ID="Label1" runat="server" ForeColor="Maroon" Font-Size="Medium"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>

            </form>
        </div>
    </div>
</body>
</html>
