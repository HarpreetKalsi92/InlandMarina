<%@ Page Language="C#" MasterPageFile="~/InlandMarina.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InlandMarina.Login" %>
<%--Login Page
Author: James Defant
Date: July 24 2019--%>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Main" runat="server">
    
    <fieldset class="col-md-6 offset-md-3">
        <h1>Login to Inland Marina</h1>

        <!-- Error Message -->
        <div class="error-msg">
            <asp:Label ID="uxError" runat="server" 
                Text="Incorrect user info"
                class="alert alert-danger"></asp:Label>
        </div>

        <!-- Username -->        
        <div class="form-group">
            <asp:Label ID="userText" runat="server" 
                Text="Username:"></asp:Label>
            <asp:TextBox ID="uxUserName" runat="server"
                class="form-control"></asp:TextBox>
            <small class="validation">
                <asp:RequiredFieldValidator ID="usernameRequiredValidation" runat="server" 
                    ErrorMessage="Username is required" 
                    ControlToValidate="uxUserName"
                    class="validator"></asp:RequiredFieldValidator>
            </small>
        </div>

        <!-- Password -->
        <div class="form-group">
            <asp:Label ID="passText" runat="server" 
                Text="Password:"></asp:Label>
            <asp:TextBox ID="uxPassword" runat="server"
                TextMode="Password"
                class="form-control"></asp:TextBox>
            <small class="validation">
                <asp:RequiredFieldValidator ID="passwordRequiredValidation" runat="server" 
                    ErrorMessage="Password is required" 
                    ControlToValidate="uxPassword"
                    class="validator"></asp:RequiredFieldValidator>
            </small>
        </div>

        <!-- Login button -->
        <asp:Button ID="uxLogin" runat="server" 
            Text="Login"
            OnClick="uxLogin_Click"
            class="btn btn-secondary"/>

    </fieldset>
    
</asp:Content>