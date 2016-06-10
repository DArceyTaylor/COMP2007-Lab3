<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentDetails.aspx.cs" Inherits="COMP2007_Lab3.DepartmentDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-8">
                <h1>Department Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="DepartmentNameTextBox">DepartmentName</label>
                    <asp:TextBox runat="server" CssClass="form-control" id="DepartmentNameTextBox" placeholder="Department Name"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="BudgetTextBox">Budget</label>
                    <asp:TextBox runat="server" CssClass="form-control" id="BudgetTextBox" placeholder="Budget"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Invalid Date! Budget must be greater than 0.0"
                        ControlToValidate="BudgetTextBox" ValueToCompare="0.00" 
                        Operator="LessThanEqual" Type="Double" Display="Dynamic" BackColor="Red" ForeColor="White" 
                        Font-Size="Large" ></asp:RangeValidator>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" UseSubmitBehavior="false"
                        CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
