using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal abstract class Recognizer
    {
        //Abstract Properties
        public string patternName;
        public int patternLength;

        //Constructor
        protected Recognizer(string patternName, int patternLength)
        {
            this.patternName = patternName;
            this.patternLength = patternLength;
        }

        /// <summary>
        /// Recognize a candlestick
        /// </summary>
        /// <param name="scsList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract bool Recognize(List<SmartCandlestick> scsList, int index);

        /// <summary>
        /// Recognize a list of candlesticks
        /// </summary>
        /// <param name="scsList"></param>
        public void RecognizeAll(List<SmartCandlestick> scsList)
        {
            for (int i = 0; i < scsList.Count; i++)
            {
                Recognize(scsList, i);
            }
        }
    }
}
