using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class SmartCandlestick : Candlestick
    {
        public decimal range {  get; set; } // The range of the candlestick
        public decimal topPrice { get; set; } // The top price of the candlestick
        public decimal bottomPrice { get; set; } // The bottom price of the candlestick
        public decimal bodyRange { get; set; } // The range of the candlestick's body
        public decimal upperTail { get; set; } // The length of the upper tail
        public decimal lowerTail { get; set; } // The length of the lower tail

        // The dictionary that map each pattern to a boolean value (true or false) depending on whether the current candlestick matches that pattern
        public Dictionary<string, bool> dictionaryPattern = new Dictionary<string, bool>();

        /// <summary>
        /// Construct a smart candlestick from a csv row of data
        /// </summary>
        /// <param name="rowOfData"></param>
        public SmartCandlestick(string rowOfData) : base(rowOfData)
        {
            setExtraProperties();
        }

        /// <summary>
        /// Construct a smart candlestick from a candlestick
        /// </summary>
        /// <param name="cs"></param>
        public SmartCandlestick(Candlestick cs)
        {
            date = cs.date;
            open = cs.open;
            close = cs.close;
            high = cs.high;
            low = cs.low;
            volume = cs.volume;
            setExtraProperties();
        }

        /// <summary>
        /// Compute the extra properties based on the inherited properties
        /// </summary>
        private void setExtraProperties()
        {
            this.range = this.high - this.low;
            this.topPrice = Math.Max(this.open, this.close);
            this.bottomPrice = Math.Min(this.open, this.close);
            this.upperTail = this.high - this.topPrice;
            this.lowerTail = this.bottomPrice - this.low;
            this.bodyRange = this.topPrice - this.bottomPrice;
        }

        ///// <summary>
        ///// Populate the pattern dictionary with pairs of pattern and its corresponding boolean value
        ///// </summary>
        //private void setPatternDictionary()
        //{
        //    // Set value for bullish
        //    dictionaryPattern.Add("Bullish", this.close > this.open);

        //    // Set value for bearish
        //    dictionaryPattern.Add("Bearish", this.close < this.open);

        //    // Set value for neutral
        //    dictionaryPattern.Add("Neutral", this.bodyRange <= this.range * 0.15m);

        //    // Set value for marubozu
        //    dictionaryPattern.Add("Marubozu", (this.upperTail <= this.bodyRange * 0.1m) && (this.lowerTail <= this.bodyRange * 0.1m));

        //    // Set value for hammer
        //    dictionaryPattern.Add("Hammer", (this.upperTail <= this.bodyRange * 0.15m) && (this.bodyRange * 2 <= this.lowerTail));

        //    // Set value for doji
        //    dictionaryPattern.Add("Doji", this.bodyRange <= this.range * 0.02m);

        //    // Set value for Dragonfly Doji
        //    dictionaryPattern.Add("Dragonfly Doji", this.bodyRange <= this.range * 0.02m && this.lowerTail >= this.range * 0.7m);

        //    // Set value for Gravestone Doji
        //    dictionaryPattern.Add("Gravestone Doji", this.bodyRange <= this.range * 0.02m && this.upperTail >= this.range * 0.7m);

        //}
    }
}
