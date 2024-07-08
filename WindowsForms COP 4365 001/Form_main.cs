using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.WebRequestMethods;

namespace WindowsForms_COP_4365_001
{
    public partial class Form_Main : Form
    {
        private List<SmartCandlestick> candlesticks = null; // Stores the list of all candlesticks
        private List<SmartCandlestick> filteredCandleSticks = null; // Stores the list of candlesticks having date between startDate and endDate
        private BindingList<SmartCandlestick> boundCandleSticks = null; // List of candlesticks that are bound to the DataGridView
        private DateTime? startDate = null; // The earliest date that a candlestick is allowed to have (bound to a dateTimePicker)
        private DateTime? endDate = null; // The latest date that a candlestick is allowed to have (bound to a dateTimePicker)
        //Dictionary to store all Recognizers
        private Dictionary<string, Recognizer> recognizers;
        //Highest total chart value
        private double chartMax;
        //Lowest total chart value
        private double chartMin;

        /// <summary>
        /// Defalt constructor for form
        /// </summary>
        public Form_Main()
        {
            InitializeComponent();
            InitializeRecognizers();

            /*
                Initialize all the members variables of the Form when it was loaded
            */
            candlesticks = new List<SmartCandlestick>(1000);
            filteredCandleSticks = new List<SmartCandlestick>();
            boundCandleSticks = new BindingList<SmartCandlestick>();
            startDate = new DateTime(2022, 1, 1);
            endDate = DateTime.Now;
        }

        /// <summary>
        /// Initialize the recognizers dictionary
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitializeRecognizers()
        {
            recognizers = new Dictionary<string, Recognizer>();

            //Bullish Recognizer
            Recognizer r = new Recognizer_Bullish();
            recognizers.Add(r.patternName, r);
            //Bearish Recognizer
            r = new Recognizer_Bearish();
            recognizers.Add(r.patternName, r);
            //Neutral Recognizer
            r = new Recognizer_Neutral();
            recognizers.Add(r.patternName, r);
            //Marubozu Recognizer
            r = new Recognizer_Marubozu();
            recognizers.Add(r.patternName, r);
            //Hammer Recognizer
            r = new Recognizer_Hammer();
            recognizers.Add(r.patternName, r);
            //Doji Recognizer
            r = new Recognizer_Doji();
            recognizers.Add(r.patternName, r);
            //Dragonfly Doji Recognizer
            r = new Recognizer_Dragonfly_Doji();
            recognizers.Add(r.patternName, r);
            //Gravestone Doji Recognizer
            r = new Recognizer_Gravestone_Doji();
            recognizers.Add(r.patternName, r);
            //Bullish Engulfing Recognizer
            r = new Recognizer_Bullish_Engulfing();
            recognizers.Add(r.patternName, r);
            //Bearish Engulfing Recognizer
            r = new Recognizer_Bearish_Engulfing();
            recognizers.Add(r.patternName, r);
            //Bullish Harami Recognizer
            r = new Recognizer_Bullish_Harami();
            recognizers.Add(r.patternName, r);
            //Bearish Harami Recognizer
            r = new Recognizer_Bearish_Harami();
            recognizers.Add(r.patternName, r);
            //Peak Recognizer
            r = new Recognizer_Peak();
            recognizers.Add(r.patternName, r);
            //Valley Recognizer
            r = new Recognizer_Valley();
            recognizers.Add(r.patternName, r);
        }

        /// <summary>
        /// Initialize a new form with specified startDate, endDate, and the path to a ticker file
        /// </summary>
        /// <param name="tickerPath"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public Form_Main(string tickerPath, DateTime? startDate, DateTime? endDate)
        {
            InitializeComponent();
            InitializeRecognizers();

            // Update the start and end dates
            this.startDate = startDate;
            this.endDate = endDate;

            // Update the dateTimePicker values
            dateTimePicker_startDate.Value = startDate.Value;
            dateTimePicker_endDate.Value = endDate.Value;

            // Read the file at tickerPath
            this.candlesticks = readFile(tickerPath);
            
            // Process the tickers (filer, normalize, and display them)
            processTickers();

        }

        /// <summary>
        /// Function to handle the click event from the button_open_ticker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_open_ticker_Click(object sender, EventArgs e)
        {
            // Show the dialog so that the user can choose a ticker
            openFileDialog_openTicker.ShowDialog();
        }

        /// <summary>
        /// Function to handle the event when a user finish choosing the ticker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog_openTicker_FileOk(object sender, CancelEventArgs e)
        {
            // Get the number of files selected
            int selectedFileNum = openFileDialog_openTicker.FileNames.Count();

            // Iterate through the list of selected files
            for (int i = 0; i < selectedFileNum; ++ i)
            {
                // Get the file path
                string tickerPath = openFileDialog_openTicker.FileNames[i];
                // Get the name of the current ticker
                string tickerName = Path.GetFileNameWithoutExtension(tickerPath);

                // Delare a new form
                Form_Main form_main;

                // The first stock must appear in the main input form
                if (i == 0)
                {
                    form_main = this; // Set form_main to the main form
                    readFile(); // Go read the chosen file
                    processTickers(); // Process the list of tickers fetched from the chosen file
                    form_main.Text = "Parent " + tickerName; // Change the form name to show the ticker's name
                }
                else
                {
                    form_main = new Form_Main(tickerPath, this.startDate, this.endDate); // Create a new form for the current ticker
                    form_main.Text = "Child " + tickerName; // Change the form name to show the ticker's name
                }

                // Show the current form
                form_main.Show();
                // Bring the current form to the front
                form_main.BringToFront();
            }

        }

        /// <summary>
        /// Filter, normalize, and display the tickers that have been read by the readFile() function
        /// </summary>
        private void processTickers()
        {
            // Filter the list of candleSticks
            filterCandlesticks();

            // Normalize the chart to display full range
            normalizeChart();

            // Fill the combo box with patterns
            fillComboBox();

            // Display the list of tickers on the data grid view
            displayTickers();
        }

        /// <summary>
        /// Fill the combo box dynamically based on the SmartCandlestick's pattern dictionary
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void fillComboBox()
        {
            fillComboBox(this.recognizers);
        }

        /// <summary>
        /// Helper function to fill the combo box
        /// </summary>
        /// <param name="filteredCandleSticks"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void fillComboBox(Dictionary<string, Recognizer> recognizers)
        {
            comboBox_pattern.Items.Clear(); // Clear the combo box before inserting new elements
            comboBox_pattern.Items.AddRange(recognizers.Keys.ToArray()); // Fill the combo box with the recognizers' names
        }

        /// <summary>
        /// Normalize the chart to display full range 
        /// </summary>
        private void normalizeChart()
        {
            normalizeChart(this.boundCandleSticks);
        }

        /// <summary>
        /// Helper function to normalize the chart
        /// </summary>
        /// <param name="boundCandleSticks"></param>
        private void normalizeChart(BindingList<SmartCandlestick> boundCandleSticks)
        {
            // If boundCandleSticks is empty, stop
            if (boundCandleSticks.Count == 0) return;

            // Variables to store the min and max price of the stock
            decimal min = boundCandleSticks.First().low, max = 0;

            //Iterate through each candlestick in the binding list
            foreach (Candlestick cs in boundCandleSticks)
            {
                // Update the min and max values
                if (cs.low < min)
                {
                    min = cs.low;
                }
                if (cs.high > max)
                {
                    max = cs.high;
                }
            }
            // Add 2% to the Maximum and subtract 2% to the Minimum values of the Y Axis
            this.chartMin = chart_stock.ChartAreas["ChartArea_stock"].AxisY.Minimum = Math.Round(Decimal.ToDouble(min) * 0.98, 2);
            this.chartMax = chart_stock.ChartAreas["ChartArea_stock"].AxisY.Maximum = Math.Round(Decimal.ToDouble(max) * 1.02, 2);
        }

        /// <summary>
        /// Filter the list of candle sticks to only 
        /// </summary>
        private void filterCandlesticks()
        {
            // Filter the list of candlesticks
            this.filteredCandleSticks = filteredCandlesticks(this.candlesticks, startDate.Value, endDate.Value);

            // Set the current binding list to the filtered list
            boundCandleSticks = new BindingList<SmartCandlestick>(this.filteredCandleSticks);
        }

        /// <summary>
        /// Helper function that returns a list of candlesticks that have startDate <= date <= endDate
        /// </summary>
        /// <param name="candlesticks"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private List<SmartCandlestick> filteredCandlesticks(List<SmartCandlestick> candlesticks, DateTime startDate, DateTime endDate)
        {
            // Initialize the list that will store the final filtered candlesticks with capacity set to the size of the candlesticks list
            List<SmartCandlestick> filteredCandlesticks = new List<SmartCandlestick>(candlesticks.Count); 

            // Iterate through the list of candlesticks 
            foreach (SmartCandlestick cs in candlesticks)
            {
                // Add the candlesticks having startDate <= date <= endDate to the filter list
                if (cs.date >= startDate && cs.date <= endDate)
                {
                    filteredCandlesticks.Add(cs);
                }
            }
            return filteredCandlesticks;
        }

        /// <summary>
        /// Display the tickers on the data grid view and the chart
        /// </summary>
        private void displayTickers()
        {
            displayTickers(boundCandleSticks);
        }

        /// <summary>
        /// Helper method to display the list of tickers
        /// </summary>
        /// <param name="boundCandleSticks"></param>
        private void displayTickers(BindingList<SmartCandlestick> boundCandleSticks)
        {
            // Clear the previous annotations
            chart_stock.Annotations.Clear();
            // Set the date source of the chart to the binding list
            chart_stock.DataSource = boundCandleSticks;
            chart_stock.DataBind();
        }

        /// <summary>
        /// Read the chosen csv file and stores the data in the list of candlesticks
        /// </summary>
        private void readFile()
        {
            this.candlesticks = readFile(openFileDialog_openTicker.FileName);
        }

        /// <summary>
        /// Helper method that read the content of a file and stores the data in the list of candlesticks
        /// </summary>
        /// <param name="filename"></param>
        private List<SmartCandlestick> readFile(string filename)
        {
            // Stores the result of the function
            List<SmartCandlestick> candlesticks = new List<SmartCandlestick>();

            // The string contains the value of the first row of the csv file 
            const string referenceString = "Date,Open,High,Low,Close,Adj Close,Volume";

            // Iterate through each row of the csv file
            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine(); // Get the current line

                // Continue reading until the end of file is found
                if (line == referenceString)
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Instantiate a new candlestick
                        SmartCandlestick cs = new SmartCandlestick(line);
                        // Add the new candlestick to the list of all candlesticks
                        candlesticks.Add(cs);
                    }
                }
                else
                {
                    // Change the text of the form to notify that the chosen file is bad (doesn't have that labels at the beginning)
                    Text = "Bad File" + filename;
                }
            }

            // Run all the recognizers on the list
            foreach (Recognizer r in recognizers.Values)
            {
                //Adds dictionary entries for every pattern on every candlestick
                r.RecognizeAll(candlesticks);
            }

            return candlesticks;
        }

        /// <summary>
        /// Update the chart and the data grid view according to the current values of the datetime picker 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_update_Click(object sender, EventArgs e)
        {
            // Don't update if the data values are invalid
            if (candlesticks.Count == 0 || startDate > endDate) return;

            // Process the tickers
            processTickers();

        }

        /// <summary>
        /// Update the value of startDate when the dateTimePicker_startDate changes value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
        {
            this.startDate = dateTimePicker_startDate.Value;
        }

        /// <summary>
        /// Update the value of endDate when the dateTimePicker_endDate changes value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_endDate_ValueChanged(object sender, EventArgs e)
        {
            this.endDate = dateTimePicker_endDate.Value;
        }

        /// <summary>
        /// Update the annotations whenever the user select a pattern on the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_pattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_stock.Annotations.Clear(); // Clear the previous annotations first
            string chosenPattern = comboBox_pattern.SelectedItem.ToString(); // Get the pattern choice

            for (int i = 0; i < boundCandleSticks.Count; ++ i)
            {
                SmartCandlestick smcs = boundCandleSticks[i]; // Get the current smart candlestick
                if (smcs.dictionaryPattern[chosenPattern]) // If the current candlestick matches the pattern, annotate it
                {
                    DataPoint dataPoint = chart_stock.Series[0].Points[i]; // Get the data point of the current candlestick

                    // If the selected pattern is a multi-candlestick pattern
                    int patternLength = recognizers[chosenPattern].patternLength;
                    if (patternLength > 1)
                    {
                        //Skip indexes that cause out of bounds error
                        if (i == 0 || (i == boundCandleSticks.Count - 1 & patternLength == 3))
                        {
                            continue;
                        }
                        //Initialize rectangle annotation
                        RectangleAnnotation rectangle = new RectangleAnnotation();
                        rectangle.SetAnchor(dataPoint);

                        double Ymax, Ymin;
                        double width = (90.0 / boundCandleSticks.Count()) * patternLength; //Scale width to number of candlesticks
                                                                                    //Find the min and max between every candlestick in pattern
                        if (patternLength == 2)    //Even number pattern
                        {
                            Ymax = (int)(Math.Max(smcs.high, boundCandleSticks[i - 1].high));
                            Ymin = (int)(Math.Min(smcs.low, boundCandleSticks[i - 1].low));
                            rectangle.AnchorOffsetX = ((width / patternLength) / 2 - 0.25) * (-1);  //Offset even pattern for previous candlestick
                        }
                        else    //Odd number pattern
                        {
                            Ymax = (int)(Math.Max(smcs.high, Math.Max(boundCandleSticks[i + 1].high, boundCandleSticks[i - 1].high)));
                            Ymin = (int)(Math.Min(smcs.low, Math.Min(boundCandleSticks[i + 1].low, boundCandleSticks[i - 1].low)));
                        }
                        double height = 40.0 * (Ymax - Ymin) / (chartMax - chartMin); ; //Scale height to chart bounds
                        rectangle.Height = height; rectangle.Width = width;             //Set width and hight
                        rectangle.Y = Ymax;                                             //Set Y to highest Y value for candlesticks
                        rectangle.BackColor = Color.Transparent;                        //Set area to transparent to see chart
                        rectangle.LineWidth = 2;                                        //Set perimeter width
                        rectangle.LineDashStyle = ChartDashStyle.Dash;                  //Set perimeter style to dashed
                                                                                        //Add annotation to chart
                        chart_stock.Annotations.Add(rectangle);
                    }

                    ArrowAnnotation arrow = new ArrowAnnotation(); // Create a new arrow annotation
                    arrow.AxisX = chart_stock.ChartAreas[0].AxisX; // Set the x axis of the arrow to the x axis of the stock chart area 
                    arrow.AxisY = chart_stock.ChartAreas[0].AxisY; // Set the y axis of the arrow to the y axis of the stock chart area
                    // Set the arrow's width and height
                    arrow.Width = 0.3;
                    arrow.Height = 0.3;
                    arrow.SetAnchor(dataPoint); // Anchor the arrow to the current data point
                    chart_stock.Annotations.Add(arrow); // Add the arrow annotation to the list of annotations of the chart
                }
            }
        }
    }
}
