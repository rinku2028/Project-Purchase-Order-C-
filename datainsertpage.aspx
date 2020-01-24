<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="datainsertpage.aspx.cs" Inherits="datainsert.datainsertpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 23px;
            width: 417px;
        }
        .auto-style3 {
            width: 87px;
        }
        .auto-style4 {
            width: 417px;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
       
        <table>
            <tr>
                <td class="auto-style3">Part Number</td>
               
                <td class="auto-style4"><asp:TextBox ID="txtpartnum" runat="server" ></asp:TextBox></td>
                <td>
                <asp:RequiredFieldValidator ID="rfpartnum" runat="server" ErrorMessage="Please input partnumber!" ControlToValidate="txtpartnum" ForeColor="Red" validationGroup="valgp" Enabled="true"></asp:RequiredFieldValidator></td>
                <td></td>
               
            </tr>
            <tr>
                <td class="auto-style3">Particulars</td>
                <td class="auto-style4"><asp:TextBox ID="txtparticulars" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please input particulars name!" ControlToValidate="txtparticulars" ForeColor="Red" ValidationGroup="valgp" Enabled="true"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style3">Quantity</td>
                <td class="auto-style4"><asp:TextBox ID="txtqunatity" runat="server"></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please input quantity" ControlToValidate="txtqunatity" ForeColor="Red" ValidationGroup="valgp" Enabled="true"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style3">Unit Price</td>
                <td class="auto-style4"><asp:TextBox ID="txtunitprice" runat="server" OnTextChanged="txtunitprice_TextChanged"></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please input price" ControlToValidate="txtunitprice" ForeColor="Red" ValidationGroup="valgp" Enabled="true"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style3">Total Price</td>
                <td class="auto-style4"><asp:TextBox ID="txttotalprice" runat="server" Enabled="False"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please input totalprice" ControlToValidate="txttotalprice" ForeColor="Red" ValidationGroup="valgp" Enabled="true"></asp:RequiredFieldValidator></td>
             </tr>
            <tr>
                <td class="auto-style3">Order Date</td>
               <td class="auto-style4"><asp:TextBox ID="txtdate" runat="server" OnTextChanged="txtdate_TextChanged"></asp:TextBox></td>
               <td><!--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please input date!" ControlToValidate="txtdate" ForeColor="Red"></asp:RequiredFieldValidator>--></td>

            </tr>
            <tr>
                 <td>
                  <asp:Button ID="btnValidate" runat="server" Text="ValidateDate" OnClick="btnValidate_Click" />
               
                    <td class="auto-style2"> <asp:Button ID="btnsave" runat="server" Text="SAVE" OnClick="btnsave_Click"/>
                        <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click" /><asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click" />
                        <asp:Button ID="btnrefresh" runat="server" Text="Refresh"  OnClick="btnrefresh_Click"/>
                        <asp:Button ID="btnView" runat="server" Text="View Details" OnClick="btnView_Click" />
                 </td>
                 </td>
                <td>&nbsp;</td>
                </tr>
            <tr>
                 <td class="auto-style3"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="gdview" runat="server"  AutoGenerateColumns="False" AutoGenerateEditButton="True" AllowPaging="True" OnPageIndexChanging="gdview_PageIndexChanging">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"  />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="partnumber" HeaderText="PARTNUMBER" />
                    <asp:BoundField DataField="tranparticular" HeaderText="TRANPARTICULAR" />
                    <asp:BoundField DataField="quantity" HeaderText="QUANTITY" />
                    <asp:BoundField DataField="unitprice" HeaderText="UNITPRICE"/>
                    <asp:BoundField DataField="totalprice" HeaderText="TOTALPRICE"/>
                    <asp:BoundField DataField="orderdate" HeaderText="ORDERDATE" />

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>