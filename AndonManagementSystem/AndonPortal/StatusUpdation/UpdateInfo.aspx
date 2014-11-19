<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateInfo.aspx.cs" Inherits="AndonPortal.StatusUpdation.UpdateInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="Label5" runat="server" Text="Status Updation" ForeColor="White" Font-Size="24px" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td style="text-align:right">
                <div style="text-align:right;" >
                    <asp:Label Text="CAUSE:" runat="server" ForeColor="White" />
                </div>
            </td>
            <td>
                <div style="text-align:left;" >
                    <asp:TextBox runat="server" ID="CauseTextBox" TextMode="MultiLine"  Width="300px" Height="30px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CauseTextBox" 
                        ErrorMessage="Required"
                        runat="server" ForeColor="Red" />
                </div>
            </td>
        </tr>
        
             <tr>
            <td style="text-align:right">
                <div style="text-align:right"; >
                    <asp:Label ID="Label1" Text="CORRECTIVE ACTION:" runat="server" ForeColor="White" />
                </div>
            </td>
            <td>
                <div style="text-align:left"; >
                    <asp:TextBox runat="server" ID="CorrectiveTextBox" TextMode="MultiLine"   Width="300px" Height="100px" Wrap="true" />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CorrectiveTextBox" 
                        ErrorMessage="Required"
                        runat="server" ForeColor="Red" />
                </div>
            </td>
        </tr>

              <tr>
            <td style="text-align:right">
                <div style="text-align:right;" >
                    <asp:Label ID="Label2" Text="CONTAINMENT ACTION:"  runat="server" ForeColor="White" />
                </div>
            </td>
            <td>
                <div style="text-align:left;" >
                    <asp:TextBox runat="server" ID="ContainmentTextBox"  Width="300px" Height="100px" TextMode="MultiLine" Wrap="true" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ContainmentTextBox" 
                        ErrorMessage="Required" 
                        runat="server" ForeColor="Red" />
                </div>
            </td>
        </tr>
        
             <tr>
            <td style="text-align:right">
                <div  style="text-align:right"; >
                    <asp:Label ID="Label3" Text="COST:" runat="server" ForeColor="White" />

                </div>
            </td>
            <td>
                <div style="text-align:left"; >
                    <asp:TextBox runat="server" ID="CostTextBox"  Width="300px" Height="30px" Wrap="true" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="CostTextBox" 
                        ErrorMessage="Required"
                        runat="server" ForeColor="Red" />
                </div>
            </td>
        </tr>
           <tr>
            <td style="text-align:right">
                <div style="text-align:right" >
                    <asp:Label ID="Label4" Text="SPARES (NA - not Applicable):" runat="server" ForeColor="White" />
                </div>
            </td>
            <td>
                <div style="text-align:left" >
                    <asp:TextBox runat="server" ID="SpareTextBox"  Width="300px" Height="30px" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="SpareTextBox" 
                        ErrorMessage="Required"
                        runat="server" ForeColor="Red" />
                </div>
            </td>
        </tr>

    </table>
      <div style="text-align:center">
            <asp:Button ID="Update" runat="server" Text="Update"  ForeColor="Green" BackColor="White" OnClick="Update_Click"/>
        </div>
</asp:Content>
