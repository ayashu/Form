using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Web.Services.Description;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using System.Drawing;
using Microsoft.Win32;
using BotDetect;
using System.Data.SQLite;
using System.Drawing.Printing;
using System.Data.Common;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Collections.ObjectModel;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";

            if (!IsPostBack)
            {
                bindState();
                Calendar1.Visible = false;
                //Button2.Visible = false;
                //Button3.Visible = false;
                //Button4.Visible = false;
                // Regist.Visible = false;
                //this.bindingdata();
                //Image1.Visible = false;
                //LoadImage();
            }
            using (SqlConnection sql = new SqlConnection(mycon))
            {
                sql.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from register", mycon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                
                sql.Close();
            }

            if (Session["passgen"] != null && !string.IsNullOrEmpty(Session["passgen"].ToString()))
            {
                Label5.Text = Session["passgen"].ToString();
            }
            
            else
            {
                Label5.Text = "";
            }

        }


        private void LoadImage()
        {
            // string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            String cs = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from register", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
            Calendar1.Attributes.Add("style", "position:absolute");
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //submit button click
            Session["email"]=TextBox4.Text;
            Calendar1.Visible = false;
            Label1.Text = "";
            if (SubmitAccount() == true)
            {
                Label1.Attributes.Add("style", "color:green");
                Label1.Text = "Data of " + TextBox1.Text + " has been submitted";
                //Regist.Visible = true;
                clearAllFields();
                LoadImage();
                Response.Redirect("PasswordGeneration.aspx");

            }
            else
            {
                Label1.Attributes.Add("style", "color:red");
                Label1.Text = "Error occured,Try again";
            }
        }
        void clearAllFields()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox5.Text = "";
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
            RadioButton3.Checked = false;
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            TextBox3.Text = "";
            TextBox4.Text = "";
            Label3.Text = "";
            Textname.Text = "";
            Textpass.Text = "";
            Label5.Text = "";
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (RadioButton1.Checked || RadioButton2.Checked || RadioButton3.Checked)
            {
                args.IsValid = true;
                
            }
            else
            {
                args.IsValid = false;
                
            }
        }
        bool Gender()
        {
            if (RadioButton1.Checked || RadioButton2.Checked || RadioButton3.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            bool SubmitAccount()
        {
            string gender = string.Empty;
            if (RadioButton1.Checked)
            {
                gender = "Male";
            }
            else if (RadioButton2.Checked)
            {
                gender = "Female";
            }
            else if (RadioButton3.Checked)
            {
                gender = "others";
            }
          
            Boolean check = bot1.Validate(textbox8.Text);
            if (check != true)
            {
                Label4.Text = "Invalid Captcha";
            }
            
            else
            {
                Label4.Text = "";
            }
            

            if (Gender() == true && btnUpload_Click() == true && DuplicateRecord2() == true && DuplicateRecord() == true && check == true )

            {
                Label6.Text = "";
                Label3.Text = "";
                byte[] pic = FileUpload1.FileBytes;

              
                String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
                SqlConnection con = new SqlConnection(mycon);
                SqlCommand cmd1 = new SqlCommand("insert into register" + "(aadhar,name,dob,gender,course,mobile,email,image,state,district)  values(@aadhar,@name,@dob,@gender,@course,@mobile,@email,@image,@state,@district)", con);
                con.Open();
                cmd1.Parameters.AddWithValue("@aadhar", TextBox5.Text);
                cmd1.Parameters.AddWithValue("@name", TextBox1.Text);
                cmd1.Parameters.AddWithValue("@dob", TextBox2.Text);
                cmd1.Parameters.AddWithValue("@gender", gender);
                cmd1.Parameters.AddWithValue("@course", DropDownList1.Text);
                cmd1.Parameters.AddWithValue("@mobile", TextBox3.Text);
                cmd1.Parameters.AddWithValue("@email", TextBox4.Text);
                cmd1.Parameters.AddWithValue("@image", pic);
                cmd1.Parameters.AddWithValue("@state", DropDownList2.Text);
                cmd1.Parameters.AddWithValue("@district", DropDownList3.Text);
                cmd1.Connection = con;
                cmd1.ExecuteNonQuery();
                con.Close();
                
                return true;
            }
            else
            {
                return false;
            }
        }
        bool DuplicateRecord()
        {
            String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select aadhar from register where aadhar='" + TextBox5.Text + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Label3.Text = "The aadhar number already exist";
                return false;
            }
            else
            {
                Label3.Text = "";
                return true;
            }
        }

        bool DuplicateRecord2()
        {
            String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select email from register where email='" + TextBox4.Text + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Label6.Text = "The email already exist";
                return false;
            }
            else
            {
                Label6.Text = "";
                return true;
            }
        }
        public bool btnUpload_Click()
        {
            if (FileUpload1.HasFile == true)
            {
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp"
                    || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                {
                    if (fileSize <= 51200)//50kb
                    {
                        Label2.Text = "";
                        return true;
                    }
                    else
                    {
                        Label2.Text = "File size exceeds 50kb";
                        return false;
                    }
                }
                else
                {
                    Label2.Text = "select .jpg,.png,.gif and .bmp images with 50kb size";
                    return false;
                }
            }
            else
            {
                Label2.Text = "No image selected";
                return false;
            }
        }
        void bindState()
        {

            //bind data of state to dropdownlist
            String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            String query = "select * from state";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "state_name";
            DropDownList2.DataValueField = "state_id";
            DropDownList2.DataBind();

            //at top sets ---select state----
            ListItem selectItem = new ListItem("----Select State----", "Select State");
            selectItem.Selected = true;
            DropDownList3.Items.Insert(0, selectItem);
        }

        void bindDistrict(int state_id)
        {
            //bind data of district to dropdownlist
            String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            String query = "select * from district where s_id = @state_id";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.Parameters.AddWithValue("@state_id", state_id);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "district_name";
            DropDownList3.DataValueField = "district_id";
            DropDownList3.DataBind();

            //at top sets ---select state----
            ListItem selectItem = new ListItem("-Select District-", "Select District");
            selectItem.Selected = true;
            DropDownList3.Items.Insert(0, selectItem);
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int state_id = Convert.ToInt32(DropDownList2.SelectedValue);
                bindDistrict(state_id);
                UpdatePanel2.Update();
                UpdatePanel1.Update();

            }
            catch (Exception ee)
            {
                Response.Write("<script>alert('state is required')</script>");
            }
        }
        // The id parameter name should match the DataKeyNames value set on the control
        //protected void Regist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    Regist.PageIndex = e.NewPageIndex;
        //    DataBind();
        //}

        //protected void Regist_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //select button in gidview
        //    if (e.CommandName == "Select")
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = Regist.Rows[index];
        //        string id = row.Cells[0].Text;
        //        string aadhar = row.Cells[1].Text;
        //        string name = row.Cells[2].Text;
        //        string dob = row.Cells[3].Text;
        //        string gender = row.Cells[4].Text;
        //        string course = row.Cells[5].Text;
        //        string mobile = row.Cells[6].Text;
        //        string email = row.Cells[7].Text;
        //        string city = row.Cells[8].Text;
        //        string district = row.Cells[9].Text;
        //        string imagePath = row.Cells[10].Text;


        //        // populate text boxes with data
        //        TextBox1.Text = name;
        //        TextBox2.Text = dob;
        //        TextBox3.Text = mobile;
        //        TextBox4.Text = email;
        //        TextBox5.Text = aadhar;
        //        Image1.ImageUrl = imagePath;
        //        if (gender == "Male")
        //        {
        //            RadioButton1.Checked = true;

        //        }
        //        else if (gender == "Female")
        //        {
        //            RadioButton2.Checked = true;

        //        }
        //        else if (gender == "Others")
        //        {
        //            RadioButton3.Checked = true;

        //        }
        //        DropDownList1.SelectedValue = course;
        //        DropDownList2.SelectedValue = city;
        //        DropDownList3.SelectedValue = district;
        //        //    // show delete and edit buttons
        //        Button2.Visible = true;
        //        Button3.Visible = true;
        //        Button1.Visible = false;
        //        Button4.Visible = true;
        //    }
        //}
        public static string GetShaData(string data)
        {
            // Create a new SHA1 object using the SHA1.Create() method.
            //Convert the input data to a byte array using the Encoding.Default.GetBytes() method.
            //Compute the hash of the data using the ComputeHash() method of the SHA1 object.
            //Convert the hash to a hexadecimal string using a StringBuilder.
            //Return the hexadecimal string representation of the hash.
            SHA1 sha = SHA1.Create();
            Byte[] hasData = sha.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder returnvalue = new StringBuilder();
            int i;
            for (i = 0; i < hasData.Length; i++)
            {
                returnvalue.Append(hasData[i].ToString());
            }
            return returnvalue.ToString();
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Session["useremail"] = Textname.Text;
            if (Textname.Text != "" && Textpass.Text != "")
            {
                String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                
                SqlCommand cmd1 = new SqlCommand("select * from LoginTable where email='" + Textname.Text + "' AND password='" + GetShaData(Textpass.Text) + "'", con);

                SqlDataAdapter sd = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                Label5.Text = "";
                if (dt.Rows.Count > 0)
                { 
                    Response.Redirect("LoginPage.aspx");
                    Label5.Text = "";
                    clearAllFields();
                }
                else
                {
                    Label5.Text = "The username or password are incorrect.Try Again.";

                }
            }
            else
            {
                Label5.Text = "Username and password not entered";
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clearAllFields();
        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    //delete button
        //    String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
        //    string aadhar = TextBox5.Text;

        //    using (SqlConnection conn = new SqlConnection(mycon))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand("delete from register where aadhar=@aadhar", conn))
        //        {
        //            cmd.Parameters.AddWithValue("@aadhar", aadhar);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    clearAllFields();
        //    Regist.DataBind();
        //    Button2.Visible = false;
        //    Button3.Visible = false;
        //    Button4.Visible = false;
        //    Button1.Visible = true;

        //}

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    //cancel button
        //    Button2.Visible = false;
        //    Button3.Visible = false;
        //    Button4.Visible = false;
        //    Button1.Visible = true;
        //    clearAllFields();
        //}

        //protected void Button5_Click(object sender, EventArgs e)
        //{
        //    //Search in gridview
        //    String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
        //    SqlConnection conn = new SqlConnection(mycon);
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    string query = "select * from register where name like '%'+@name+'%'";
        //    cmd.CommandText = query;
        //    cmd.Connection = conn;
        //    cmd.Parameters.AddWithValue("name", Textbox6.Text);
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    sda.Fill(dt);
        //    Regist.DataSource = dt;
        //    DataBind();
        //}


        //protected void Regist_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Delete")
        //    {
        //        String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
        //        int index = Convert.ToInt32(e.CommandArgument);
        //        int id = Convert.ToInt32(Regist.DataKeys[index].Value);

        //        if (Page.ClientScript.IsStartupScriptRegistered("confirm"))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "confirm", "confirmDelete();", true);
        //        }
        //        else
        //        {
        //            string confirmValue = Request.Form["confirm_value"];
        //            if (confirmValue == "Yes")
        //            {
        //                using (SqlConnection conn = new SqlConnection(mycon))
        //                {
        //                    conn.Open();
        //                    SqlCommand cmd = new SqlCommand("DELETE FROM tableName WHERE ID = @ID", conn);
        //                    cmd.Parameters.AddWithValue("@ID", id);
        //                    cmd.ExecuteNonQuery();
        //                    conn.Close();
        //                }
        //                Regist.DataBind();
        //            }
        //        }
        //    }
        //}
        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
        //    // Regist.DataKeyNames = new string[] { "id" };

        //    // Get the primary key value of the row being deleted
        //    //if (Regist.SelectedIndex >= 0)
        //    //{
        //    //int id = Convert.ToInt32(Regist.DataKeys[Regist.SelectedIndex].Value);
        //        string id =Regist.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();

        //        //int id=0;
        //        //GridViewRow selectedRow = Regist.SelectedRow;
        //        //if (selectedRow != null)
        //        //{
        //        //    string id1 = selectedRow.Cells[0].Text;
        //        //    id = Convert.ToInt32(id1);
        //        //}
        //        //GridViewRow row = Regist.SelectedRow;

        //        // Display a confirmation message before deleting the row
        //        string confirmValue = Request.Form["confirm_value"];
        //        if (confirmValue == "Yes")
        //        {
        //            // Create a SQL DELETE statement using the primary key value
        //            string deleteSQL = "DELETE FROM register WHERE id = @id";

        //            // Create a new SqlConnection and SqlCommand object
        //            using (SqlConnection conn = new SqlConnection(mycon))
        //            using (SqlCommand cmd = new SqlCommand(deleteSQL, conn))
        //            {
        //                // Add the primary key value as a parameter to the SQL DELETE statement
        //                cmd.Parameters.AddWithValue("@id", id);

        //                // Open the SqlConnection and execute the SqlCommand
        //                conn.Open();
        //                cmd.ExecuteNonQuery();
        //            }

        //            // Refresh the GridView
        //            Regist.DataBind();
        //        }
        //        else
        //        {
        //            e.Cancel = true;
        //        }
        //    //}
        //}


        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    // Show a confirmation message
        //    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "confirmDelete();", true);
        //}

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    // Get the id of the row to delete
        //    int id = Convert.ToInt32(Regist.DataKeys[e.RowIndex].Value);

        //    // Show a confirmation message
        //    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "confirmDelete('" + id + "');", true);
        //}
        //private void DeleteRowFromSqlExpressDataSource(int id)
        //{
        //   String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";

        //    using (SqlConnection con = new SqlConnection(mycon))
        //    {
        //        con.Open();
        //        using (SqlCommand cmd = new SqlCommand("DELETE FROM register WHERE id = @id", con))
        //        {
        //            cmd.Parameters.AddWithValue("@id", id);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    // Rebind the GridView to reflect the changes
        //    Regist.DataBind();
        //}


        //protected void deletebutton_Click(string Aadhar)
        //{
        //    //String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
        //    //SqlConnection con = new SqlConnection(mycon);
        //    //int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
        //    //string aadharno = Convert.ToString(Regist.Rows[rowindex].Cells[1].Text);
        //    //con.Open();
        //    
        //    //SqlCommand cmd1 = new SqlCommand("Delete register where aadhar='" + aadharno + "'", con);
        //    //cmd1.ExecuteNonQuery();
        //    //con.Close();
        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully deleted');", true);
        //    //bindingdata();
        //    String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";

        //    using (SqlConnection con=new SqlConnection(mycon))
        //    {
        //        string query="delete from register where aadhar="+Aadhar+"";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        con.Open();
        //        cmd.ExecuteNonQuery();

        //    }
        //}

        //private void bindingdata()
        //{
        //    String mycon = "Data source=DESKTOP-EL3JA64\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
        //    using (SqlConnection con = new SqlConnection(mycon))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("select * from register"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                using (DataTable dt = new DataTable())
        //                {
        //                    sda.Fill(dt);
        //                    Regist.DataSource = dt;
        //                    Regist.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}
        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    Regist.EditIndex = e.NewEditIndex;
        //    this.bindingdata();
        //}
        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string item = e.Row.Cells[0].Text;
        //        foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
        //        {
        //            if (button.CommandName == "Delete")
        //            {
        //                button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
        //            }
        //        }
        //    }
        //}
        //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.RowIndex);
        //    DataTable dt = ViewState["dt"] as DataTable;
        //    dt.Rows[index].Delete();
        //    ViewState["dt"] = dt;
        //    bindingdata();
        //}
    }

}
