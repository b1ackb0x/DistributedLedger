<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.TransactionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true, "Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>Account Information</legend>
            <div class="row">
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.SenderAccountNo) %>
                </div>
                <div class="editor-field">
                    <%: Page.User.Identity.Name%>
                    <%: Html.HiddenFor(m => m.SenderAccountNo)%>
                    <%: Html.ValidationMessageFor(m => m.SenderAccountNo)%>
                </div>
            </div>
            <div class="row">
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ReceiverAccountNo) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.ReceiverAccountNo)%>
                    <%: Html.ValidationMessageFor(m => m.ReceiverAccountNo)%>
                </div>
            </div>
            <div class="row">
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Amount) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Amount)%>
                    <%: Html.ValidationMessageFor(m => m.Amount)%>
                </div>
            </div>
            <p>
                <input type="submit" value="Send" />
            </p>
        </fieldset>
    </div>
    <% } %>
</asp:Content>
