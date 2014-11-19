<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Downtime.aspx.cs" Inherits="AndonPortal.Report.Downtime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height:500px;overflow:auto">
    <asp:GridView ID="IssueGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  AllowSorting="false"
         AllowPaging="false" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Size="Small"  Wrap="true" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Width="75px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </div>
     <asp:Button ID="Download" runat="server" Text="Download"  OnClick="Download_Click"/>
</asp:Content>
