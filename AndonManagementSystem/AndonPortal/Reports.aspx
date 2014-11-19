<%@ Page Title="ReportConfiguration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="AndonPortal.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server" >
    
        
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server" >
    <div style="align-content:center; text-align:center">
    <asp:Label runat="server" Text="Report Configuration" ForeColor="White" Font-Size="24px" />
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td></td>
            <td><asp:Label ID="Label3" runat="server" Text="Report Type:" ForeColor="White" ></asp:Label> &nbsp;<div>
                <asp:RadioButtonList CssClass="fixed" ID="TypeSelection" runat="server"  ForeColor="White" RepeatDirection="Horizontal">
                    <asp:ListItem  Value="Downtime">Downtime</asp:ListItem>
                   <asp:ListItem Value="MTBF" >MTBF</asp:ListItem>
                    <asp:ListItem Value="MTTR" >MTTR</asp:ListItem>

                </asp:RadioButtonList>
                    </div>
                </td>
             <td><asp:Label ID="Label6" runat="server" Text="Line: " ForeColor="White"></asp:Label><br />
            
                <asp:DropDownList ID="LineSelection" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="LineSelection_SelectedIndexChanged" ></asp:DropDownList>
            </td>
            
            <td>
                <asp:Label runat="server" Text="No of Shifts:" ForeColor="White"></asp:Label> <br /> <asp:TextBox ID="ShiftTextBox" runat="server" Width="100px"></asp:TextBox>
               
            </td>
          
        </tr>
        <tr>
            <td>
                <div style="text-align:right">
                <asp:Label ID="Label4" runat="server" Text="From" ForeColor="White"></asp:Label>
                    </div>
                </td>
            <td>
                <asp:Calendar ID="FromDate" runat="server" 
                      OtherMonthDayStyle-ForeColor ="#c0c0c0" ForeColor="White"
                      NextPrevFormat="ShortMonth"
                     NextPrevStyle-Font-Size="8"
                     NextPrevStyle-VerticalAlign="Bottom" 
                     NextPrevStyle-BackColor="Green"  TitleStyle-BackColor="Green" TitleStyle-BorderColor="Green"
                    ></asp:Calendar>
            </td>
            <td>
                <div style="text-align:right">
                <asp:Label ID="Label5" runat="server" Text="To" ForeColor="White"></asp:Label>
                    </div>
                    </td>
            <td >
                <div style="text-align:left">
                <asp:Calendar ID="ToDate" runat="server" 
                      OtherMonthDayStyle-ForeColor ="#c0c0c0"  NextPrevFormat="ShortMonth"
                    ForeColor="White" NextPrevStyle-Font-Size="8"
                     NextPrevStyle-VerticalAlign="Bottom" 
                     TitleStyle-BackColor="Green" TitleStyle-BorderColor="Green" BorderColor="White"></asp:Calendar>
                    </div>
            </td>
           
        </tr>
        </table>
    
  
    <div style="text-align:right">
    <asp:Button ID="Generate" runat="server" Text="Generate"  ForeColor="Green" BackColor="White" OnClick="Generate_Click"/>
        </div>
</asp:Content>
