<%@ Page Language="C#" MasterPageFile="~/InlandMarina.Master" AutoEventWireup="true" CodeBehind="Lease.aspx.cs" Inherits="InlandMarina.Lease" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="Head" runat="server">

</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="Main" runat="server">
    <div class="jumbotron jumbotron-fluid leaseJumbo">
        <div class="container">
            <h1 class="pageHeader text-center">Leasing</h1> 
            <p class="pageDescription text-center">Lease any available slips from our docks!</p>
           
        </div>
    </div>
    <div class="container">
        <div class="row">
        <div class="col-sm-6">
            <br />
            <h2 class="text-center">List of Slips Currently Leased </h2>
            <asp:GridView ID="GridView3" CssClass="gridView" runat="server" AutoGenerateColumns="False"  DataSourceID="ObjectDataSource4" >
                <RowStyle CssClass="altRowStyle" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                    </asp:BoundField>
                    <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width">
                    </asp:BoundField>
                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length">
                    </asp:BoundField>
                    <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID">
                    </asp:BoundField>
                </Columns>     
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCurrentLeases" TypeName="DBAccess.LeaseDB">
                <SelectParameters>
                    <asp:Parameter Name="CustomerID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <br />
            <h2 class="text-center">Select Dock </h2>
            <asp:GridView ID="Gridview1" CssClass="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" DataKeyNames="ID">
            <RowStyle CssClass="altRowStyle" />
             <SelectedRowStyle BackColor="#96b1ff" />
                <Columns>
                    
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CheckBoxField DataField="WaterService" HeaderText="WaterService" SortExpression="WaterService">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="ElectricalService" HeaderText="ElectricalService" SortExpression="ElectricalService">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:CheckBoxField>
                    <asp:CommandField ShowSelectButton="True" >
                    <ItemStyle Font-Bold="True" ForeColor="#000066" />
                    </asp:CommandField>
                </Columns>               
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableDocks" TypeName="DBAccess.LeaseDB"></asp:ObjectDataSource>
            <br /><br />
        </div>
            <div class="col-sm-6">
            <h2 class="text-center">Select Slip </h2>
            <asp:GridView ID="GridView2" CssClass="gridView" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2"  OnSelectedIndexChanged="GridView2_SelectedIndexChanged"  DataKeyNames="ID">
                <RowStyle CssClass="rowStyle" />
                <AlternatingRowStyle CssClass="altRowStyle" />
                 <SelectedRowStyle BackColor="#96b1ff" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Width" HeaderText="Width" SortExpression="Width">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Length" HeaderText="Length" SortExpression="Length">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DockID" HeaderText="DockID" SortExpression="DockID">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" >
                    <ItemStyle Font-Bold="True" ForeColor="#000066" />
                    </asp:CommandField>
                </Columns>
                
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAvailableSlips" TypeName="DBAccess.LeaseDB">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Gridview1" Name="DockID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
                </div>
            </div>
        </div>
</asp:Content>