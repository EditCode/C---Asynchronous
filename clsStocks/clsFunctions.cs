using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;

namespace clsStocks
{
    public class clsFunctions
    {
        #region " Properties "
        private DataTable stockPrices;

        public DataTable StockPrices
        {
            get
            {
                return stockPrices;
            }
            set
            {
                stockPrices = value;
            }
        }
        #endregion

        /*Since were not dealing with connecting to a Database etc
         *I decided to use a DataTable for the purposes of this project.
         *Generating the initial table so its ready for use in the application.
         */
        #region " Methods "
        public void GenerateTable()
        {
            DataTable dt = new DataTable("Stocks");
            DataColumn column1 = new DataColumn("Symbol");
            column1.AllowDBNull = true;
            column1.DataType.Equals(typeof(string));
            dt.Columns.Add(column1);
            DataColumn column2 = new DataColumn("Price");
            column1.AllowDBNull = true;
            column1.DataType.Equals(typeof(float));
            dt.Columns.Add(column2);

            this.StockPrices = dt;

        }

        //Function to add a new record to the existing DataTable.
        public void addRecord(DataTable data, string newStocks)
        {
            StockPrices = data;
            //DataTable dt = StockPrices;
            DataRow dr = StockPrices.NewRow();
            dr["Symbol"] = newStocks;
            dr["Price"] = "$" + randomNbr();
            StockPrices.Rows.Add(dr);

        }

        //Helper function to generate a random number for the stock price.
        public double randomNbr()
        {
            Random rndNbr = new Random();
            double nbr = 0;
            nbr = (100-1) * rndNbr.NextDouble() + 1;
            return Math.Round(nbr, 2, MidpointRounding.AwayFromZero);

        }

        //Helper function to update stock prices.
        public void updatePrices(DataTable data)
        {
            foreach (DataRow dr in data.Rows)
            {
                dr["Price"] = randomNbr();
                /*Need to sleep the current update otherwise it updates
                 *all prices to the same amount.  When debugging it works fine.
                 *Might need to look at othr alternatives.
                */
                Thread.Sleep(2300);
            }
            StockPrices = data;
        }
        #endregion

    }
}
