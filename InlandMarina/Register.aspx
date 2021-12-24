<%@ Page Language="C#" MasterPageFile="~/InlandMarina.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="InlandMarina.Register" %>
<%--Register Page
Author: James Defant
Date: July 24 2019--%>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Main" runat="server">

    <fieldset class="col-md-6 offset-md-3">
        <h1>Registration</h1>

        <!-- Error Message -->
        <div class="error-msg">
            <asp:Label ID="uxError" runat="server"
                Text="Incorrect user info"
                class="alert alert-danger"></asp:Label>
        </div>

        <!-- First Name -->
        <div class="form-group">
            <asp:Label ID="firstNameText" runat="server"
                Text="First Name:"></asp:Label>
            <asp:TextBox ID="uxFirstName" runat="server"
                class="form-control"></asp:TextBox>
            <small class="validation">
                <asp:RequiredFieldValidator ID="firstNameRequiredValidation" runat="server"
                    ErrorMessage="First Name is required"
                    ControlToValidate="uxFirstName"
                    class="validator"></asp:RequiredFieldValidator>
            </small>
        </div>

        <!-- Last Name -->
        <div class="form-group">
            <asp:Label ID="lastNameText" runat="server"
                Text="Last Name:"></asp:Label>
            <asp:TextBox ID="uxLastName" runat="server"
                class="form-control"></asp:TextBox>
            <small class="validation">
                <asp:RequiredFieldValidator ID="lastNameRequiredValidation" runat="server"
                    ErrorMessage="Last Name is required"
                    ControlToValidate="uxLastName"
                    class="validator"></asp:RequiredFieldValidator>
            </small>
        </div>

        <!-- Phone -->
        <div class="form-group">
            <asp:Label ID="phoneText" runat="server"
                Text="Phone:"></asp:Label>
            <asp:TextBox ID="uxPhone" runat="server"
                class="form-control"></asp:TextBox>
            <small class="validation">
                <asp:RequiredFieldValidator ID="phoneRequiredValidation" runat="server"
                    ErrorMessage="Phone number is required"
                    ControlToValidate="uxPhone"
                    class="validator"></asp:RequiredFieldValidator>
            </small>
        </div>

        <!-- City -->
        <div class="form-group">
            <asp:Label ID="cityText" runat="server"
                Text="City:"></asp:Label>
            <asp:TextBox ID="uxCity" runat="server"
                class="form-control"></asp:TextBox>
            <small class="validation">
                <asp:RequiredFieldValidator ID="cityRequiredValidation" runat="server"
                    ErrorMessage="City is required"
                    ControlToValidate="uxCity"
                    class="validator"></asp:RequiredFieldValidator>
            </small>
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

        <!-- Password Confirmation-->
        <div class="form-group">
            <asp:Label ID="passConfirmText" runat="server"
                Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="uxPasswordConfirm" runat="server"
                TextMode="Password"
                class="form-control"></asp:TextBox>
            <small class="validation">
                <asp:RequiredFieldValidator ID="passwordConfirmRequiredValidation" runat="server"
                    ErrorMessage="Password confirmation is required"
                    ControlToValidate="uxPasswordConfirm"
                    class="validator" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="passwordCompareValidation" runat="server"
                    ErrorMessage="Passwords must match"
                    ControlToValidate="uxPasswordConfirm"
                    ControlToCompare="uxPassword"
                    class="validator"
                    Display="Dynamic"></asp:CompareValidator>
            </small>
        </div>

        <!-- Buttons -->
        <div class="form-group">
            <asp:Button ID="uxRegister" runat="server"
                Text="Register"
                OnClick="uxRegister_Click"
                class="btn btn-secondary"/>

            <asp:Button ID="uxClear" runat="server"
                Text="Clear"
                OnClick="uxClear_Click"
                class="btn btn-secondary"/>
        </div>
    </fieldset>

</asp:Content>
