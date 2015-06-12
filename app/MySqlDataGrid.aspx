<%@ Page language="c#" Codebehind="MySqlDataGrid.aspx.cs" AutoEventWireup="false" Inherits="Speech.MySqlDataGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
	</HEAD>
	<body>
		<P>
		<form runat="server"> 
			<TABLE id="Table1" height="176" cellSpacing="1" cellPadding="1" width="344" border="0">
				<TR>
					<TD bgColor="#cccc99"></TD>
				</TR>
				<TR>
					<TD bgColor="gainsboro">
						<TABLE id="HtmlTable1" style="BORDER-COLLAPSE: collapse" cellSpacing="0" cellPadding="3"
							rules="all" align="center" bgColor="gainsboro" border="1" runat="server">
							<TR style="BACKGROUND-COLOR: #f7f7f7">
								<TD bgColor="gainsboro">Name</TD>
								<TD bgColor="gainsboro">Address</TD>
								<TD bgColor="gainsboro">&nbsp;</TD>
							</TR>
							<TR>
								<TD width="100">
									<asp:TextBox id="TextBox3" runat="server"></asp:TextBox></TD>
								<TD width="100">
									<asp:TextBox id="TextBox4" runat="server"></asp:TextBox></TD>
								<TD>
									<asp:Button id="btn_add" runat="server" Text="Add" BorderStyle="None"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="DataGrid1" Runat="server" DataKeyField="ID" AutoGenerateColumns="False" EditItemStyle-BackColor="#F7F7F7"
							HeaderStyle-BackColor="#F7F7F7" CellPadding="3" HorizontalAlign="Center">
							<FooterStyle BackColor="PaleGoldenrod"></FooterStyle>
							<SelectedItemStyle BackColor="Control"></SelectedItemStyle>
							<EditItemStyle BackColor="#F7F7F7"></EditItemStyle>
							<ItemStyle BackColor="White"></ItemStyle>
							<HeaderStyle BackColor="DarkKhaki"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="ID">
									<HeaderStyle Width="30px"></HeaderStyle>
									<ItemTemplate>
										<asp:Literal ID="Label" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' Runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Name">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "name") %>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="TextBox1" Text='<%# DataBinder.Eval(Container.DataItem, "name") %>' CssClass="stdInput" Runat="server" />
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Address">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "address") %>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="Textbox2" Text='<%# DataBinder.Eval(Container.DataItem, "address") %>' CssClass="stdInput" Runat="server" />
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD bgColor="gainsboro">
						<TABLE id="HtmlTable2" style="BORDER-COLLAPSE: collapse" cellSpacing="0" cellPadding="3"
							rules="all" align="center" bgColor="#ffcc99" border="1" runat="server" Visible="False">
							<TR>
								<TD width="234" bgColor="#cccc33">Errors</TD>
							</TR>
							<TR>
								<TD>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator1" Runat="server" ErrorMessage="*First Name* is a required field"
										EnableClientScript="False" Display="None" ControlToValidate="Textbox3" ForeColor="RosyBrown"></asp:RequiredFieldValidator>
									<asp:RequiredFieldValidator id="Requiredfieldvalidator2" Runat="server" ErrorMessage="*Last Name* is a required field"
										EnableClientScript="False" Display="None" ControlToValidate="Textbox4" ForeColor="RosyBrown"></asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator id="Regularexpressionvalidator1" Runat="server" ErrorMessage="*First Name* contains illegal values"
										EnableClientScript="False" Display="None" ControlToValidate="Textbox3" ForeColor="RosyBrown" ValidationExpression="[\w\s]{1,255}"></asp:RegularExpressionValidator>
									<asp:RegularExpressionValidator id="Regularexpressionvalidator2" Runat="server" ErrorMessage="*Last Name* contains illegal values"
										EnableClientScript="False" Display="None" ControlToValidate="Textbox4" ForeColor="RosyBrown" ValidationExpression="[\w\s]{1,255}"></asp:RegularExpressionValidator>
									<asp:ValidationSummary id="ValidationSummary1" Runat="server" ForeColor="RosyBrown" ShowSummary="True"
										DisplayMode="List"></asp:ValidationSummary></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</form>
		</P>
	</body>
</HTML>
