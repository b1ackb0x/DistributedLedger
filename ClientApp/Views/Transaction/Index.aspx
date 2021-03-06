﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ClientApp.Models.TransactionModel>" %>
<%@ Import Namespace="DomainModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="error">
        <%: ViewData["error"] %>
    </div>
    <% using (Html.BeginForm("Send", "Transaction", FormMethod.Post, new {autocomplete= "off"}))
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
    <div class="processing">
      
        <% int i = 0; %>
        <% foreach (var block in  (Block [])ViewData["BlockChain"])
           {%>
        
             <% i = i + 1; %>
        <div class="block">
            <h1><%: i %></h1>
            <div> <b>Proof of Work:</b> <%: block.ProofOfWork %></div>
            
            <div> <b>Previous Block: </b><%:  block.PreviousBlockHash%></div>
            
            <% foreach (Transaction trans in block.EncryptedTransactions)
               {%>
           
            
                   <div class="trans">
                  <div class="row">  Timestamp: <%: trans.TimeStamp.ToString() %></div>
                  <div class="row">  Receiver Account: <%: trans.ReceiverAccount.ID %></div>
                    <div class="row">Sender Account: <%: trans.SenderAccount.ID %></div>
                   <div class="row"> Amount: <%: trans.Amount %></div>
                   </div>
              <% } %>
              
        </div>       

          <% } %>
    </div>
</asp:Content>
