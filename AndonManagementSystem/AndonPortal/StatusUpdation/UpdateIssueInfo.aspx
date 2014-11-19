<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateIssueInfo.aspx.cs" Inherits="AndonPortal.StatusUpdation.UpdateIssueInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="Label1" runat="server" Text="Status Updation" ForeColor="White" Font-Size="24px" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="IssueGrid" runat="server" AutoGenerateColumns="False"  
        HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ForeColor="White" >
        <Columns>

             <asp:TemplateField HeaderText="Issue" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:HyperLink  ForeColor="White" ID="IssueLink" runat="server"  
                             NavigateUrl='<%#"~/StatusUpdation/UpdateInfo.aspx?Name="+Eval("Name")+"&Issue="+Eval("ISSUE") %>'
                            Text='<%#Eval("ISSUE") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>    
             <asp:BoundField DataField="DATE" HeaderText="Date" >
                <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="RAISED" HeaderText="Raised" >
                <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="RESOLVED" HeaderText="Resovled" >
                <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField DataField="DOWNTIME" HeaderText="Downtime" >
                <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="LINE" HeaderText="Line" >
                <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="STATION" HeaderText="Station"  > 
                <HeaderStyle Width="100px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="DETAILS" HeaderText="Details"  >
                <HeaderStyle Width="100px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CAUSE" HeaderText="Cause"  >
                <HeaderStyle Width="100px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CORRECTIVE ACTION" HeaderText="Corrective Action"  >
                <HeaderStyle Width="150px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CONTATIMENT ACTION" HeaderText="Containment Action">
                
                <HeaderStyle Width="150px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="COST" HeaderText="Cost"  >
                <HeaderStyle Width="30px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField DataField="SPARE" HeaderText="Spare" >
                <HeaderStyle Width="50px"></HeaderStyle>
            </asp:BoundField>
            <asp:ButtonField />
        </Columns>

        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
    </asp:GridView>
    
</asp:Content>
