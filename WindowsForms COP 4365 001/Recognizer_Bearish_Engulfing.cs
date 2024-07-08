using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Bearish_Engulfing : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Bearish_Engulfing() : base("Bearish Engulfing", 2)
        {
        }

        /// <summary>
        /// Inherited method to recognize a candlestick
        /// </summary>
        /// <param name="scsList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
                    bool bearish = (prev.open < prev.close) & (scs.close < scs.open);
                    bool engulfing = (scs.topPrice > prev.topPrice) & (scs.bottomPrice < prev.bottomPrice);
                    bool bearish_engulfing = bearish & engulfing;
                    scs.dictionaryPattern.Add(this.patternName, bearish_engulfing);;
                    return bearish_engulfing;
                }
            }
        }
    }
}
