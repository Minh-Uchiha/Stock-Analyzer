namespace WindowsForms_COP_4365_001
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_open_ticker = new System.Windows.Forms.Button();
            this.openFileDialog_openTicker = new System.Windows.Forms.OpenFileDialog();
            this.chart_stock = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bindingSource_boundTickerList = new System.Windows.Forms.BindingSource(this.components);
            this.button_update = new System.Windows.Forms.Button();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.comboBox_pattern = new System.Windows.Forms.ComboBox();
            this.label_pattern = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_boundTickerList)).BeginInit();
            this.SuspendLayout();
            // 
            // button_open_ticker
            // 
            this.button_open_ticker.BackColor = System.Drawing.Color.DarkViolet;
            this.button_open_ticker.ForeColor = System.Drawing.SystemColors.Control;
            this.button_open_ticker.Location = new System.Drawing.Point(279, 576);
            this.button_open_ticker.Name = "button_open_ticker";
            this.button_open_ticker.Size = new System.Drawing.Size(136, 63);
            this.button_open_ticker.TabIndex = 0;
            this.button_open_ticker.Text = "Open Ticker";
            this.button_open_ticker.UseVisualStyleBackColor = false;
            this.button_open_ticker.Click += new System.EventHandler(this.button_open_ticker_Click);
            // 
            // openFileDialog_openTicker
            // 
            this.openFileDialog_openTicker.FileName = "IBM";
            this.openFileDialog_openTicker.Filter = "CSV files (*.csv)|*.csv|Monthly|*-Month.csv|Weekly|*-Week.csv|Daily|*-Day.csv";
            this.openFileDialog_openTicker.FilterIndex = 2;
            this.openFileDialog_openTicker.InitialDirectory = "G:\\University Materials\\YEAR III\\Semester II\\CIS 4930\\Stock Data";
            this.openFileDialog_openTicker.Multiselect = true;
            this.openFileDialog_openTicker.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_openTicker_FileOk);
            // 
            // chart_stock
            // 
            chartArea1.Name = "ChartArea_stock";
            chartArea2.AlignWithChartArea = "ChartArea_stock";
            chartArea2.Name = "ChartArea_volume";
            this.chart_stock.ChartAreas.Add(chartArea1);
            this.chart_stock.ChartAreas.Add(chartArea2);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Enabled = false;
            legend1.Name = "Legend_Stock";
            this.chart_stock.Legends.Add(legend1);
            this.chart_stock.Location = new System.Drawing.Point(28, 20);
            this.chart_stock.Name = "chart_stock";
            series1.ChartArea = "ChartArea_stock";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=LimeGreen";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend_Stock";
            series1.Name = "Series_stock";
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "High,Low,Open,Close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_volume";
            series2.Legend = "Legend_Stock";
            series2.Name = "Series_volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            this.chart_stock.Series.Add(series1);
            this.chart_stock.Series.Add(series2);
            this.chart_stock.Size = new System.Drawing.Size(957, 512);
            this.chart_stock.TabIndex = 2;
            this.chart_stock.Text = "chart1";
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.DarkViolet;
            this.button_update.ForeColor = System.Drawing.SystemColors.Control;
            this.button_update.Location = new System.Drawing.Point(595, 576);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(136, 63);
            this.button_update.TabIndex = 3;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(28, 610);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(245, 22);
            this.dateTimePicker_startDate.TabIndex = 4;
            this.dateTimePicker_startDate.Value = new System.DateTime(2022, 1, 1, 20, 53, 0, 0);
            this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.dateTimePicker_startDate_ValueChanged);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(737, 610);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(248, 22);
            this.dateTimePicker_endDate.TabIndex = 5;
            this.dateTimePicker_endDate.ValueChanged += new System.EventHandler(this.dateTimePicker_endDate_ValueChanged);
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_startDate.ForeColor = System.Drawing.Color.DarkViolet;
            this.label_startDate.Location = new System.Drawing.Point(92, 576);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(99, 25);
            this.label_startDate.TabIndex = 6;
            this.label_startDate.Text = "Start Date";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_endDate.ForeColor = System.Drawing.Color.DarkViolet;
            this.label_endDate.Location = new System.Drawing.Point(815, 576);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(93, 25);
            this.label_endDate.TabIndex = 7;
            this.label_endDate.Text = "End Date";
            // 
            // comboBox_pattern
            // 
            this.comboBox_pattern.FormattingEnabled = true;
            this.comboBox_pattern.Location = new System.Drawing.Point(421, 608);
            this.comboBox_pattern.Name = "comboBox_pattern";
            this.comboBox_pattern.Size = new System.Drawing.Size(168, 24);
            this.comboBox_pattern.TabIndex = 8;
            this.comboBox_pattern.SelectedIndexChanged += new System.EventHandler(this.comboBox_pattern_SelectedIndexChanged);
            // 
            // label_pattern
            // 
            this.label_pattern.AutoSize = true;
            this.label_pattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pattern.ForeColor = System.Drawing.Color.DarkViolet;
            this.label_pattern.Location = new System.Drawing.Point(441, 576);
            this.label_pattern.Name = "label_pattern";
            this.label_pattern.Size = new System.Drawing.Size(130, 25);
            this.label_pattern.TabIndex = 9;
            this.label_pattern.Text = "Pick a pattern";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 651);
            this.Controls.Add(this.label_pattern);
            this.Controls.Add(this.comboBox_pattern);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.chart_stock);
            this.Controls.Add(this.button_open_ticker);
            this.Name = "Form_Main";
            this.Text = "Please pick a stock";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_boundTickerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_open_ticker;
        private System.Windows.Forms.OpenFileDialog openFileDialog_openTicker;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stock;
        private System.Windows.Forms.BindingSource bindingSource_boundTickerList;
        private System.Windows.Forms.DataGridViewTextBoxColumn openDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.ComboBox comboBox_pattern;
        private System.Windows.Forms.Label label_pattern;
    }
}

