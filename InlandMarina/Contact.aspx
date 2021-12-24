<%@ Page Language="C#" MasterPageFile="~/InlandMarina.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="InlandMarina.Contact" %>
<%--Contact page
Written by Harpreet Kalsi
Date: 25.07.19--%>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Main" runat="server">
     <div class="jumbotron jumbotron-fluid contactJumbo">
        <div class="container">
            <h1 class="pageHeader text-center">Contact Us</h1> 
            <p class="pageDescription text-center">Get in touch!</p>           
        </div>
    </div>
    <div class="container-fluid">
        <p class="text-center pageDescription">
            Inland Lake Marina <br />
            Box 123 Inland Lake, Arizona <br />
            ZIP 86038 <br />
            (office) 928-450-2234 <br />
            (leasing) 928-450-2235 <br />
            (fax) 928-450-2236
        </p>


    <div class="row">
    <div class="col-sm-6 text-center">
        <i class="fas fa-address-book fa-10x"></i> 
        <p class="font-weight-bold">Manager:</p> <p>Glenn Cooke <br /> Contact email: info@inlandmarina.com </p>
        </div>
    <div class="col-sm-6 text-center">
        <i class="fas fa-address-book fa-10x"></i>
        <p class="font-weight-bold">Manager:</p> <p>Kimberley Carson <br /> Contact email: info@inlandmarina.com</p>
        
        </div>
    </div>
        </div>
</asp:Content>