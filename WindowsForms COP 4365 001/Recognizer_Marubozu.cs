using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Marubozu : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Marubozu() : base("Marubozu", 1)
        {
        }

        /// <summary>
        /// Recognize a candlestick pattern
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
                bool marubozu = scs.bodyRange > (scs.range * 0.96m);
                scs.dictionaryPattern.Add(this.patternName, marubozu);
                return marubozu;
            }
        }
    }
}
