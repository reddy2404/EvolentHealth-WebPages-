<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvolveHealthCrud.aspx.cs" Inherits="EvolveHealth.EvolveHealthCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 185px">
    <form id="form1" runat="server" style="align-content:center ;padding-top:60px; padding-left:150px;" >
        <asp:Panel ID="pnlCrud" runat="server" BorderStyle="Double" width="802px"  style="background-color:aliceblue;align-content:center;">
            <table style="width:800px; padding-top: 35px;">
                <tr>
                    <th style="font-family:'Times New Roman'; font-size:medium; color:red ">
                        Basic CRUD operation s using webforms and stored procedures
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="padding-left:40px;">

                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" EnableViewState="False"
                            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />                                
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:CommandField ShowEditButton="true" />
                                <asp:CommandField ShowDeleteButton="true" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>


            <asp:Panel ID="pnlNewRecord" runat="server" Width="672px" Visible="false">
                <table>
                    <tr>

                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtFName" runat="server" Width="79px" placeholder="FirstName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="revFName" ControlToValidate="txtFName" runat="server" ErrorMessage="Field required" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>

                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtLName" runat="server" Width="77px" placeholder="LastName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="revLName" ControlToValidate="txtLName" runat="server" ErrorMessage="Field required" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>

                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" Width="83px" placeholder="xxxxxx@xx.xxx"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Inval id"
                                            ControlToValidate="txtEmail" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"> </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtPhone" runat="server" Width="78px" placeholder="xxx-xxx-xxxx"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="revPhone" runat="server"
                                            ErrorMessage="Invalid Number" ControlToValidate="txtPhone" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                            <asp:ListItem>True</asp:ListItem>
                                            <asp:ListItem>False</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>

                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click " ValidationGroup="insert" />
                        </td>

                    </tr>
                </table>
            </asp:Panel>
            <table>
                <tr>

                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add New Record" OnClick="btnAdd_Click" />
                    </td>

                    <td>
                        <asp:Button ID="btnNew" runat="server" Text="Clear Text Fields" OnClick="btnNew_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
