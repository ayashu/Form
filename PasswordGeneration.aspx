<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordGeneration.aspx.cs" Inherits="WebApplication1.PasswordGeneration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CssPassword.css" />
    <script src="~/lib/query/dist/jquery.js"></script>
    <script src="~/lib/query/dist/jquery.min.js"></script>
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#closed1").click(function () {
                $("#closed1").hide();
                $("#password").attr("type", "password");
            });
            $("#closed").click(function () {
                $("#closed").hide();
                $("#password").attr("type", "password");
            });
        });
    </script>
</head>
<body>

    <div class="container" id="divContainer">
        <div class="formcontainer">
            <form id="form1" runat="server">

                <div class="panels-container">
                    <div class="panel left-panel">

                        <asp:Image ID="Image7" runat="server" CssClass="Leftpanelimg" ImageUrl="https://internationalenterprisegroup.com/wp-content/uploads/2020/11/bottom-img-1-768x627.png" />

                    </div>
                </div>

                <div class="signin-signin">
                    <table class="signintable">
                        <tr>
                            <td colspan="2" align="center" class="title">Set New Password</td>
                        </tr>

                        <tr class="inputfield">
                            <td>
                                <asp:Image ID="imgname" runat="server" CssClass="img" ImageUrl="https://dentalevdashboard.medusindhvb.com/DevD/img/usericon.png" />
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" CssClass="textbox" ReadOnly="true" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="TextBox1">Email missing</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr class="inputfield">
                            <td>
                                <asp:Image ID="Image1" runat="server" CssClass="img" ImageUrl="https://cdn2.iconfinder.com/data/icons/app-types-in-grey/512/lock_512pxGREY.png" />

                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="New password" CssClass="textbox" TextMode="Password" ></asp:TextBox>
                                <i id="closed1" class="fa fa-eye-slash " style="float:right;margin-top:-30px;margin-right: -80px;display:none;cursor:pointer;" ></i>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ControlToValidate="TextBox2">Password missing</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid password format" ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$"></asp:RegularExpressionValidator>

                            </td>
                        </tr>

                        <tr class="inputfield">
                            <td>
                                <asp:Image ID="Image2" runat="server" CssClass="img" ImageUrl="https://cdn2.iconfinder.com/data/icons/app-types-in-grey/512/lock_512pxGREY.png" />

                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" placeholder="Reconfirm password" CssClass="textbox" TextMode="Password"></asp:TextBox>
                                <i id="closed" class="fa fa-eye-slash " style="float:right;margin-top:-30px;margin-right: -80px;display:none;cursor:pointer;" ></i>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TextBox3" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Password missing</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid password format" ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="TextBox3" ControlToCompare="TextBox2" ErrorMessage="CompareValidator" ForeColor="Red">Password does not match</asp:CompareValidator>

                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="Button1" runat="server" Text="Submit" CausesValidation="true" class="loginbtn" OnClick="Button1_Click" OnClientClick="Button1_Click"/>
                            </td>
                        </tr>
                    </table>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ForeColor="Red" ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character." ControlToValidate="TextBox2" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$"></asp:RegularExpressionValidator>
                </div>
            </form>

        </div>
    </div>
</body>
</html>
