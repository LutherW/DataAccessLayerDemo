<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberDetails.aspx.cs" Inherits="DataAccessLayerDemo.UI.Web.WebForm.MemberDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>    
    <form id="form1" runat="server">
    <div>   
    <h1>Library System</h1>
        <a href="default.aspx">Library System Home</a>
        <h2><asp:Literal ID="litName" runat="server" /></h2>     
    <p>
        Books on Loan
        <asp:Repeater ID="rptLoans" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate> 
            <ItemTemplate>
                <li><%# Eval("BookTitle")%><br />
                    <small>
                        <%#DisplayLoanStatus((DataAccessLayerDemo.Services.ViewModels.LoanView)Container.DataItem) %>
                    </small>
                </li>                  
            </ItemTemplate> 
            <FooterTemplate>
                </ul>
            </FooterTemplate> 
        </asp:Repeater>
        
    </p>

        Select a book to loan out:<br />
        <br />
        <asp:Repeater ID="rptBooks" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <%# Eval("Title")%> 
                    <%# LoanStatus((DataAccessLayerDemo.Services.ViewModels.BookView)Container.DataItem)%>
                </li>
            </ItemTemplate> 
            <FooterTemplate>
                </ul>
            </FooterTemplate> 
        </asp:Repeater>                            
    </div>
    </form>
</body>
</html>

