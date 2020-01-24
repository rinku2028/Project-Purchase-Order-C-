using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;

namespace datainsert
{
    public partial class datainsertpage : System.Web.UI.Page
    {
        SqlConnection sqlconn = new SqlConnection("Data Source=desktop-tb3r1mj;Initial Catalog=access;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtdate.Text == "")
            {
                lblMessage.Text = "Must entered date";
                txtdate.Focus();
            }
            else
            {
                try
                {
                    sqlconn.Open();
                    lblMessage.Text = "Database connected";
                    string sql = @"insert into ordermaster(partnumber,tranparticular,quantity,unitprice,totalprice,orderdate) values
                 ('" + txtpartnum.Text + "','" + txtparticulars.Text + "','" + txtqunatity.Text + "','" + txtunitprice.Text + "','" + txttotalprice.Text + "','" + txtdate.Text + "')";

                    SqlCommand sqlcommand = new SqlCommand(sql, sqlconn);
                    sqlcommand.CommandType = System.Data.CommandType.Text;
                    sqlcommand.ExecuteNonQuery();
                    lblMessage.Text = "Data inserted successfully!!";
                    sqlconn.Close();


                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Database not connected";
                }
            }
        }

        protected void txtunitprice_TextChanged(object sender, EventArgs e)
        {
            txttotalprice.Text = Convert.ToString(Convert.ToInt32(txtqunatity.Text) * (Convert.ToInt32(txtunitprice.Text)));
        }


        //For checking date format in date textbox
        protected void txtdate_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            //Verify whether date entered in dd/MM/yyyy format.
            bool isValid = regex.IsMatch(txtdate.Text.Trim());

            //Verify whether entered date is Valid date.
            DateTime dt;
            isValid = DateTime.TryParseExact(txtdate.Text, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (!isValid)
            {
                lblMessage.Text = "Please put correct date format dd/MM/yyyy";
            }
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            //Date format (dd/MM/yyyy) validation using Regular Expression in C#
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            //Verify whether date entered in dd/MM/yyyy format.
            bool isValid = regex.IsMatch(txtdate.Text.Trim());

            //Verify whether entered date is Valid date.
            DateTime dt;
            isValid = DateTime.TryParseExact(txtdate.Text, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (!isValid)
            {
                lblMessage.Text = "Please put correct date format dd/MM/yyyy";
            }

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //DateTime dt = new DateTime
            // string dataconn = "Data Source=it15;Initial Catalog=access;Integrated Security=True";
            //  SqlConnection sqlconn = new SqlConnection(dataconn);
            sqlconn.Open();
            string sql = @"update ordermaster set tranparticular='" + txtparticulars.Text + "',quantity='" + txtqunatity.Text + "',unitprice='" + txtunitprice.Text + "',totalprice='" + txttotalprice.Text + "',orderdate='" + Convert.ToDateTime(txtdate.Text).ToString("dd/MM/yyyy") + "'  where partnumber='" + txtpartnum.Text + "'";
            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.ExecuteNonQuery();
            sqlconn.Close();
            lblMessage.Text = "Data updated successfully";

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            //  string dataconn = "Data Source=it15;Initial Catalog=access;Integrated Security=True";
            //  SqlConnection sqlconn = new SqlConnection(dataconn);
            sqlconn.Open();
            string sql = @"delete from ordermaster where partnumber='" + txtpartnum.Text + "'";
            SqlCommand sqlcommand = new SqlCommand(sql, sqlconn);
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.ExecuteNonQuery();
            sqlconn.Close();
            lblMessage.Text = "Data deleted successfully";


        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            //rfpartnum.Enabled = false;

            sqlconn.Open();
            string sql = "select id,partnumber,tranparticular,quantity,unitprice,totalprice,convert(varchar,orderdate,101)as ORDERDATE from ordermaster order by id";
            SqlDataAdapter sqldata = new SqlDataAdapter();
            SqlCommand sqlcmd = new SqlCommand(sql, sqlconn);
            sqldata.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqldata.Fill(dt);
            gdview.DataSource = dt;
            gdview.DataBind();
        }

        protected void gdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdview.PageIndex = e.NewPageIndex;
            this.DataBind();
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            txtpartnum.Text = "";
            txtparticulars.Text = "";
            txtqunatity.Text = "";
            txtunitprice.Text = "";
            txttotalprice.Text = "";
            txtdate.Text = "";
        }
    }
}
