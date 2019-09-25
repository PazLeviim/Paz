<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllItems.aspx.cs" Inherits="AllItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Mission</title>
    <link href="AllItems.css" rel="stylesheet" />
    <script src="AllItems.js"></script>
</head>
<body onload="Show()">
    <h1 style="text-align:center;">My Missions</h1>
    <%=Request.Form["Filter"] %>
    <form runat="server" method="post" action="AllItems.aspx">
        <table>
        <tr>
            <td><a href="AllItems.aspx"><button type="submit" name="Filter" value="All">All</button></a></td>
            <td><a href="AllItems.aspx"><button type="submit" name="Filter" value="Missions Done">Missions Done</button></a></td>
            <td><a href="AllItems.aspx"><button type="submit" name="Filter" value="Missions Not Done">Missions Not Done</button></a></td>
        </tr>
    </table>
    <%CreateItems(); %>
    <a href="NewItem.aspx"><button type="button">Create Mission</button></a>
        <input type="submit" value="Save" name="Save" />
    <p>&copy;כל הזכויות שמורות לפז לויים</p>
    </form>
</body>
</html>
