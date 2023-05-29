<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebApplication1.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="CssLogin.css" />
    <title>Login page</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ConfirmLogout() {
            return confirm("Are you sure you want to log out?");
        }

        function getImagePreview(input) {
            // var result = validation()
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    //if (result == true) {
                    $('#Image4').attr('src', e.target.result)
                        .width(200)
                        .height(200);
                }
                //}
                reader.readAsDataURL(input.files[0]);
            }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="header">
            <asp:HyperLink ID="LogoLink" runat="server" CssClass="logo" Text="LOGO" NavigateUrl="#section" />
            <ul>
                <li class="active">
                    <asp:HyperLink ID="HomeLink" runat="server" Text="Home" NavigateUrl="#section" CssClass="bullet" />
                </li>
                <li>
                    <asp:HyperLink ID="AboutUsLink" runat="server" Text="About Us" NavigateUrl="#about" CssClass="bullet" />
                </li>
                <li>
                    <asp:HyperLink ID="ProfileLink" runat="server" Text="Profile" NavigateUrl="#profile" CssClass="bullet" />
                </li>
                <li>
                    <asp:HyperLink ID="ContactUsLink" runat="server" Text="Contact Us" NavigateUrl="#contact" CssClass="bullet" />
                </li>
                <li>
                    <div class="inline-container">
                        <asp:Image ID="Image5" runat="server" CssClass="UsernameIcon" ImageUrl="https://i0.wp.com/conniect.org/wp-content/uploads/2020/05/Patient1.png?resize=600%2C600&ssl=1" />
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="EmailText" ReadOnly="true"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <asp:Button ID="LogoutBtn" runat="server" Text="Logout" CssClass="logoutbtn" OnClick="LogoutBtn_Click" OnClientClick="return ConfirmLogout();" />
                </li>
            </ul>
        </div>

        <div class="section" id="section">
            <asp:Image ID="stars" runat="server" CssClass="img1" ImageUrl="https://th.bing.com/th/id/R.6e9dabf4849cd9d68fd0c41506a0261e?rik=4avXbtAFR5Begw&riu=http%3a%2f%2fclipart-library.com%2fnew_gallery%2f22-222446_stars-sticker-by-vminpd-transparent-white-star-overlay.png&ehk=E3bnJzUtmb1d7yiESZ37r9%2bIwXOm592PJvVgLByhFfs%3d&risl=&pid=ImgRaw&r=0" />
            <asp:Image ID="mountain_behind" runat="server" CssClass="img3" ImageUrl="https://static.vecteezy.com/system/resources/previews/012/177/138/original/snow-mountain-free-png.png" />
            <h2 id="text">Welcome!</h2>
            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="btn" Text="Explore" NavigateUrl="#about" />
            <asp:Image ID="mountain_front" runat="server" CssClass="img4" ImageUrl="https://th.bing.com/th/id/R.4eef136adcb9386ad302b06a759e61c7?rik=T3%2fSjCRrktenxg&riu=http%3a%2f%2fclipart-library.com%2fimages_k%2fmountain-clipart-transparent-background%2fmountain-clipart-transparent-background-1.png&ehk=iAh%2bq0Ndfp5v7q0ScXy9H5kp13B9E%2b4bFlVsmPKRsjs%3d&risl=&pid=ImgRaw&r=0" />

        </div>

        <div class="About" id="about">
            <h2>Loreum Ispum</h2>

            <div>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed aliquet nisi id ipsum fringilla, vitae consectetur quam interdum. Nullam bibendum quam in varius ultrices. Vestibulum condimentum, magna et interdum laoreet, sapien velit scelerisque risus, in aliquet nibh nunc in lorem. 
            Mauris elementum, nunc nec aliquam condimentum, mauris nisi tristique dui, non fermentum justo erat vitae nunc. Sed efficitur elit nec lacinia convallis. Fusce feugiat elit a neque fringilla, non fringilla sapien ultricies. 
            Integer finibus, turpis non egestas vulputate, nisl tortor aliquet ex, et placerat dolor purus in massa. Donec venenatis nisl vel massa maximus, non fermentum nibh ultrices. Proin semper, tortor ac euismod scelerisque, felis lectus dapibus urna, ac posuere est nunc id ipsum. 
            Fusce id fringilla lorem, eu gravida ligula. Integer eu metus ipsum. Donec et enim luctus, interdum libero sed, laoreet sapien.
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed aliquet nisi id ipsum fringilla, vitae consectetur quam interdum. Nullam bibendum quam in varius ultrices. Vestibulum condimentum, magna et interdum laoreet, sapien velit scelerisque risus, in aliquet nibh nunc in lorem. 
            Mauris elementum, nunc nec aliquam condimentum, mauris nisi tristique dui, non fermentum justo erat vitae nunc. 
            <br />
                <br />

                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed aliquet nisi id ipsum fringilla, vitae consectetur quam interdum. Nullam bibendum quam in varius ultrices. Vestibulum condimentum, magna et interdum laoreet, sapien velit scelerisque risus, in aliquet nibh nunc in lorem. 
            Mauris elementum, nunc nec aliquam condimentum, mauris nisi tristique dui, non fermentum justo erat vitae nunc. Sed efficitur elit nec lacinia convallis. Fusce feugiat elit a neque fringilla, non fringilla sapien ultricies. 
            Integer finibus, turpis non egestas vulputate, nisl tortor aliquet ex, et placerat dolor purus in massa. Donec venenatis nisl vel massa maximus, non fermentum nibh ultrices. Proin semper, tortor ac euismod scelerisque, felis lectus dapibus urna, ac posuere est nunc id ipsum. 
            Fusce id fringilla lorem, eu gravida ligula. Integer eu metus ipsum. Donec et enim luctus, interdum libero sed, laoreet sapien.
            <br />
                <br />
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed aliquet nisi id ipsum fringilla, vitae consectetur quam interdum. Nullam bibendum quam in varius ultrices. Vestibulum condimentum, magna et interdum laoreet, sapien velit scelerisque risus, in aliquet nibh nunc in lorem. 
            Mauris elementum, nunc nec aliquam condimentum, mauris nisi tristique dui, non fermentum justo erat vitae nunc. Sed efficitur elit nec lacinia convallis. Fusce feugiat elit a neque fringilla, non fringilla sapien ultricies. 
            Integer finibus, turpis non egestas vulputate, nisl tortor aliquet ex, et placerat dolor purus in massa. Donec venenatis nisl vel massa maximus, non fermentum nibh ultrices. Proin semper, tortor ac euismod scelerisque, felis lectus dapibus urna, ac posuere est nunc id ipsum. 
            Fusce id fringilla lorem, eu gravida ligula. 
            </div>
        </div>

        <div class="Profile" id="profile">
            <h2>Profile</h2>
            <div class="ProfileInfo">
                <div class="profilebox">
                    <asp:Image ID="Image4" runat="server" CssClass="Profileimg" />
                    <div id="uploadSection" runat="server" visible="false">
                        <p class="UploadText">Upload Image</p>

                        <asp:Label ID="Label2" runat="server" EnableTheming="False" ForeColor="#990000" Font-Size='10' CssClass="UploadLabel"></asp:Label>

                        <asp:FileUpload runat="server" ID="FileUpload1" onchange="getImagePreview(this)" CssClass="FileUpload" />
                    </div>
                </div>
                <div class="profilebox">
                    <table>
                        <tr>
                            <td>Name
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textboxreg" placeholder="Username"></asp:TextBox>
                            </td>

                            <td>DOB
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxreg" placeholder="Dob"></asp:TextBox>
                                <asp:ImageButton ID="ImageButton2" CssClass="calenderimg" Visible="false" runat="server" ImageUrl="https://th.bing.com/th/id/R.f81e214105d61276be3d772037669498?rik=wZlR1S66H8L4uw&riu=http%3a%2f%2ficons.iconarchive.com%2ficons%2fpaomedia%2fsmall-n-flat%2f512%2fcalendar-icon.png&ehk=V7%2bBUpaKm7g0qHpRT7raWGlRTf%2bi2Sw5CwurGpCURBA%3d&risl=&pid=ImgRaw&r=0" ImageAlign="AbsBottom" Width="48px" CausesValidation="False" OnClick="ImageButton1_Click" OnClientClick="ImageButton1_Click;return false;" />
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
                        </tr>

                        <tr>
                            <td>Course
                            </td>
                            <td>
                                <%--<asp:TextBox ID="TextBox3" runat="server" CssClass="textboxreg" placeholder="Course"></asp:TextBox>--%>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textboxreg">
                                    <asp:ListItem>Science</asp:ListItem>
                                    <asp:ListItem>Arts</asp:ListItem>
                                    <asp:ListItem>Commerce</asp:ListItem>
                                </asp:DropDownList>
                            </td>

                            <td>Gender
                            </td>
                            <td>
                                <%--<asp:TextBox ID="TextBox4" runat="server" CssClass="textboxreg" placeholder="Gender"></asp:TextBox>--%>
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="textboxreg">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                    <asp:ListItem>Others</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>State
                            </td>
                            <td>
                                <%--<asp:TextBox ID="TextBox5" runat="server" CssClass="textboxreg" placeholder="State"></asp:TextBox>--%>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="textboxreg" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </td>

                            <td>District
                            </td>
                            <td>
                                <%--<asp:TextBox ID="TextBox6" runat="server" CssClass="textboxreg" placeholder="District"></asp:TextBox>--%>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="textboxreg">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr>
                            <td>Mobile No
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox7" runat="server" CssClass="textboxreg" placeholder="Mobile number"></asp:TextBox>
                            </td>

                            <td>Aadhar No
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="textboxreg" placeholder="Email"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <asp:Label ID="Label1" runat="server" EnableTheming="False" ForeColor="green" Font-Size='10' Display="dynamic" CssClass="Label1"></asp:Label>
                        </tr>

                    </table>
                </div>
            </div>
            <div class="ProfileButtons">
                <asp:Button ID="Button1" runat="server" Text="Modify" CssClass="Profilebtn" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Delete" CssClass="Profilebtn" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="Save" CssClass="Profilebtn" OnClick="Button3_Click" />
                <asp:Button ID="Button4" runat="server" Text="Cancel" CssClass="Profilebtn" OnClick="Button4_Click" />

            </div>


        </div>

        <div class="ContactUs" id="contact">
            <h2>Contact Us!!</h2>
            <div class="contactInfo">

                <div class="box" <%--id="box1"--%>>
                    <div class="icon">
                        <asp:Image ID="Image1" runat="server" CssClass="img1" ImageUrl="https://cdn.asp.events/CLIENT_Clarion__96F66098_5056_B733_492B7F3A0E159DC7/sites/Clarion-Defence-Portal/media/__theme/J372528_D&S04_Stats_450x400_v2-(Events-B).png" />
                    </div>
                    <div class="text">
                        <h3>Address</h3>
                        <p>
                            190 Karanpur<br />
                            Block 2<br />
                            Dehradun,Uttarakhand
                        </p>
                    </div>
                </div>

                <div class="box" <%--id="box2"--%>>
                    <div class="icon">
                        <asp:Image ID="Image2" runat="server" CssClass="img1" ImageUrl="https://th.bing.com/th/id/R.2cb691cd5c05328f15f39263f70220ce?rik=Z7%2f8evAQURfttw&riu=http%3a%2f%2fclipart-library.com%2fimg%2f1344166.png&ehk=Eup27LJAdO89zKYNjO5mrk80mR6Wc%2bMwWeLa%2bD8eA%2f4%3d&risl=&pid=ImgRaw&r=0" />
                    </div>
                    <div class="text">
                        <h3>Phone</h3>
                        <p>
                            9927792538<br />
                            9760203409<br />
                            9927792538
                        </p>
                    </div>
                </div>

                <div class="box" <%--id="box3"--%>>
                    <div class="icon">
                        <asp:Image ID="Image3" runat="server" CssClass="img1" ImageUrl="https://appforwin10.com/wp-content/uploads/2019/03/Aqua-Mail-Email-App-App-for-Windows-10.png" />
                    </div>
                    <div class="text">
                        <h3>Email</h3>
                        <p>
                            ayashu@gmail.com<br />
                            kothiyal@gmail.com<br />
                            ak@gmail.com
                        </p>
                    </div>
                </div>

            </div>
        </div>

    </form>
</body>
</html>
