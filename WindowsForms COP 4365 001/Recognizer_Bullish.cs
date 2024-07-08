using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Bullish : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Bullish() : base("Bullish", 1)
        {
        }

        /// <summary>
        /// Inherited method to recognize a list of candlesticks
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
                bool bullish = scs.close > scs.open;
                scs.dictionaryPattern.Add(this.patternName, bullish);
                return bullish;
            }
        }
    }
}
