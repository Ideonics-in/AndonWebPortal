<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportDisplay.aspx.cs" Inherits="AndonPortal.ReportDisplay" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server"  style=" width:auto; height:inherit;overflow:auto">
        <asp:PlaceHolder ID="ReportDataPlaceHolder" runat="server"   >
    <%--<asp:GridView ID="Report" runat="server"  ForeColor="White" GridLines="Both">
         
        



    </asp:GridView>--%>
            </asp:PlaceHolder>
        </div>
    <asp:Button ID="Download" runat="server" Text="Download"  OnClick="Download_Click"/>
</asp:Content>
