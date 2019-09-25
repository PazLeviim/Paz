<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewItem.aspx.cs" Inherits="NewItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>הוספת משימה חדשה</title>
    <script src="NewItem.js"></script>
</head>
<body style="direction:rtl;">
    <h1 style="text-align:center;">New Mission</h1>
    <form runat="server" method="post" action="AllItems.aspx">
        <table>
            <tr>
                <th><input placeholder="Title" name="title" required id="title"/></th>
            </tr>
            <tr>
                <th><textarea placeholder="Description" style="height:130px;width:190px;" name="describe"></textarea></th>
            </tr>
            <tr>
                <th><input placeholder="Place" name="place" required id="place"/></th>
            </tr>
            <tr>
                <th>Deadline: <input type="date" onblur="MinDate()" name="deadline" id="deadline" required id="deadline" />
                </th>
            </tr>
            <tr>
                <td><button type="submit" name="editMission" value="Save">Save</button></td> <td><a href="AllItems.aspx"><button type="button" name="editMission" value="Cancel">Cancel</button></a></td>
            </tr>
        </table>
    </form>
</body>
</html>
