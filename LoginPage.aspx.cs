using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using BotDetect;
using System.Globalization;

namespace WebApplication1
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                bindState();
                
                TextBox10.Text = Session["useremail"].ToString();

                TextBox1.ReadOnly = true;
                TextBox2.ReadOnly = true;
                DropDownList1.Enabled = false;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                DropDownList4.Enabled = false;
                TextBox7.ReadOnly = true;
                TextBox8.ReadOnly = true;

                String email = Session["useremail"].ToString();
                String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM register WHERE email=@Email", con);

                cmd1.Parameters.AddWithValue("@Email", email);
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Retrieve the data from the reader and assign it to variables
                        string name = reader["name"].ToString();
                        DateTime dob = Convert.ToDateTime(reader["dob"]);
                        string gender = reader["gender"].ToString();
                        string course = reader["course"].ToString();
                        string mobile = reader["mobile"].ToString();
                        string state = reader["state"].ToString();
                        string district = reader["district"].ToString();
                        string aadhar = reader["aadhar"].ToString();
                        byte[] imageBytes = (byte[])reader["image"];
                        
                        int state_id;
                        int.TryParse(state, out state_id);
                        bindDistrict(state_id);

                        // Convert the byte array to a base64 string
                        string base64Image = Convert.ToBase64String(imageBytes);

                        // Construct the data URI scheme for the image
                        string imageUrl = "data:image/jpeg;base64," + base64Image;
                        // Populate the retrieved data into the textboxes
                        TextBox1.Text = name;
                        TextBox2.Text = dob.ToShortDateString();
                        DropDownList1.SelectedValue = course;
                        DropDownList2.SelectedValue = gender;

                        TextBox7.Text = mobile;
                        TextBox8.Text = aadhar;

                        reader.Close(); // Close the reader before executing the next queries

                        SqlCommand cmd2 = new SqlCommand("SELECT state_name FROM state WHERE state_id=@state", con);
                        cmd2.Parameters.AddWithValue("@state", state);
                        
                        using (SqlDataReader reader1 = cmd2.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                string state1 = reader1["state_name"].ToString();
                                DropDownList3.SelectedValue = state;
                                
                                reader1.Close();
                            }

                            SqlCommand cmd3 = new SqlCommand("SELECT district_name FROM district WHERE district_id=@district AND s_id=@state", con);
                            cmd3.Parameters.AddWithValue("@district", district);
                            cmd3.Parameters.AddWithValue("@state", state);
                            using (SqlDataReader reader2 = cmd3.ExecuteReader())
                            {
                                if (reader2.Read())
                                {
                                    string district1 = reader2["district_name"].ToString();
                                    DropDownList4.SelectedValue= district;
                                    
                                }
                                reader2.Close();
                            }

                            // Set the ImageUrl to display the image
                            Image4.ImageUrl = imageUrl;

                        }
                    }

                    Button3.Visible = false;
                    Button4.Visible = false;
                    Calendar1.Visible = false;
                }
            }
        }

            protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            uploadSection.Visible = true;
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;

            DropDownList1.Enabled = true;

            DropDownList2.Enabled = true;
            DropDownList3.Enabled = true;
            DropDownList4.Enabled = true;
            TextBox7.ReadOnly = false;

            
            ImageButton2.Visible = true;

            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = true;
            Button4.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Perform the deletion
            Label1.Text = "";
            string email = Session["useremail"].ToString();
            string mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data; Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM register WHERE email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            SqlCommand cmd1 = new SqlCommand("DELETE FROM LoginTable WHERE email = @Email", con);
            cmd1.Parameters.AddWithValue("@Email", email);
            con.Close();
            Response.Redirect("SignInUpPage.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Get the modified values from the text boxes
            string email = Session["useremail"].ToString();
            string mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data; Integrated Security=true";

            SqlConnection con = new SqlConnection(mycon);
            con.Open();

            // Check if a file is uploaded and its format and size are valid
            bool isImageUploaded = FileUpload1.HasFile && btnUpload_Click();

            // Update the profile information and image
            SqlCommand cmd = new SqlCommand("UPDATE register SET dob = @DOB, course = @Course, gender = @Gender, state = @State, district = @District, mobile = @MobileNo, image = @Image WHERE email = @Email", con);
            cmd.Parameters.AddWithValue("@DOB", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Course", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@Gender", DropDownList2.Text);
            cmd.Parameters.AddWithValue("@State", DropDownList3.Text);
            cmd.Parameters.AddWithValue("@District", DropDownList4.Text);
            cmd.Parameters.AddWithValue("@MobileNo", TextBox7.Text);
            cmd.Parameters.AddWithValue("@Email", email);

            byte[] imageBytes = null; // Declare the variable with a default value

            if (isImageUploaded)
            {
                // If image is uploaded, save it to the database
                using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    imageBytes = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                }
                cmd.Parameters.AddWithValue("@Image", imageBytes);
            }
            else
            {
                // If no image is uploaded, set the image column to its current value
                cmd.Parameters.AddWithValue("@Image", GetProfileImage(email));
            }

            int rowsAffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowsAffected > 0)
            {
                Label1.Text = "Updation complete";

                if (isImageUploaded && imageBytes != null) // Check if imageBytes is not null
                {
                    // Update the profile image
                    string base64Image = Convert.ToBase64String(imageBytes);
                    string imageUrl = "data:image/jpeg;base64," + base64Image;
                    Image4.ImageUrl = imageUrl;
                }
            }
            else
            {
                Label1.Text = "Updation failed";
            }

            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            DropDownList1.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            TextBox7.ReadOnly = true;

            Calendar1.Visible = false;
            ImageButton2.Visible = false;

            uploadSection.Visible = false;
            Button1.Visible = true;
            Button2.Visible = true;
            Button3.Visible = false;
            Button4.Visible = false;
        }

        private byte[] GetProfileImage(string email)
        {
            string mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data; Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT image FROM register WHERE email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
            byte[] imageBytes = (byte[])cmd.ExecuteScalar();
            con.Close();
            return imageBytes;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            TextBox10.Text = Session["useremail"].ToString();
            TextBox1.ReadOnly = true;
            TextBox2.ReadOnly = true;
            DropDownList1.Enabled = false;
            DropDownList2.Enabled = false;
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            TextBox7.ReadOnly = true;
            TextBox8.ReadOnly = true;

            String email = Session["useremail"].ToString();
            String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from register where email=@email", con);
            cmd1.Parameters.AddWithValue("@Email", email);
            using (SqlDataReader reader = cmd1.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Retrieve the data from the reader and assign it to variables
                    string name = reader["name"].ToString();
                    DateTime dob = Convert.ToDateTime(reader["dob"]);
                    string gender = reader["gender"].ToString();
                    string course = reader["course"].ToString();
                    string mobile = reader["mobile"].ToString();
                    string state = reader["state"].ToString();
                    string district = reader["district"].ToString();
                    string aadhar = reader["aadhar"].ToString();
                    byte[] imageBytes = (byte[])reader["image"];

                    // Convert the byte array to a base64 string
                    string base64Image = Convert.ToBase64String(imageBytes);

                    // Construct the data URI scheme for the image
                    string imageUrl = "data:image/jpeg;base64," + base64Image;
                    // Populate the retrieved data into the textboxes
                    TextBox1.Text = name;
                    TextBox2.Text = dob.ToShortDateString();
                    DropDownList1.SelectedValue = course;
                    DropDownList2.SelectedValue = gender;
                    DropDownList3.SelectedValue = state;
                    DropDownList4.SelectedValue = district;
                    TextBox7.Text = mobile;
                    TextBox8.Text = aadhar;

                    // Set the ImageUrl to display the image
                    Image4.ImageUrl = imageUrl;
                }
            }
            uploadSection.Visible = false;
            Label1.Text = "";
            Button1.Visible = true;
            Button2.Visible = true;
            Button3.Visible = false;
            Button4.Visible = false;

            Calendar1.Visible = false;
            ImageButton2.Visible = false;
            
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session["useremail"] = "";
            Response.Redirect("SignInUpPage.aspx");
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

        void bindState()
        {
            //bind data of state to dropdownlist
            String mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data;Integrated Security=true";
            SqlConnection con = new SqlConnection(mycon);
            String query = "select * from state";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "state_name";
            DropDownList3.DataValueField = "state_id";
            DropDownList3.DataBind();

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
            DropDownList4.DataSource = dt;
            DropDownList4.DataTextField = "district_name";
            DropDownList4.DataValueField = "district_id";
            DropDownList4.DataBind();

            //at top sets ---select state----
            ListItem selectItem = new ListItem("-Select District-", "Select District");
            selectItem.Selected = true;
            DropDownList4.Items.Insert(0, selectItem);
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
