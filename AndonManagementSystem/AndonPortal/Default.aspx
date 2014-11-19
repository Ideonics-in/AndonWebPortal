<%@ Page  Title="Andon Portal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AndonPortal._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
               
            </hgroup>
           
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent"  >
    <div   >
         <asp:HyperLink ID="LiveStatusLink" runat="server" NavigateUrl="~/LiveStatus.aspx" ForeColor="White"
         Font-Size="30px">Line Status</asp:HyperLink> 
         <br />
         <asp:HyperLink ID="LiveStatusLink0" runat="server" NavigateUrl="~/VHTStatus.aspx" ForeColor="White"
         Font-Size="30px">VHT Status</asp:HyperLink> <br />
    <asp:HyperLink ID="ReportLink" runat="server" NavigateUrl="~/Reports/Reports.aspx" ForeColor="White"
         Font-Size="30px">Reports</asp:HyperLink>
        <br />
    <asp:HyperLink ID="StatusUpdationLink" runat="server" NavigateUrl="~/StatusUpdation/GetIssues.aspx" ForeColor="White"
         Font-Size="30px">Status Updation</asp:HyperLink>
        </div>
</asp:Content>
