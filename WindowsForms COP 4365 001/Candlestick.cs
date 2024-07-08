using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    public class Candlestick
    {
        // The opening price of the ticker at the current date
        public decimal open { get; set; }
        // The closing price of the ticker at the current date
        public decimal close { get; set; }
        // The highest price of the ticker at the current date
        public decimal high { get; set; }
        // The lowest price of the ticker at the current date
        public decimal low { get; set; }
        // The adjusted close price of the ticker at the current date
        public decimal adjClose { get; set; }
        // The volume of the ticker at the current date
        public ulong volume { get; set; }
        // The date
        public DateTime date { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Candlestick()
        {
        }

        /// <summary>
        /// Construct a new candle stick based on a string of data values
        /// </summary>
        /// <param name="rowOfData"></param>
        public Candlestick(string rowOfData)
        {
            char[] separators = new char[] {','};
            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Get the date string so that we can send it to DateTime.parse
            string dateString = subs[0];
            // Parse the date
            date = DateTime.Parse(dateString);

            // Read the open price
            decimal temp;
            bool success = decimal.TryParse(subs[1], out temp);
            if (success) open = temp;

            // Read the high price
            success = decimal.TryParse(subs[2], out temp);
            if (success) high = temp;

            // Read the low price
            success = decimal.TryParse(subs[3], out temp);
            if (success) low = temp;

            // Read the close price
            success = decimal.TryParse(subs[4], out temp);
            if (success) close = temp;

            // Read the adjusted close price
            success = decimal.TryParse(subs[5], out temp);
            if (success) adjClose = temp;

            // Read the volume 
            ulong tmp;
            success = ulong.TryParse(subs[6], out tmp);
            if (success) volume = tmp;

        }
    }
}
