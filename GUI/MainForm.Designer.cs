namespace Recorder
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Signals Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTestCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTrainingNFromJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTrainingFileFromJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTestingFileFromJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateJsonByTrainingDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateJsonFileByTestingDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.chart = new Accord.Controls.Wavechart();
            this.lbPosition = new System.Windows.Forms.Label();
            this.lbLength = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtw = new System.Windows.Forms.Button();
            this.Save_New_Record = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.username_box = new System.Windows.Forms.Label();
            this.test_new_record = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.run_sample = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadAudio1 = new System.Windows.Forms.Button();
            this.LoadAudio2 = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.withDTW = new System.Windows.Forms.RadioButton();
            this.WithPruning = new System.Windows.Forms.RadioButton();
            this.Distancee = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.loadFile = new System.Windows.Forms.Button();
            this.LoadFolder = new System.Windows.Forms.Button();
            this.With_DTW = new System.Windows.Forms.RadioButton();
            this.With_Pruning = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.accuracy_label = new System.Windows.Forms.Label();
            this.training_set_label = new System.Windows.Forms.Label();
            this.Time_For_load_training_Label = new System.Windows.Forms.Label();
            this.Testing_Label = new System.Windows.Forms.Label();
            this.time_For_loading_testing_label = new System.Windows.Forms.Label();
            this.time_matching_test_cases_label = new System.Windows.Forms.Label();
            this.accuracy_text_label = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.loadTestCaseToolStripMenuItem,
            this.loadTrainingNFromJsonToolStripMenuItem,
            this.optionsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1096, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(101, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(181, 20);
            this.optionsToolStripMenuItem.Text = "Load Train Test Case From txt";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // loadTestCaseToolStripMenuItem
            // 
            this.loadTestCaseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTestCaseToolStripMenuItem.Name = "loadTestCaseToolStripMenuItem";
            this.loadTestCaseToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
            this.loadTestCaseToolStripMenuItem.Text = "Load Test Case From txt";
            this.loadTestCaseToolStripMenuItem.Click += new System.EventHandler(this.loadTestCaseToolStripMenuItem_Click);
            // 
            // loadTrainingNFromJsonToolStripMenuItem
            // 
            this.loadTrainingNFromJsonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTrainingFileFromJsonToolStripMenuItem,
            this.loadTestingFileFromJsonToolStripMenuItem});
            this.loadTrainingNFromJsonToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTrainingNFromJsonToolStripMenuItem.Name = "loadTrainingNFromJsonToolStripMenuItem";
            this.loadTrainingNFromJsonToolStripMenuItem.Size = new System.Drawing.Size(180, 20);
            this.loadTrainingNFromJsonToolStripMenuItem.Text = "Load Test Case From Json File";
            this.loadTrainingNFromJsonToolStripMenuItem.Click += new System.EventHandler(this.loadTrainingNFromJsonToolStripMenuItem_Click);
            // 
            // loadTrainingFileFromJsonToolStripMenuItem
            // 
            this.loadTrainingFileFromJsonToolStripMenuItem.Name = "loadTrainingFileFromJsonToolStripMenuItem";
            this.loadTrainingFileFromJsonToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.loadTrainingFileFromJsonToolStripMenuItem.Text = "Load Training File From Json";
            this.loadTrainingFileFromJsonToolStripMenuItem.Click += new System.EventHandler(this.loadTrainingFileFromJsonToolStripMenuItem_Click);
            // 
            // loadTestingFileFromJsonToolStripMenuItem
            // 
            this.loadTestingFileFromJsonToolStripMenuItem.Name = "loadTestingFileFromJsonToolStripMenuItem";
            this.loadTestingFileFromJsonToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.loadTestingFileFromJsonToolStripMenuItem.Text = "Load Testing File From Json";
            this.loadTestingFileFromJsonToolStripMenuItem.Click += new System.EventHandler(this.loadTestingFileFromJsonToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetDataBaseToolStripMenuItem,
            this.generateJsonByTrainingDataToolStripMenuItem,
            this.generateJsonFileByTestingDataToolStripMenuItem});
            this.optionsToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.optionsToolStripMenuItem1.Text = "Options";
            // 
            // resetDataBaseToolStripMenuItem
            // 
            this.resetDataBaseToolStripMenuItem.Name = "resetDataBaseToolStripMenuItem";
            this.resetDataBaseToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.resetDataBaseToolStripMenuItem.Text = "Reset DataBase";
            this.resetDataBaseToolStripMenuItem.Click += new System.EventHandler(this.resetDataBaseToolStripMenuItem_Click);
            // 
            // generateJsonByTrainingDataToolStripMenuItem
            // 
            this.generateJsonByTrainingDataToolStripMenuItem.Name = "generateJsonByTrainingDataToolStripMenuItem";
            this.generateJsonByTrainingDataToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.generateJsonByTrainingDataToolStripMenuItem.Text = "Generate Json By Training Data";
            this.generateJsonByTrainingDataToolStripMenuItem.Click += new System.EventHandler(this.generateJsonByTrainingDataToolStripMenuItem_Click);
            // 
            // generateJsonFileByTestingDataToolStripMenuItem
            // 
            this.generateJsonFileByTestingDataToolStripMenuItem.Name = "generateJsonFileByTestingDataToolStripMenuItem";
            this.generateJsonFileByTestingDataToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.generateJsonFileByTestingDataToolStripMenuItem.Text = "Generate Json File By Testing Data";
            this.generateJsonFileByTestingDataToolStripMenuItem.Click += new System.EventHandler(this.generateJsonFileByTestingDataToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Wave files (*.wav)|*.wav";
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnStop.Location = new System.Drawing.Point(134, 107);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(55, 30);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "<";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecord.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnRecord.Location = new System.Drawing.Point(256, 107);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(55, 30);
            this.btnRecord.TabIndex = 4;
            this.btnRecord.Text = "=";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Black;
            this.chart.ForeColor = System.Drawing.Color.DarkGreen;
            this.chart.Location = new System.Drawing.Point(90, 27);
            this.chart.Name = "chart";
            this.chart.RangeX = ((AForge.DoubleRange)(resources.GetObject("chart.RangeX")));
            this.chart.RangeY = ((AForge.DoubleRange)(resources.GetObject("chart.RangeY")));
            this.chart.SimpleMode = false;
            this.chart.Size = new System.Drawing.Size(143, 41);
            this.chart.TabIndex = 6;
            this.chart.Text = "chart1";
            // 
            // lbPosition
            // 
            this.lbPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbPosition.Location = new System.Drawing.Point(12, 27);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(72, 41);
            this.lbPosition.TabIndex = 7;
            this.lbPosition.Text = "Position: 00.00 sec.";
            this.lbPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLength
            // 
            this.lbLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLength.Location = new System.Drawing.Point(239, 27);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(72, 41);
            this.lbLength.TabIndex = 7;
            this.lbLength.Text = "Length: 00.00 sec.";
            this.lbLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnAdd.Location = new System.Drawing.Point(12, 107);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "a";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlay.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnPlay.Location = new System.Drawing.Point(195, 107);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(55, 30);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "4";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIdentify.Font = new System.Drawing.Font("Webdings", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnIdentify.Location = new System.Drawing.Point(73, 107);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(55, 30);
            this.btnIdentify.TabIndex = 4;
            this.btnIdentify.Text = "s";
            this.btnIdentify.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 74);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(299, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "wav";
            this.saveFileDialog1.FileName = "file.wav";
            this.saveFileDialog1.Filter = "Wave files|*.wav|All files|*.*";
            this.saveFileDialog1.Title = "Save wave file";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // dtw
            // 
            this.dtw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtw.Location = new System.Drawing.Point(12, 180);
            this.dtw.Name = "dtw";
            this.dtw.Size = new System.Drawing.Size(136, 23);
            this.dtw.TabIndex = 11;
            this.dtw.Text = "DTW";
            this.dtw.UseVisualStyleBackColor = true;
            this.dtw.Click += new System.EventHandler(this.dtw_Click);
            // 
            // Save_New_Record
            // 
            this.Save_New_Record.Enabled = false;
            this.Save_New_Record.Location = new System.Drawing.Point(328, 86);
            this.Save_New_Record.Name = "Save_New_Record";
            this.Save_New_Record.Size = new System.Drawing.Size(136, 23);
            this.Save_New_Record.TabIndex = 12;
            this.Save_New_Record.Text = "Save New Record";
            this.Save_New_Record.UseVisualStyleBackColor = true;
            this.Save_New_Record.Click += new System.EventHandler(this.Save_New_Record_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(328, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // username_box
            // 
            this.username_box.AutoSize = true;
            this.username_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_box.Location = new System.Drawing.Point(350, 41);
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(79, 17);
            this.username_box.TabIndex = 16;
            this.username_box.Text = "username";
            this.username_box.Click += new System.EventHandler(this.username_box_Click);
            // 
            // test_new_record
            // 
            this.test_new_record.Enabled = false;
            this.test_new_record.Location = new System.Drawing.Point(328, 113);
            this.test_new_record.Name = "test_new_record";
            this.test_new_record.Size = new System.Drawing.Size(136, 23);
            this.test_new_record.TabIndex = 18;
            this.test_new_record.Text = "Find The Best Match";
            this.test_new_record.UseVisualStyleBackColor = true;
            this.test_new_record.Click += new System.EventHandler(this.test_new_record_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(276, 217);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(58, 20);
            this.textBox2.TabIndex = 20;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 26);
            this.button2.TabIndex = 21;
            this.button2.Text = "DTW With Pruning";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Pruning Width";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // run_sample
            // 
            this.run_sample.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.run_sample.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.run_sample.ForeColor = System.Drawing.Color.Black;
            this.run_sample.Location = new System.Drawing.Point(540, 257);
            this.run_sample.Name = "run_sample";
            this.run_sample.Size = new System.Drawing.Size(273, 38);
            this.run_sample.TabIndex = 19;
            this.run_sample.Text = "Compare File and number of Files";
            this.run_sample.UseVisualStyleBackColor = false;
            this.run_sample.Click += new System.EventHandler(this.run_sample_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(542, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Compare two files";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LoadAudio1
            // 
            this.LoadAudio1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadAudio1.ForeColor = System.Drawing.Color.Maroon;
            this.LoadAudio1.Location = new System.Drawing.Point(544, 60);
            this.LoadAudio1.Margin = new System.Windows.Forms.Padding(2);
            this.LoadAudio1.Name = "LoadAudio1";
            this.LoadAudio1.Size = new System.Drawing.Size(103, 31);
            this.LoadAudio1.TabIndex = 24;
            this.LoadAudio1.Text = "Load Input file";
            this.LoadAudio1.UseVisualStyleBackColor = true;
            this.LoadAudio1.Click += new System.EventHandler(this.LoadAudio1_Click);
            // 
            // LoadAudio2
            // 
            this.LoadAudio2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadAudio2.ForeColor = System.Drawing.Color.Maroon;
            this.LoadAudio2.Location = new System.Drawing.Point(668, 60);
            this.LoadAudio2.Margin = new System.Windows.Forms.Padding(2);
            this.LoadAudio2.Name = "LoadAudio2";
            this.LoadAudio2.Size = new System.Drawing.Size(103, 31);
            this.LoadAudio2.TabIndex = 25;
            this.LoadAudio2.Text = "Load Template file";
            this.LoadAudio2.UseVisualStyleBackColor = true;
            this.LoadAudio2.Click += new System.EventHandler(this.LoadAudio2_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(714, 108);
            this.test.Margin = new System.Windows.Forms.Padding(2);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(130, 28);
            this.test.TabIndex = 31;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1010, 80);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(55, 20);
            this.textBox3.TabIndex = 32;
            this.textBox3.UseWaitCursor = true;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(930, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Pruning Width";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // withDTW
            // 
            this.withDTW.AutoSize = true;
            this.withDTW.Checked = true;
            this.withDTW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.withDTW.Location = new System.Drawing.Point(794, 60);
            this.withDTW.Margin = new System.Windows.Forms.Padding(2);
            this.withDTW.Name = "withDTW";
            this.withDTW.Size = new System.Drawing.Size(54, 17);
            this.withDTW.TabIndex = 34;
            this.withDTW.TabStop = true;
            this.withDTW.Text = "DTW";
            this.withDTW.UseVisualStyleBackColor = true;
            this.withDTW.CheckedChanged += new System.EventHandler(this.withDTW_CheckedChanged_1);
            // 
            // WithPruning
            // 
            this.WithPruning.AutoSize = true;
            this.WithPruning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WithPruning.Location = new System.Drawing.Point(794, 80);
            this.WithPruning.Margin = new System.Windows.Forms.Padding(2);
            this.WithPruning.Name = "WithPruning";
            this.WithPruning.Size = new System.Drawing.Size(131, 17);
            this.WithPruning.TabIndex = 35;
            this.WithPruning.Text = "DTW With Pruning";
            this.WithPruning.UseVisualStyleBackColor = true;
            this.WithPruning.CheckedChanged += new System.EventHandler(this.WithPruning_CheckedChanged_1);
            // 
            // Distancee
            // 
            this.Distancee.AutoSize = true;
            this.Distancee.Location = new System.Drawing.Point(733, 166);
            this.Distancee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Distancee.Name = "Distancee";
            this.Distancee.Size = new System.Drawing.Size(0, 13);
            this.Distancee.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(602, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Distance : ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.DarkRed;
            this.Time.Location = new System.Drawing.Point(872, 149);
            this.Time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(58, 17);
            this.Time.TabIndex = 38;
            this.Time.Text = "Time : ";
            this.Time.Click += new System.EventHandler(this.Time_Click);
            // 
            // loadFile
            // 
            this.loadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFile.ForeColor = System.Drawing.Color.Maroon;
            this.loadFile.Location = new System.Drawing.Point(546, 296);
            this.loadFile.Margin = new System.Windows.Forms.Padding(2);
            this.loadFile.Name = "loadFile";
            this.loadFile.Size = new System.Drawing.Size(74, 27);
            this.loadFile.TabIndex = 39;
            this.loadFile.Text = "Load file";
            this.loadFile.UseVisualStyleBackColor = true;
            this.loadFile.Click += new System.EventHandler(this.loadFile_Click);
            // 
            // LoadFolder
            // 
            this.LoadFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadFolder.ForeColor = System.Drawing.Color.Maroon;
            this.LoadFolder.Location = new System.Drawing.Point(668, 300);
            this.LoadFolder.Margin = new System.Windows.Forms.Padding(2);
            this.LoadFolder.Name = "LoadFolder";
            this.LoadFolder.Size = new System.Drawing.Size(85, 28);
            this.LoadFolder.TabIndex = 40;
            this.LoadFolder.Text = "Load Folder";
            this.LoadFolder.UseVisualStyleBackColor = true;
            this.LoadFolder.Click += new System.EventHandler(this.LoadFolder_Click);
            // 
            // With_DTW
            // 
            this.With_DTW.AutoSize = true;
            this.With_DTW.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.With_DTW.Location = new System.Drawing.Point(794, 301);
            this.With_DTW.Margin = new System.Windows.Forms.Padding(2);
            this.With_DTW.Name = "With_DTW";
            this.With_DTW.Size = new System.Drawing.Size(54, 17);
            this.With_DTW.TabIndex = 41;
            this.With_DTW.Text = "DTW";
            this.With_DTW.UseVisualStyleBackColor = true;
            this.With_DTW.CheckedChanged += new System.EventHandler(this.With_DTW_CheckedChanged);
            // 
            // With_Pruning
            // 
            this.With_Pruning.AutoSize = true;
            this.With_Pruning.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.With_Pruning.Location = new System.Drawing.Point(794, 331);
            this.With_Pruning.Margin = new System.Windows.Forms.Padding(2);
            this.With_Pruning.Name = "With_Pruning";
            this.With_Pruning.Size = new System.Drawing.Size(131, 17);
            this.With_Pruning.TabIndex = 42;
            this.With_Pruning.Text = "DTW With Pruning";
            this.With_Pruning.UseVisualStyleBackColor = true;
            this.With_Pruning.CheckedChanged += new System.EventHandler(this.With_Pruning_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(924, 334);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Pruning Width";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(1005, 332);
            this.width.Margin = new System.Windows.Forms.Padding(2);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(58, 20);
            this.width.TabIndex = 44;
            this.width.TextChanged += new System.EventHandler(this.width_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(714, 359);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 26);
            this.button1.TabIndex = 45;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(543, 388);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 46;
            this.label6.Text = "Distance : ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(542, 456);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "Matched File : ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(870, 386);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 48;
            this.label8.Text = "Time :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 49;
            // 
            // accuracy_label
            // 
            this.accuracy_label.AutoSize = true;
            this.accuracy_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuracy_label.ForeColor = System.Drawing.Color.DarkRed;
            this.accuracy_label.Location = new System.Drawing.Point(113, 489);
            this.accuracy_label.Name = "accuracy_label";
            this.accuracy_label.Size = new System.Drawing.Size(24, 20);
            this.accuracy_label.TabIndex = 50;
            this.accuracy_label.Text = "%";
            this.accuracy_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accuracy_label.Click += new System.EventHandler(this.accuracy_label_Click);
            // 
            // training_set_label
            // 
            this.training_set_label.AutoSize = true;
            this.training_set_label.Location = new System.Drawing.Point(13, 247);
            this.training_set_label.Name = "training_set_label";
            this.training_set_label.Size = new System.Drawing.Size(70, 13);
            this.training_set_label.TabIndex = 51;
            this.training_set_label.Text = "Training Set :";
            this.training_set_label.Click += new System.EventHandler(this.training_set_label_Click);
            // 
            // Time_For_load_training_Label
            // 
            this.Time_For_load_training_Label.AutoSize = true;
            this.Time_For_load_training_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_For_load_training_Label.ForeColor = System.Drawing.Color.DarkRed;
            this.Time_For_load_training_Label.Location = new System.Drawing.Point(13, 266);
            this.Time_For_load_training_Label.Name = "Time_For_load_training_Label";
            this.Time_For_load_training_Label.Size = new System.Drawing.Size(204, 17);
            this.Time_For_load_training_Label.TabIndex = 52;
            this.Time_For_load_training_Label.Text = "Time Loading And Extract :";
            this.Time_For_load_training_Label.Click += new System.EventHandler(this.Time_For_load_training_Label_Click);
            // 
            // Testing_Label
            // 
            this.Testing_Label.AutoSize = true;
            this.Testing_Label.Location = new System.Drawing.Point(18, 324);
            this.Testing_Label.Name = "Testing_Label";
            this.Testing_Label.Size = new System.Drawing.Size(67, 13);
            this.Testing_Label.TabIndex = 53;
            this.Testing_Label.Text = "Testing Set :";
            this.Testing_Label.Click += new System.EventHandler(this.Testing_Label_Click);
            // 
            // time_For_loading_testing_label
            // 
            this.time_For_loading_testing_label.AutoSize = true;
            this.time_For_loading_testing_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_For_loading_testing_label.ForeColor = System.Drawing.Color.DarkRed;
            this.time_For_loading_testing_label.Location = new System.Drawing.Point(15, 342);
            this.time_For_loading_testing_label.Name = "time_For_loading_testing_label";
            this.time_For_loading_testing_label.Size = new System.Drawing.Size(204, 17);
            this.time_For_loading_testing_label.TabIndex = 54;
            this.time_For_loading_testing_label.Text = "Time Loading And Extract :";
            this.time_For_loading_testing_label.Click += new System.EventHandler(this.time_For_loading_testing_label_Click);
            // 
            // time_matching_test_cases_label
            // 
            this.time_matching_test_cases_label.AutoSize = true;
            this.time_matching_test_cases_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_matching_test_cases_label.ForeColor = System.Drawing.Color.DarkRed;
            this.time_matching_test_cases_label.Location = new System.Drawing.Point(18, 409);
            this.time_matching_test_cases_label.Name = "time_matching_test_cases_label";
            this.time_matching_test_cases_label.Size = new System.Drawing.Size(238, 17);
            this.time_matching_test_cases_label.TabIndex = 55;
            this.time_matching_test_cases_label.Text = "Time For Matching Test Cases :";
            this.time_matching_test_cases_label.Click += new System.EventHandler(this.time_matching_test_cases_label_Click);
            // 
            // accuracy_text_label
            // 
            this.accuracy_text_label.AutoSize = true;
            this.accuracy_text_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuracy_text_label.ForeColor = System.Drawing.Color.DarkRed;
            this.accuracy_text_label.Location = new System.Drawing.Point(17, 486);
            this.accuracy_text_label.Name = "accuracy_text_label";
            this.accuracy_text_label.Size = new System.Drawing.Size(97, 20);
            this.accuracy_text_label.TabIndex = 56;
            this.accuracy_text_label.Text = "Accuracy : ";
            this.accuracy_text_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.accuracy_text_label.Click += new System.EventHandler(this.accuracy_text_label_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1096, 546);
            this.Controls.Add(this.accuracy_text_label);
            this.Controls.Add(this.time_matching_test_cases_label);
            this.Controls.Add(this.time_For_loading_testing_label);
            this.Controls.Add(this.Testing_Label);
            this.Controls.Add(this.Time_For_load_training_Label);
            this.Controls.Add(this.training_set_label);
            this.Controls.Add(this.accuracy_label);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.width);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.With_Pruning);
            this.Controls.Add(this.With_DTW);
            this.Controls.Add(this.LoadFolder);
            this.Controls.Add(this.loadFile);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Distancee);
            this.Controls.Add(this.WithPruning);
            this.Controls.Add(this.withDTW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.test);
            this.Controls.Add(this.LoadAudio2);
            this.Controls.Add(this.LoadAudio1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.run_sample);
            this.Controls.Add(this.test_new_record);
            this.Controls.Add(this.username_box);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Save_New_Record);
            this.Controls.Add(this.dtw);
            this.Controls.Add(this.lbLength);
            this.Controls.Add(this.lbPosition);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnIdentify);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.trackBar1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Speaker Identification";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private Accord.Controls.Wavechart chart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ToolStripMenuItem loadTestCaseToolStripMenuItem;
        private System.Windows.Forms.Button dtw;
        private System.Windows.Forms.Button Save_New_Record;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label username_box;
        private System.Windows.Forms.Button test_new_record;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem loadTrainingNFromJsonToolStripMenuItem;
        private System.Windows.Forms.Button run_sample;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoadAudio1;
        private System.Windows.Forms.Button LoadAudio2;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton withDTW;
        private System.Windows.Forms.RadioButton WithPruning;
        private System.Windows.Forms.Label Distancee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Button loadFile;
        private System.Windows.Forms.Button LoadFolder;
        private System.Windows.Forms.RadioButton With_DTW;
        private System.Windows.Forms.RadioButton With_Pruning;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTrainingFileFromJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTestingFileFromJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetDataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateJsonByTrainingDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateJsonFileByTestingDataToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label accuracy_label;
        private System.Windows.Forms.Label training_set_label;
        private System.Windows.Forms.Label Time_For_load_training_Label;
        private System.Windows.Forms.Label Testing_Label;
        private System.Windows.Forms.Label time_For_loading_testing_label;
        private System.Windows.Forms.Label time_matching_test_cases_label;
        private System.Windows.Forms.Label accuracy_text_label;
    }
}
