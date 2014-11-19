<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetIssues.aspx.cs" Inherits="AndonPortal.StatusUpdation.GetIssues" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="Label1" runat="server" Text="Status Updation" ForeColor="White" Font-Size="24px" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <div style="text-align: right;">
                    <asp:Label ID="Label3" runat="server" Text="Name:" ForeColor="White"></asp:Label>
                </div>
            </td>
            <td>
                <div style="text-align: left">

                    <asp:TextBox ID="NameTextBox" runat="server" Width="100px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="NameTextBox" ErrorMessage="Name should be entered"
                        runat="server" ForeColor="Red" />
                </div>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Department: " ForeColor="White"></asp:Label><br />


            </td>

            <td>
                <div style="text-align: left;">
                    <asp:DropDownList ID="DepartmentSelection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DepartmentSelection_SelectedIndexChanged" DataSourceID="DepartmentDataSource" DataTextField="description" DataValueField="description"></asp:DropDownList>
                    <asp:SqlDataSource ID="DepartmentDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IAS_SEPFCConnectionString %>" SelectCommand="SELECT [description] FROM [departments]"></asp:SqlDataSource>
                </div>


            </td>

        </tr>
        <tr>
            <td>
                <div style="text-align: right">
                    <asp:Label ID="Label4" runat="server" Text="From" ForeColor="White"></asp:Label>
                </div>
            </td>
            <td>
                <asp:Calendar ID="FromDate" runat="server"
                    OtherMonthDayStyle-ForeColor="#c0c0c0" ForeColor="White"
                    NextPrevFormat="ShortMonth"
                    NextPrevStyle-Font-Size="8"
                    NextPrevStyle-VerticalAlign="Bottom"
                    NextPrevStyle-BackColor="Green" TitleStyle-BackColor="Green" TitleStyle-BorderColor="Green" SelectedDate="">

                </asp:Calendar>
            </td>
            <td>
                <div style="text-align: right">
                    <asp:Label ID="Label5" runat="server" Text="To" ForeColor="White"></asp:Label>
                </div>
            </td>
            <td>
                <div style="text-align: left">
                    <asp:Calendar ID="ToDate" runat="server"
                        OtherMonthDayStyle-ForeColor="#c0c0c0" NextPrevFormat="ShortMonth"
                        ForeColor="White" NextPrevStyle-Font-Size="8"
                        NextPrevStyle-VerticalAlign="Bottom"
                        TitleStyle-BackColor="Green" TitleStyle-BorderColor="Green" BorderColor="White"></asp:Calendar>
                </div>
            </td>

        </tr>
    </table>
    <div style="text-align: right">
        <asp:Button ID="Generate" runat="server" Text="Get Issues" ForeColor="Green" BackColor="White" OnClick="Generate_Click" />
    </div>
</asp:Content>
