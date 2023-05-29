using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class PasswordGeneration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Session["email"].ToString();
           // TextBox1.Text="ayashukothiyal@gmail.com";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["passgen"] = "Your new password is generated. Login with your credentials";

            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                string pass = GetShaData(TextBox2.Text);
                string mycon = "Data source=DESKTOP-G4DVJQG\\SQLEXPRESS; Initial Catalog=Data; Integrated Security=true";
                SqlConnection con = new SqlConnection(mycon);

                SqlCommand cmd1 = new SqlCommand("INSERT INTO LoginTable (email, password) VALUES (@email, @password)", con);
                cmd1.Parameters.AddWithValue("@email", TextBox1.Text);
                cmd1.Parameters.AddWithValue("@password", pass);

                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();

                Response.Redirect("SignInUpPage.aspx");
            }
        }


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

    }
}
