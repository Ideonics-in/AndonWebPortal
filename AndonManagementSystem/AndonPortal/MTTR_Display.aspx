<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MTTR_Display.aspx.cs" Inherits="AndonPortal.MTTR_Display" %>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:chart id="MTTRChart" runat="server" BackColor="#D3DFF0" 
        BorderColor="26, 59, 105" Palette="BrightPastel" BorderlineDashStyle="Solid" 
        BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" 
        Width="600px" Height="400px" RightToLeft="Yes" >
   <titles>
   <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Performance in Different Subjects" ForeColor="26, 59, 105">
   </asp:Title>
   </titles>
   <legends>
   <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default"  BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
   </legends>
  <borderskin SkinStyle="Emboss"></borderskin>
 <series>
 <asp:Series IsValueShownAsLabel="True" ChartArea="ChartArea1" Name="Default" 
               CustomProperties="LabelStyle=Bottom" BorderColor="180, 26, 59, 105" 
               LabelFormat="#"></asp:Series>
  </series>
 <chartareas>
 <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
    <axisy2 Enabled="False"></axisy2>
    <axisx2 Enabled="False"></axisx2>
    <area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
    <axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle" LabelAutoFitStyle="None">
    <MajorGrid LineColor="64, 64, 64, 64" />
    </axisy>
    <axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="True" ArrowStyle="Triangle" IsReversed="False" TextOrientation="Auto" LabelAutoFitStyle="LabelsAngleStep90" IsInterlaced="True" LogarithmBase="10">
    <MajorGrid LineColor="64, 64, 64, 64" />
    </axisx>
    </asp:ChartArea>
    </chartareas>
</asp:chart>

</asp:Content>
