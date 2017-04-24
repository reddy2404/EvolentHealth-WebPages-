using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace EvolveHealth
{
    
    public partial class EvolveHealthCrud : System.Web.UI.Page
    {

        #region PageLoad Events and Load Grid
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();

        }

        //Load Grid 
        private void LoadGrid()
        {
            dbHelper data = new dbHelper();
            GridView1.DataSource = data.GetResultList();
            GridView1.DataBind();
        }
        #endregion

        #region Clear TextFields and Error Field
        //Clear TextFields
        protected void ClearTextFields()
        {
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
        
        //Clear Error fields
        protected void ClearError()
        {
            lblError.Text = "";
        }
       
#endregion
       
        #region Delete record
        //Delete record

        protected  void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //Label lbldeleteid = (Label)row.FindControl("ID");
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
           // int ID = Convert.ToInt32(lbldeleteid);
            dbHelper data = new dbHelper();
            try
            {
               Boolean result=   data.DeleteData(ID);
               LoadGrid();
                if(result==true)
                {
                    lblError.Text = "Row Deleted successfully";
                }
                else
                {
                    lblError.Text = "Deleting row failed";
                }
           
            }catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
          

        }
#endregion

        #region Update Existing Record
        //Update Existing Record
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadGrid();
          

        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
           //GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            GridViewRow row = GridView1.Rows[e.RowIndex];
           
            string FName = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string LName = ((TextBox)(row.Cells[2].Controls[0])).Text;
            string Email = ((TextBox)(row.Cells[3].Controls[0])).Text;
            string PhoneNumber = ((TextBox)(row.Cells[4].Controls[0])).Text;
            string StatusId = ((TextBox)(row.Cells[5].Controls[0])).Text;


            //check for validations
            if ((AlphaString(FName) && AlphaString(LName))==true &&  (FName!=string.Empty & LName!=string.Empty ))
            {
                //email
                if (EmailValidation(Email.Trim()))
                {
                    lblError.Text = string.Empty;
                }
                else
                {
                    lblError.Text = "Please provide a valid email address";
                    lblError.ForeColor = System.Drawing.Color.Red;
                     return;
                }  
                //phone

                if (PhoneNumberValidation(PhoneNumber.Trim()))
                {
                    lblError.Text = string.Empty;
                }
                else
                {
                    lblError.Text = "Please provide a valid phone Number";
                    lblError.ForeColor = System.Drawing.Color.Red;
                     return;
                } 
                //status

                if (StatusId == "True"|| StatusId =="False")
                {

                }else{
                    lblError.Text = "Enter either true or false";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;

                }

            }
            else
            {
                lblError.Text = "valid First and Last Names are required";
                lblError.ForeColor = System.Drawing.Color.Red;
                 return;
            }
            //end of validations
             Boolean blnstatus = false;
             if (StatusId == "true")
            {
                blnstatus = true;

            }
            
           
            GridView1.EditIndex = -1;

            try
            {
                dbHelper data = new dbHelper();
              int Result =  data.UpdateData(ID, FName, LName, PhoneNumber, Email, blnstatus);

                if (Result==1)
                {
                    lblError.Text = "Successfull update";
                }else
                {
                    lblError.Text = "update Failed";
                }
               
                LoadGrid();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        //email validation
        private bool EmailValidation(string emailId)
        {
            return Regex.IsMatch
            (
               emailId,
               @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
               RegexOptions.IgnoreCase
            );
        } 
        //Phone number validation
        private bool PhoneNumberValidation( string Number)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
          var isvalid=r.IsMatch(Number);

            if (isvalid)
            {
                return true;
            }else
            {
                return false;
            }
        }

        //validation for first and last names
        public Boolean AlphaString(string s)
    {
        Regex r = new Regex(@"^[a-zA-Z]+$");
        if (r.IsMatch(s))
        {
            return true;               
        }
        else
        {
            return false;
        }
    }
        #endregion

        #region Insert New Record
        //Insert new record
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ClearError();
            ClearTextFields();
            pnlNewRecord.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            pnlNewRecord.Visible = true;

        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string FName = txtFName.Text;
            string LName = txtLName.Text;
            string Phone = txtPhone.Text;
            string Email = txtEmail.Text;
            string status = ddlStatus.SelectedItem.Text;

            Boolean blnStatus = Boolean.Parse(status);

            dbHelper data = new dbHelper();
            int Result = data.InsertData(FName, LName, Phone, Email, blnStatus);

            if (Result == 1)
            {
                lblError.Text = "Data Inserted Successfully";
            }
            else
            {
                lblError.Text = "Inserting Data  Failed";
            }

            LoadGrid();
            ClearTextFields();
            pnlNewRecord.Visible = false;
        }

        #endregion

  
    }
}
   