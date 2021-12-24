<%@Page Language="C#" MasterPageFile="~/InlandMarina.Master" AutoEventWireup="true" CodeBehind="AvailableSlip.aspx.cs" Inherits="InlandMarina.AvailableSlip" %>
<%--Content page for AvailableSlips page
Written by Darren Uong--%>
<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Main" runat="server">
    <div class="jumbotron jumbotron-fluid slipsJumbo">
        <div class="container">
            <h1 class="pageHeader text-center">Available Slips</h1> 
            <p class="pageDescription text-center">Browse available slips within our docks!</p>
           
        </div>
    </div>
        <div class="row">

    <div class="col-sm-6">
        <h2 class="text-center">Docks</h2>
    <asp:GridView ID="gvDocks" CssClass="gridView" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" OnSelectedIndexChanging="gvDocks_SelectedIndexChanging" OnSelectedIndexChanged="gvDocks_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="WaterService" HeaderText="WaterService" SortExpression="WaterService" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="ElectricalService" HeaderText="ElectricalService" SortExpression="ElectricalService" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:CheckBoxField>
            <asp:CommandField ShowSelectButton="True" >
            <ItemStyle Font-Bold="True" ForeColor="#000066" />
            </asp:CommandField>
        </Columns>
       <RowStyle CssClass="altRowStyle" />
        <SelectedRowStyle BackColor="#96b1ff" />
    </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDocks" TypeName="DBAccess.DockDB"></asp:ObjectDataSource>
&nbsp;
        </div>
        <div class="col-sm-6">
            <h2 class="text-center" id="slipsTitle">Slips</h2>
    <asp:GridView  CssClass="gridView" ID="gvSlips" runat="server" AutoGenerateColumns="False" DataSourceID="SlipDataSource">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID" Visible="False" />
        </Columns>
        <RowStyle CssClass="rowStyle" />
        <AlternatingRowStyle CssClass="altRowStyle" />
    </asp:GridView>
            <asp:ObjectDataSource ID="SlipDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableSlips" TypeName="DBAccess.SlipDB">
                <SelectParameters>
                    <asp:Parameter Name="DockID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            </div>
                </div>

    </asp:Content>