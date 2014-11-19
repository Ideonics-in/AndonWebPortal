<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportDisplay.aspx.cs" Inherits="AndonPortal.ReportDisplay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:1000px;height:500px;overflow:auto">
        <asp:PlaceHolder ID="ReportDataPlaceHolder" runat="server" >
    <%--<asp:GridView ID="Report" runat="server"  ForeColor="White" GridLines="Both">
         
        



    </asp:GridView>--%>
            </asp:PlaceHolder>
        </div>
    <asp:Button ID="Download" runat="server" Text="Download"  OnClick="Download_Click"/>
</asp:Content>
