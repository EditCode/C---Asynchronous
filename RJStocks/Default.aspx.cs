/*
 * Name: Roger J.
 * Date: 7/20/2013
 * Version: 1.0
 * Notes: Stocks web app that will allow a user to enter a
 * stock symbol that will then be added to there current view.
 * Once there are symbols entered the applicatio will Asynchronous
 * update all entered stocks price every 2 minutes.
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace RJStocks
{

    public partial class Default : System.Web.UI.Page
    {
        clsStocks.clsFunctions myStocks = new clsStocks.clsFunctions();

        #region " Properties "
        public static DataTable dt;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Placeholder helper for end user
            txtSymbol.Attributes.Add("placeholder", "Symbol");

            if (!IsPostBack)
            {
                myStocks.GenerateTable();
                dt = myStocks.StockPrices;
            }
        }

        //Add the new record to the DataTable and bind it to the Gridview
        protected void bntSubmit_Click(object sender, EventArgs e)
        {
            myStocks.addRecord(dt, txtSymbol.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            txtSymbol.Text = "";
        }

        /*Asynchronous update function that only updates the GridView vs. entire page 
         * by method of a full page post back.
         */
        protected void TimerInterval(object sender, EventArgs e)
        {
            //Check if we have any stocks prices to update.
            if (dt.Rows.Count > 0)
            {
                myStocks.updatePrices(dt);
                dt = myStocks.StockPrices;
                GridView1.DataSource = dt;
                GridView1.DataBind();

                //Now let's show when prices were last updated.
                lblUpdated.Text = "Last Updated: " + Convert.ToString(DateTime.Now);
            }
        }
    }

}