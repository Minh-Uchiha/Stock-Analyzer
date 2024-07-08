using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Bearish_Harami : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Bearish_Harami() : base("Bearish Harami", 2)
        {
        }

        /// <summary>
        /// Inherited method to recognize a candlestick pattern
        /// </summary>
        /// <param name="scsList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int index)
        {
            //Return if the candlestick has been recognized
            SmartCandlestick scs = scsList[index];
            if (scs.dictionaryPattern.TryGetValue(this.patternName, out bool value))
            {
                return value;
            }
            else
            {
                //Return false if out of bounds or continue to calculation
                int offset = this.patternLength / 2;
                if (index < offset)
                {
                    scs.dictionaryPattern.Add(this.patternName, false);
                    return false;
                }
                else
                {
                    SmartCandlestick prev = scsList[index - offset];
                    bool bearish = (prev.open < prev.close) & (scs.close < scs.open);
                    bool harami = (scs.topPrice < prev.topPrice) & (scs.bottomPrice > prev.bottomPrice);
                    bool bearish_harami = bearish & harami;
                    scs.dictionaryPattern.Add(this.patternName, bearish_harami);
                    return bearish_harami;
                }
            }
        }
    }
}
