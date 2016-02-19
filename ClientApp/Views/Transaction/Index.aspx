<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ClientApp.Models.TransactionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm("Send", "Transaction", FormMethod.Post))
       { %>
    <%: Html.ValidationSummary(true, "Please correct the errors and try again.") %>
    <div class="form">
        <fieldset>
            <legend>Transaction Information</legend>
                
                <div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.SenderAccountNo) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.SenderAccountNo)%>
                    <%: Html.ValidationMessageFor(m => m.SenderAccountNo)%>
                </div>
                </div>
                
                <div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ReceiverAccountNo) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.ReceiverAccountNo)%>
                    <%: Html.ValidationMessageFor(m => m.ReceiverAccountNo) %>
                </div>
                </div>
                
                <div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Amount) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Amount)%>
                    <%: Html.ValidationMessageFor(m => m.Amount)%>
                </div>
                </div>
                
            <div class="action"><input type="submit" value="Send" /></div>
        </fieldset>
    </div>
    <% } %>
    <div class="processing"></div>
</asp:Content>
