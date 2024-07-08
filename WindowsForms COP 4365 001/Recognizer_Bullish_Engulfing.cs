using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Bullish_Engulfing : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Bullish_Engulfing() : base("Bullish Engulfing", 2)
        {
        }

        /// <summary>
        /// Inherited method to recognize a list of smartcandlesticks
        /// </summary>
        /// <param name="scsList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int index)
        {
            //Return existing value or calculate
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
                    bool bullish = (prev.open > prev.close) & (scs.close > scs.open);
                    bool engulfing = (scs.topPrice > prev.topPrice) & (scs.bottomPrice < prev.bottomPrice);
                    bool bullish_engulfing = bullish & engulfing;
                    scs.dictionaryPattern.Add(this.patternName, bullish_engulfing);
                    return bullish_engulfing;
                }
            }
        }
    }
}
