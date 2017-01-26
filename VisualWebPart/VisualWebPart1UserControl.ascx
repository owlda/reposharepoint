<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="VisualWebPart99.VisualWebPart1.VisualWebPart1UserControl" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:TextBox ID="FilterBox" runat="server"></asp:TextBox>&nbsp&nbsp&nbsp
        <asp:Button class="ExecuteButton" runat="server" Text="Find" OnClick="ExecuteButton_OnClick"/>
        <asp:UpdateProgress ID="UpdateProgressFind" runat="server">
           <ProgressTemplate>
                <img src="../../../../_layouts/15/images/loadingcirclests16.gif" />
          </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="ResultLabel" runat="server" Text="Label" Visible="False" ForeColor="Green"></asp:Label><br/><br/>
     </ContentTemplate>
</asp:UpdatePanel>
<asp:Button ID="RedirectButton" runat="server" Text="Redirect" OnClick="RedirectButton_OnClick"/>








