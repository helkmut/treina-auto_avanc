using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.Odbc;

namespace Speech
{
	/// <summary>
	/// Summary description for MySqlDataGrid.
	/// </summary>
	public class MySqlDataGrid : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btn_add;
		protected System.Web.UI.HtmlControls.HtmlTable HtmlTable1;
		protected System.Web.UI.HtmlControls.HtmlTable HtmlTable2;


		private const string ConnStr = "Driver={MySQL ODBC 3.51 Driver};Server=treina-auto_avanc-db-dev;Database=test;uid=root;pwd=bela;option=3";
		string strSort;
		string strerrorMsg;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		string strscriptString;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if (!IsPostBack) 
			{
				if (strSort == "") 
				{
					strSort = "IntegerValue";
				}    
				BindDataGrid();
			}    
		}


		private void BindDataGrid()
		{
			using(OdbcConnection con = new OdbcConnection(ConnStr))
			using(OdbcCommand cmd = new OdbcCommand("SELECT * FROM Sample", con))
			{
				con.Open();
				DataGrid1.DataSource = cmd.ExecuteReader(
					CommandBehavior.CloseConnection | 
					CommandBehavior.SingleResult);
				DataGrid1.DataBind();
			}
		}
	
		private void InsertInfo()
		{
			if(CheckIsAddNameValid())
			{
				HtmlTable2.Visible = false;

				using(OdbcConnection con = new OdbcConnection(ConnStr))
				using(OdbcCommand cmd = new OdbcCommand("INSERT INTO sample(name, address) VALUES (?,?)", con))
				{
					cmd.Parameters.Add("@name", OdbcType.VarChar, 255).Value = TextBox3.Text.Trim();
					cmd. Parameters.Add("@address", OdbcType.VarChar, 255).Value = TextBox4.Text.Trim();
				
					con.Open();
					cmd.ExecuteNonQuery();
					BindDataGrid();
				}
			}
		}
	
		private void UpdateInfo(int id, string name, string address)
		{
			using(OdbcConnection con = new OdbcConnection(ConnStr))
			using(OdbcCommand cmd = new OdbcCommand("UPDATE sample SET name = ?, address = ? WHERE ID = ?", con))
			{
				cmd.Parameters.Add("@name", OdbcType.VarChar, 255).Value = name;
				cmd.Parameters.Add("@address", OdbcType.VarChar, 255).Value = address;
				cmd.Parameters.Add("@ID", OdbcType.Int).Value = id;
			
				con.Open();
				cmd.ExecuteNonQuery();
			}
		}

		private void DeleteInfo(int id)
		{
			using(OdbcConnection con = new OdbcConnection(ConnStr))
			using(OdbcCommand cmd = new OdbcCommand("DELETE FROM sample WHERE ID = ?", con))
			{
				cmd.Parameters.Add("@ID", OdbcType.Int).Value = id;
			
				con.Open();
				cmd.ExecuteNonQuery();
			}
		}

		private bool CheckIsAddNameValid()
		{
			HtmlTable2.Visible = true;

			Requiredfieldvalidator1.Validate();
			Requiredfieldvalidator2.Validate();
			Regularexpressionvalidator1.Validate();
			Regularexpressionvalidator2.Validate();
		
			return (Requiredfieldvalidator1.IsValid && 
				Requiredfieldvalidator2.IsValid && 
				Regularexpressionvalidator1.IsValid && 
				Regularexpressionvalidator2.IsValid);
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		
		}

		private void btn_add_Click(object sender, System.EventArgs e)
		{
			InsertInfo();
		}

		
		private void Textbox4_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = (int)e.Item.ItemIndex;
			BindDataGrid();
		}

		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{

				int cUsrID ;
				string strName;
				string strAddress;

				Literal ltID;
				TextBox txtTempName;
				TextBox txtTempAddress;

				ltID = (System.Web.UI.WebControls.Literal ) e.Item.Cells[0].FindControl("Label");
				cUsrID = Convert.ToInt32 (ltID.Text);

				txtTempName = (System.Web.UI.WebControls.TextBox)e.Item.Cells[1].FindControl("TextBox1");
				strName = txtTempName.Text;

				txtTempAddress = (System.Web.UI.WebControls.TextBox) e.Item.Cells[2].FindControl("Textbox2");
				strAddress = txtTempAddress.Text;
			
				UpdateInfo(cUsrID, strName, strAddress);

				DataGrid1.EditItemIndex = -1;
				BindDataGrid();
			}
			catch(Exception ex)
			{
				strerrorMsg = ex.Message.Replace("'", @"""");
				strscriptString = "<script language = Javascript>";
				strscriptString += "window.status = '" + strerrorMsg + "';";
				strscriptString += "</script>";
				RegisterStartupScript("clientScript", strscriptString);
			}
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				int cID;
				Literal  ltID = null;
				string ss = string.Empty; 

				ltID = (System.Web.UI.WebControls.Literal ) e.Item.Cells[0].FindControl("Label");
				cID = Convert.ToInt32 (ltID.Text);

				DeleteInfo(cID);

				BindDataGrid();
				
			}
			catch(Exception ex)
			{
				strerrorMsg = ex.Message.Replace("'", @"""");
				strscriptString = "<script language = Javascript>";
				strscriptString += "window.status = '" + strerrorMsg + "';";
				strscriptString += "</script>";
				RegisterStartupScript("clientScript", strscriptString);
			}
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;
			BindDataGrid();
		}
	}
}
