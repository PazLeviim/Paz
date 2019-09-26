using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AllItems : System.Web.UI.Page
{
    public string ConnectionServer() //This function is the connection server of my SQL
    {
        return @"Data Source = (LocalDB)\MSSQLLocalDB;
        Database=Missions;
        Integrated Security = True;";
    }
    public void CreateItems() //This function it take all the rows in my SQL and introduce it on the main page with option to delete and remark it the mission complete
    {
        Response.Write("<table><tr><th>No.</th><th>Title</th><th>Description</th><th>Create Date</th><th>Deadline</th><th>Place</th><th>Status</th></tr></table>");
        for (int i = 0; i < Convert.ToInt16(Session["Count"]); i++)
            Response.Write("<table><tr class=missions><th>" + Convert.ToInt16(i + 1) + ".</th><th>" + Session["title" + i] + "</th><th>" + Session["description" + i] + "</th>" +
                "<th>" + Session["date" + i] + "</th><th>" + Session["deadline" + i] + "</th><th>" + Session["place" + i] + "</th><th class=statuss name=status" + i + ">" + Session["status" + i] + "</th><th><input type=checkbox onclick='Done()' name=MissionCheck" + i + " class=missions_done  /></th>" +
                "<th><button type=submit style=height:28px;width:28px; class=removers name=Remover"+i+" readonly value="+rows[i]+" ><b>X</b></button></th></tr></table><br/>");
    }
    public int CountDB(string sqlcmd) //Take the number of how much rows I have
    {
        SqlConnection connection = new SqlConnection(ConnectionServer());
        SqlCommand command = new SqlCommand(sqlcmd, connection);
        connection.Open();
        int count = 0;
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
            count++;
        connection.Close();
        return count;

    }
    public void DeleteRows(int row) //delete the rows that I choose
    {
        string sql = string.Format("delete from Missions where id='{0}'", row);
        UpdateDB(sql);
    }
    public void UpdateDB(string sqlcmd) //I use it for delete and update rows it actions of update my sql server
    {
        SqlConnection connection = new SqlConnection(ConnectionServer());
        SqlCommand command = new SqlCommand(sqlcmd, connection);
        connection.Open();
        int count = command.ExecuteNonQuery();
        connection.Close();
    }
    public int[] rows = new int[1000]; //My ID column on SQL remember the first so it make it to take more place
    public void ShowDB(string sqlcmd)//show my sql records on the main page
    {
        SqlConnection connection = new SqlConnection(ConnectionServer());
        SqlCommand command = new SqlCommand(sqlcmd, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        int count = 0;
        while (reader.Read())
        {
            Session["title" + Convert.ToString(count)] = reader["Title"];
            Session["description" + Convert.ToString(count)] = reader["Description"];
            Session["date" + Convert.ToString(count)] = reader["Date"];
            Session["deadline" + Convert.ToString(count)] = reader["Deadline"];
            Session["place" + Convert.ToString(count)] = reader["Place"];
            Session["status" + Convert.ToString(count)] = reader["Status"];
            Session["row" + Convert.ToString(reader["ID"])] = reader["ID"];
            rows[count] = Convert.ToInt16(Session["row" + Convert.ToString(reader["ID"])]);
            count++;
        }
        Session["Count"] = count;
        connection.Close();
    }
    public void MissionDone(int mission_id)//Update on sql in status column when I remark it done
    {
        string sql = string.Format("update Missions set Status='Done' where id={0}", mission_id);
        UpdateDB(sql);
    }
    public void MissionNotDone(int mission_id) //Update on sql in status column when I remark it not done
    {
        string sql = string.Format("update Missions set Status='Not Done' where id={0}", mission_id);
        UpdateDB(sql);
    }
    public void ShowMissionsDoneDB()//The filter of mission that completed
    {
        string sql = "select * from Missions where Status='Done'";
        ShowDB(sql);
    }
    public void ShowMissionsNotDoneDB()//The filter of mission that not completed
    {
        string sql = "select * from Missions where Status='Not Done'";
        ShowDB(sql);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql;
        int min_count=0;
        int count = CountDB("select * from Missions");//Give me the number of records on sql
        for (int i = 0; 0 < count; i++)
        {
            if (CountDB("select * from Missions where id=" + i) == 0)//Check every ID to see that we not skiping on number
            {
                min_count = i;
                break;
            }
        }
        sql = string.Format("DBCC CHECKIDENT('Missions',RESEED,{0})",min_count-1);
        UpdateDB(sql);
        if (Request.Form["editMission"] == "Save")//Create the new mission and save it in sql DB
        {
            sql = string.Format("insert into [Missions] values ('{0}','{1}','{2}','{3}','{4}','{5}')", Request.Form["title"], Request.Form["describe"], Convert.ToString(DateTime.Now.Year) + "-" + Convert.ToString(DateTime.Now.Month + "-") + Convert.ToString(DateTime.Now.Day) + " " + Convert.ToString(DateTime.Now.TimeOfDay).Substring(0, DateTime.Now.TimeOfDay.ToString().Length - 4), Request.Form["deadline"], Request.Form["place"], "Not Done");
            UpdateDB(sql);
        }
        if (Request.Form["Filter"] != null)
        {
            if (Request.Form["Filter"] == "Missions Done")
                ShowMissionsDoneDB();
            else if (Request.Form["Filter"] == "Missions Not Done")
                ShowMissionsNotDoneDB();
            else
            {
                sql = "select * from Missions";
                ShowDB(sql);
            }
        }
        else
        {
            sql = "select * from Missions";
            ShowDB(sql);
        }
        if (Request.Form["Save"] == "Save")
        {
            int index_row = 0;
            foreach (int i in rows)
            {
                if (i == 0 && index_row > 0)
                    break;
                if (Request.Form["MissionCheck" + Convert.ToString(index_row)] == "Done")
                    MissionDone(i);
                else
                    MissionNotDone(i);
                index_row++;
            }
        }
        for (int i = 0; i < count; i++)
            if (Request.Form["Remover" + Convert.ToInt16(i)] != null)
                DeleteRows(Convert.ToInt16(Request.Form["Remover" + Convert.ToInt16(i)]));
    }
}
