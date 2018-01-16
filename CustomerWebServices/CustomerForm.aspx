<%@ Page Language="C#" title="Cory Larick - MoveHQ Test" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="CustomerWebServices.CustomerForm" %>

<!DOCTYPE html>

<!-- Partial Page post back with asp.net ajax calls -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <script type="text/javascript" lang="Javascript">
        function GetCustomerByID() {
            var id = document.getElementById("txtCustomerID").value;
            CustomerWebServices.Customer1.GetCustomerByID(id, GetCustomerByIdSuccessCallback, GetCustomerByIdFailedCallback);

        }

        function GetCustomerByIdSuccessCallback(results) {
            document.getElementById("txtFirstName").value = results["FirstName"];
            document.getElementById("txtLastName").value = results["LastName"];
            document.getElementById("txtPhone").value = results["Phone"];
            document.getElementById("txtEmail").value = results["Email"];
        }

        function GetCustomerByIdFailedCallback(errors) {
            alert(errors.get_message());
        }
    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/Customer.asmx" />
            </Services>
        </asp:ScriptManager>
        <br />
        <br />
        <br />
        <asp:GridView ID="gvCustomer" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">

            <AlternatingRowStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <br />
        <table style ="font-family: Arial; border: 1px solid black; margin-top: 0px;">
            <tr>
                <td>
                    <b>ID</b>
                </td>
                <td>
                    <asp:TextBox ID ="txtCustomerID" runat="server"></asp:TextBox>
                    <input id="Button1" type="button" onclick="GetCustomerByID()" value="Get Customer by ID"/>
                </td>
            </tr>
            <tr>
                <td>
                    <b>FirstName</b>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>LastName</b>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" Width="52px" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Phone</b>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    <asp:Button ID="btnDelet" runat="server" OnClick="btnDelet_Click" Text="Delete" Width="48px" />
                </td>
            </tr>
            <tr>
                <td>
                    <b>Email</b>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" />
                </td>
            </tr>
        </table>
        <p>
                    <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="#CC6600"></asp:Label>
                </p>

        <h2>About</h2>
        <p>Select customer from table by entering corresponding ID. Details will be populated in textboxes where you can make updates or delete</p>
        <p>Must enter ID to delete record</p>
        </form>
</body>
</html>
