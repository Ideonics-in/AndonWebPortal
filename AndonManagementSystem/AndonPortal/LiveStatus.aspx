<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LiveStatus.aspx.cs" Inherits="AndonPortal.LiveStatus" %>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height:inherit;overflow:auto;">
    <asp:GridView ID="LiveStatusGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" 
         ForeColor="#333333" GridLines="Both" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:HyperLinkField HeaderText="Line" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/OpenIssues.aspx?id={0}" DataTextField="Name" />
            <asp:ImageField HeaderText="Safety" DataImageUrlField="Image1" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:ImageField>
            <asp:ImageField HeaderText="Breakdown" DataImageUrlField="Image2" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:ImageField>
            <asp:ImageField HeaderText="Quality" DataImageUrlField="Image3" ReadOnly="True">
            </asp:ImageField>
            <asp:ImageField HeaderText="Methods" DataImageUrlField="Image4" ReadOnly="True">
            </asp:ImageField>
            <asp:ImageField HeaderText="Production" DataImageUrlField="Image5" ReadOnly="True">
            </asp:ImageField>
            <asp:ImageField HeaderText="Material" DataImageUrlField="Image6" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:ImageField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="Image1" ImageUrl="~/Images/GREENSMILEY.png" runat="server" /> &nbsp;
    <asp:Label ID="Label1" ForeColor="White" runat="server">NO ISSUE</asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="Image2" ImageUrl="~/Images/ORANGESMILEY.jpg" runat="server" /> &nbsp;
    <asp:Label ID="Label2" ForeColor="White" runat="server">ISSUE RAISED (<15 minutes)</asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="Image3" ImageUrl="~/Images/REDSMILEY.jpg" runat="server" /> &nbsp;
    <asp:Label ID="Label3" ForeColor="White" runat="server">ISSUE RAISED (>15 minutes)</asp:Label> 
        </div>
    </asp:Content>
