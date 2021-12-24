<%@ Page Language="C#" MasterPageFile="~/InlandMarina.Master" AutoEventWireup="true" CodeBehind="ConfirmLease.aspx.cs" Inherits="InlandMarina.ConfirmLease" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Main" runat="server">

    <div class="text-center">
        <br />
        <br />
        <h2>Would you like to lease this Slip?</h2>
        <br />

        <span class="confirmLabels">Slip ID: </span>
        <asp:TextBox CssClass="textboxTable" ID="txtSlipID" runat="server" ></asp:TextBox> <br />
              
        <span class="confirmLabels">Width: </span>
        <asp:TextBox CssClass="textboxTable" ID="txtWidth" runat="server" ></asp:TextBox><br />
             
        <span class="confirmLabels">Length: </span>
        <asp:TextBox CssClass="textboxTable" ID="txtLength" runat="server" ></asp:TextBox><br />
                 
        <span class="confirmLabels">Dock ID: </span>
        <asp:TextBox CssClass="textboxTable" ID="txtDockId" runat="server" ></asp:TextBox><br />

                
        <asp:Button CssClass="leaseButton btn btn-secondary" ID="btnLease" runat="server" Text="Lease" OnClick="btnLease_Click" />
        <asp:Button CssClass="leaseButton btn btn-secondary" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                
    </div>
</asp:Content>