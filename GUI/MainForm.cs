using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Accord.Audio;
using Accord.Audio.Formats;
using Accord.DirectSound;
using Accord.Audio.Filters;
using Recorder.Recorder;
using Recorder.MFCC;
using Recorder.MainFuctions;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace Recorder
{
    /// <summary>
    ///   Speaker Identification application.
    /// </summary>
    /// 
    public partial class MainForm : Form
    {
        /// <summary>
        /// Data of the opened audio file, contains:
        ///     1. signal data
        ///     2. sample rate
        ///     3. signal length in ms
        /// </summary>
        private AudioSignal signal = null;
        Sequence seq = null;
        static string username;
       static int pruningWidth=-1;
        static string accuracy;

        private string path;
       static bool OPEN_FILE = false;
        List<Sequence> sequences_list = new List<Sequence>();
        private Encoder encoder;
        private Decoder decoder;

        private bool isRecorded;

        ///to be added 
        private static int PruningOrNot = 2;
        Sequence seq1 = null;
        Sequence seq2 = null;
        private static int Pwidth = -1;
        private static string DistanceForTwo = "";
        private static string TimeForTwo = "";
        private static int forPruning = -1;

        Sequence seq3 = null;
        Dictionary<int, Sequence> audioMap = new Dictionary<int, Sequence>();
        Dictionary<int, String> nameMAP = new Dictionary<int, String>();
        private static string FolderPath=null;
        private static int PruningOrNot2 = 2;
        private static int forPruning2 = -1;
        private static int Pwidth2 = -1;
        private static string DistanceForoneandFolder = "";
        private static string TimeForoneansfolder = "";
        private static double time1inms=0;   //for milli seconds
        private static double time2ins = 0;  //for seconds
        private static double time3inm = 0;  //for minutes
        private static string name = "";
        private static string Distance = "";
        private static int removeSil = 1;
        private static string timeTrain = "";
        private static string timeTest = "";
        private static string timeMatch = "";
        //private static int Pwidth = -1;
        public MainForm()
        {
            InitializeComponent();

            // Configure the wavechart
            chart.SimpleMode = true;
            chart.AddWaveform("wave", Color.Green, 1, false);
            updateButtons();
        }

        /// <summary>
        ///   Starts recording audio from the sound card
        /// </summary>
        /// 
        private void btnRecord_Click(object sender, EventArgs e)
        {
            isRecorded = true;
            this.encoder = new Encoder(source_NewFrame, source_AudioSourceError);
            this.encoder.Start();
            updateButtons();
            OPEN_FILE = false;
            Save_New_Record.Enabled = false;
            test_new_record.Enabled=false;

        }

        /// <summary>
        ///   Plays the recorded audio stream.
        /// </summary>
        /// 
        private void btnPlay_Click(object sender, EventArgs e)
        {
            InitializeDecoder();
            // Configure the track bar so the cursor
            // can show the proper current position
            if (trackBar1.Value < this.decoder.frames)
                this.decoder.Seek(trackBar1.Value);
            trackBar1.Maximum = this.decoder.samples;
            this.decoder.Start();
            updateButtons();
        }

        private void InitializeDecoder()
        {
            if (isRecorded)
            {
                // First, we rewind the stream
                this.encoder.stream.Seek(0, SeekOrigin.Begin);
                this.decoder = new Decoder(this.encoder.stream, this.Handle, output_AudioOutputError, output_FramePlayingStarted, output_NewFrameRequested, output_PlayingFinished);
            }
            else
            {
                this.decoder = new Decoder(this.path, this.Handle, output_AudioOutputError, output_FramePlayingStarted, output_NewFrameRequested, output_PlayingFinished);
            }
        }

        /// <summary>
        ///   Stops recording or playing a stream.
        /// </summary>
        /// 
        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
            //testsaveAudio();
            updateButtons();
            updateWaveform(new float[BaseRecorder.FRAME_SIZE], BaseRecorder.FRAME_SIZE);
            Save_New_Record.Enabled = true;
            test_new_record.Enabled = true;
            saveAudio();
        }
        public void saveAudio()
        {
            var saveFileDialog_rec = new SaveFileDialog();
            if (!OPEN_FILE)
            {
                saveFileDialog_rec.FileName = Directory.GetCurrentDirectory() + "\\DataBase\\rec_temp.wav";
                Console.WriteLine(saveFileDialog_rec.FileName);
                if (this.encoder != null)
                {
                    using (Stream fileStream = saveFileDialog_rec.OpenFile())
                    {
                        this.encoder.Save(fileStream);
                    }
                }
                AudioSignal rec_signal = AudioOperations.OpenAudioFile(saveFileDialog_rec.FileName);
                rec_signal = AudioOperations.RemoveSilence(rec_signal);
                seq = AudioOperations.ExtractFeatures(rec_signal);
                Console.WriteLine(seq.Frames.Length);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(saveFileDialog_rec.FileName);
            }
        }


        /// <summary>
        ///   This callback will be called when there is some error with the audio 
        ///   source. It can be used to route exceptions so they don't compromise 
        ///   the audio processing pipeline.
        /// </summary>
        /// 
        private void source_AudioSourceError(object sender, AudioSourceErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }

        /// <summary>
        ///   This method will be called whenever there is a new input audio frame 
        ///   to be processed. This would be the case for samples arriving at the 
        ///   computer's microphone
        /// </summary>
        /// 
        private void source_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.encoder.addNewFrame(eventArgs.Signal);
            updateWaveform(this.encoder.current, eventArgs.Signal.Length);
       }


        /// <summary>
        ///   This event will be triggered as soon as the audio starts playing in the 
        ///   computer speakers. It can be used to update the UI and to notify that soon
        ///   we will be requesting additional frames.
        /// </summary>
        /// 
        private void output_FramePlayingStarted(object sender, PlayFrameEventArgs e)
        {
            updateTrackbar(e.FrameIndex);

            if (e.FrameIndex + e.Count < this.decoder.frames)
            {
                int previous = this.decoder.Position;
                decoder.Seek(e.FrameIndex);

                Signal s = this.decoder.Decode(e.Count);
                decoder.Seek(previous);

                updateWaveform(s.ToFloat(), s.Length);
            }
        }

        /// <summary>
        ///   This event will be triggered when the output device finishes
        ///   playing the audio stream. Again we can use it to update the UI.
        /// </summary>
        /// 
        private void output_PlayingFinished(object sender, EventArgs e)
        {
            updateButtons();
            updateWaveform(new float[BaseRecorder.FRAME_SIZE], BaseRecorder.FRAME_SIZE);
        }

        /// <summary>
        ///   This event is triggered when the sound card needs more samples to be
        ///   played. When this happens, we have to feed it additional frames so it
        ///   can continue playing.
        /// </summary>
        /// 
        private void output_NewFrameRequested(object sender, NewFrameRequestedEventArgs e)
        {
            this.decoder.FillNewFrame(e);
        }


        void output_AudioOutputError(object sender, AudioOutputErrorEventArgs e)
        {
            throw new Exception(e.Description);
        }

        /// <summary>
        ///   Updates the audio display in the wave chart
        /// </summary>
        /// 
        private void updateWaveform(float[] samples, int length)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    chart.UpdateWaveform("wave", samples, length);
                }));
            }
            else
            {
                if (this.encoder != null) { chart.UpdateWaveform("wave", this.encoder.current, length); }
            }
        }

        /// <summary>
        ///   Updates the current position at the trackbar.
        /// </summary>
        /// 
        private void updateTrackbar(int value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    trackBar1.Value = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, value));
                }));
            }
            else
            {
                trackBar1.Value = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, value));
            }
        }

        private void updateButtons()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(updateButtons));
                return;
            }

            if (this.encoder != null && this.encoder.IsRunning())
            {
                btnAdd.Enabled = false;
                btnIdentify.Enabled = false;
                btnPlay.Enabled = false;
                btnStop.Enabled = true;
                btnRecord.Enabled = false;
                trackBar1.Enabled = false;
            }
            else if (this.decoder != null && this.decoder.IsRunning())
            {
                btnAdd.Enabled = false;
                btnIdentify.Enabled = false;
                btnPlay.Enabled = false;
                btnStop.Enabled = true;
                btnRecord.Enabled = false;
                trackBar1.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = this.path != null || this.encoder != null;
                btnIdentify.Enabled = false;
                btnPlay.Enabled = this.path != null || this.encoder != null;//stream != null;
                btnStop.Enabled = false;
                btnRecord.Enabled = true;
                trackBar1.Enabled = this.decoder != null;
                trackBar1.Value = 0;
            }
        }

        private void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.encoder != null)
            {
                Stream fileStream = saveFileDialog1.OpenFile();
                this.encoder.Save(fileStream);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog(this);
            Console.WriteLine(path);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (this.encoder != null) { lbLength.Text = String.Format("Length: {0:00.00} sec.", this.encoder.duration / 1000.0); }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                isRecorded = false;
                path = open.FileName;
                //Open the selected audio file
                signal = AudioOperations.OpenAudioFile(path);
                signal = AudioOperations.RemoveSilence(signal);
                 seq = AudioOperations.ExtractFeatures(signal);
                OPEN_FILE = true;///
                for (int i = 0; i < seq.Frames.Length; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {

                        if (double.IsNaN(seq.Frames[i].Features[j]) || double.IsInfinity(seq.Frames[i].Features[j]))
                            throw new Exception("NaN");
                    }
                }
                updateButtons();
                Save_New_Record.Enabled = true;
                test_new_record.Enabled = true;

            }
        }

        private void Stop()
        {
            if (this.encoder != null) { this.encoder.Stop(); }
            if (this.decoder != null) { this.decoder.Stop(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.decoder.Start();



        }



        //private void trainCase3ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    String FileName = "\\train_case3.xlsx";
        //    trainNcase(FileName);
        //}

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String FileName = "TestCase.xlsx";
            trainNcase(FileName, 1);
           
        }

        private void loadTestCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            Stopwatch stopwatch = new Stopwatch();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                SequenceMatching.sequenceTest.Clear();
                List<User> hobba;
                stopwatch.Start();
                hobba = TestcaseLoader.LoadTestcase1Testing(fileDialog.FileName);

                
                //Console.WriteLine("loaded");
                if (hobba != null)
                {

                  



                    for (int i = 0; i < hobba.Count; i++)
                    {
                        List<AudioSignal> signals_list = hobba[i].UserTemplates;


                        List<Sequence> list = new List<Sequence>();

                        for (int j = 0; j < signals_list.Count; j++)
                        {


                            AudioSignal signal = signals_list[j];
                            //signal = AudioOperations.RemoveSilence(signal);
                            Sequence sequence = AudioOperations.ExtractFeatures(signal);
                            list.Add(sequence);
                        }
                        DataOperations.Person_template copy = new DataOperations.Person_template();
                        copy.sequences = list;
                        copy.name = hobba[i].UserName;
                        SequenceMatching.sequenceTest[i] = copy;



                        Console.WriteLine("person " + hobba[i].UserName);
                    }
                    //Console.WriteLine(SequenceMatching.sequenceTest.Count);
                    //Console.WriteLine(SequenceMatching.sequenceTest[0].sequences[0].Frames.Length);
                    stopwatch.Stop();
                    MessageBox.Show("Testing Data Loaded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    Console.WriteLine("Test case Loaded");
                    timeTest = "Loading and Extract Test " + Convert.ToString(stopwatch.Elapsed.TotalSeconds) + " s";
                    time_For_loading_testing_label.Text = timeTest;
                    Console.WriteLine("Time Loading And Extract Testing Set: " + stopwatch.Elapsed.TotalSeconds + " s");
                }
            }
        }
    

    
        private void trainNcase(String Filename,int test)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            Stopwatch stopwatch=new Stopwatch();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                stopwatch.Start();
                var splittedPath = fileDialog.FileName.Split('\\');
                String path = splittedPath[splittedPath.Length - 1];
                path = path.Replace(".txt", "");
                List<User> users;
                
                users = TestcaseLoader.LoadTestcase1Training(fileDialog.FileName);




                //Console.WriteLine("loaded");

                if (users != null)
                {

                    DataOperations.sequenceMap.Clear();


                    DataOperations dataOperations = new DataOperations(DataOperations.folder + "\\" + path + "_" + Filename);
                    var map = new Dictionary<int, List<Sequence>>();
                    var NamesMap = new Dictionary<int, String>();


                    for (int i = 0; i < users.Count; i++)
                    {
                        List<AudioSignal> signals_list = users[i].UserTemplates;

                        List<Sequence> list = new List<Sequence>();

                        for (int j = 0; j < signals_list.Count; j++)
                        {

                            AudioSignal signal = signals_list[j];
                            //signal = AudioOperations.RemoveSilence(signal);
                            Sequence sequence = AudioOperations.ExtractFeatures(signal);
                            list.Add(sequence);
                            //Console.WriteLine("index " + i + " " + sequence.Frames.Length);
                            //Console.WriteLine("index " + i + " " + sequence.Frames[0].Features[0]);
                        }




                        DataOperations.Person_template copy = new DataOperations.Person_template();
                        copy.sequences = list;
                        copy.name = users[i].UserName;
                        DataOperations.sequenceMap[i] = copy;

                        Console.WriteLine("person " + i);
                    }


                    //for (int i = 0; i < DataOperations.sequenceMap.Count; i++)
                    //{
                    //    //Console.WriteLine(DataOperations.sequenceMap[i].sequences[0].Frames.Length);

                    //}

                    stopwatch.Stop();
                    MessageBox.Show("Training Data Loaded Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    timeTrain = "Loading and Extract Train "+Convert.ToString(stopwatch.Elapsed.TotalSeconds)+" s";
                    Time_For_load_training_Label.Text = timeTrain;
                    Console.WriteLine("Time Loading And Extract: " + stopwatch.Elapsed.TotalSeconds + " s");
                    //dataOperations.StoreSequenceData();

                }
            }
        }


        static Semaphore semaphore = new Semaphore(1, 1);
        private void dtw_Click(object sender, EventArgs e)
        {
            if (DataOperations.sequenceMap.Count == 0)
            {
                MessageBox.Show("Please Load Training Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SequenceMatching.sequenceTest.Count == 0)
            {
                MessageBox.Show("Please Load Testing Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            textBox2.Text = "";
            Time_For_load_training_Label.Text = "Loading and Extract Train : ";
            time_For_loading_testing_label.Text = "Loading and Extract Test : ";
            accuracy_text_label.Text = "Accuracy : ";
            time_matching_test_cases_label.Text = "Matching Time ";
            accuracy_label.Text = "%";

            Stopwatch stopwatch = new Stopwatch();
            double cnt = 0;
            double true_match = 0;

            stopwatch.Start();

            object lockObj = new object(); // for thread-safe updates

            Parallel.For(0, SequenceMatching.sequenceTest.Count, k =>
            {
                var test_person = SequenceMatching.sequenceTest[k].sequences;

                for (int m = 0; m < test_person.Count; m++)
                {
                    double temp;
                    string bestMatch = "not_found";
                    double mn = double.PositiveInfinity;

                    for (int i = 0; i < DataOperations.sequenceMap.Count; i++)
                    {
                        var person = DataOperations.sequenceMap[i].sequences;

                        for (int j = 0; j < person.Count; j++)
                        {
                            temp = SequenceMatching.DTW(test_person[m], person[j]);

                            if (mn >= temp)
                            {
                                mn = temp;
                                bestMatch = DataOperations.sequenceMap[i].name;
                            }
                        }
                    }

                    semaphore.WaitOne();
                        if (bestMatch.Equals(SequenceMatching.sequenceTest[k].name))
                            true_match++;

                        cnt++;
                    //Console.WriteLine(bestMatch);
                    semaphore.Release();
                }
            });

            stopwatch.Stop();

            if (stopwatch.Elapsed.TotalSeconds >= 1)
                Console.WriteLine("Time for Matching " + stopwatch.Elapsed.TotalSeconds + " S");
            else
                Console.WriteLine("Time for Matching " + stopwatch.ElapsedMilliseconds + " ms");

            double acc = (true_match / cnt) * 100;
            Console.WriteLine("Accuracy :" + acc);

            Time_For_load_training_Label.Text = timeTrain;
            time_For_loading_testing_label.Text = timeTest;
            time_matching_test_cases_label.Text = "Matching Time : " + stopwatch.Elapsed.TotalSeconds + " s";
            accuracy_label.Text = acc + "%";
        }


    

       

        private void Save_New_Record_Click(object sender, EventArgs e)
        {
            //username_box.ge
            //saveFileDialog1.ShowDialog(this);
          

            if (username != null && username.Length > 0 && seq != null)
            {
                bool found = false;
                for (int i = 0; i < DataOperations.data_base_sequence.Count; i++)
                {
                    if (DataOperations.data_base_sequence[i].name.Equals(username))
                    {
                        found = true;
                        DataOperations.data_base_sequence[i].sequences.Add(seq);


                    }


                }
                if (!found)
                {
                    int id = DataOperations.data_base_sequence.Count;
                    DataOperations.Person_template person_Template = new DataOperations.Person_template();
                    person_Template.sequences=new List<Sequence>();
                    person_Template.name=username;
                    DataOperations.data_base_sequence[id]=person_Template;
                    DataOperations.data_base_sequence[id].sequences.Add(seq);



                }
                DataOperations.save_js_file(DataOperations.data_base_sequence,( Directory.GetCurrentDirectory() + "\\DataBase\\databaseFile.json"));
                MessageBox.Show("The Audio Added Successfuly", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Save_New_Record.Enabled = false;
                test_new_record.Enabled = false;
                if (username.Length > 0)
                {
                    textBox1.Text = username.Remove(username.Length - 1);
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
            else if (username == null || username.Length == 0)
            {
                MessageBox.Show("Enter Username", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Record or Enter an Audio File", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

      
        private void test_new_record_Click(object sender, EventArgs e)
        {

            Console.WriteLine("name " + username);

            double temp;
            double mn=double.PositiveInfinity;
            int bestPerson=int.MaxValue, best_seq=-1;
                    for (int i = 0; i < DataOperations.data_base_sequence.Count; i++)
                    {
                        var person_seq = DataOperations.data_base_sequence[i].sequences;

                        for (int j = 0; j < person_seq.Count; j++)
                        {
                    Console.WriteLine("in "+seq.Frames.Length + " temp " + person_seq[j].Frames.Length);
                            temp = SequenceMatching.DTW(seq, person_seq[j]);
                            //Console.WriteLine("index " + temp);
                            //Console.WriteLine("index " + i+"value "+temp);
                            if (temp <= mn)
                            {
                                mn = temp;
                                bestPerson = i;
                                best_seq = j;
                            }
                        }
                    }
            if (bestPerson != int.MaxValue)
            {
                Console.WriteLine(DataOperations.data_base_sequence[bestPerson].name);
                Console.WriteLine("min " + mn);
                DataOperations.data_base_sequence[bestPerson].sequences.Add(seq);
                MessageBox.Show("This Record Match with "+ DataOperations.data_base_sequence[bestPerson].name, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataOperations.save_js_file(DataOperations.data_base_sequence, (Directory.GetCurrentDirectory() + "\\DataBase\\databaseFile.json"));
                Save_New_Record.Enabled = false;
                test_new_record.Enabled = false;
            }
            else
            {
                Console.WriteLine("Database Not Found");
            }

        }
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z]*$"))
            {
                MessageBox.Show("Please enter only alphabetic characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (username.Length > 0)
                {
                    textBox1.Text = username.Remove(username.Length - 1);
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                pruningWidth = 0;
                return;
            }
            if (int.TryParse(textBox.Text, out int value))
            {
                pruningWidth = value;
            }
            else
            {
                MessageBox.Show("Please enter only numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (textBox.Text.Length > 0)
                {
                    int cursorPosition = textBox.SelectionStart - 1;
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                    textBox.SelectionStart = Math.Max(0, cursorPosition);
                }

                pruningWidth = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (DataOperations.sequenceMap.Count == 0)
            {
                MessageBox.Show("Please Load Training Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (SequenceMatching.sequenceTest.Count == 0)
            {
                MessageBox.Show("Please Load Testing Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            Time_For_load_training_Label.Text = "Loading and Extract Train : ";
            time_For_loading_testing_label.Text = "Loading and Extract Test : ";
            accuracy_text_label.Text = "Accuracy : ";
            time_matching_test_cases_label.Text = "Matching Time ";
            accuracy_label.Text = "%";
         
            
            Stopwatch stopwatch = new Stopwatch();
            double cnt = 0;
            double true_match = 0;
            stopwatch.Start();
          
            Parallel.For(0, SequenceMatching.sequenceTest.Count, k =>
            {
                var test_person = SequenceMatching.sequenceTest[k].sequences;

                for (int m = 0; m < test_person.Count; m++)
                {
                    double temp;
                    string bestMatch = "not_found";
                    double mn = double.PositiveInfinity;

                    for (int i = 0; i < DataOperations.sequenceMap.Count; i++)
                    {
                        var person = DataOperations.sequenceMap[i].sequences;

                        for (int j = 0; j < person.Count; j++)
                        {
                            temp = SequenceMatching.DTWPruning(test_person[m], person[j], pruningWidth);

                            if (mn >= temp)
                            {
                                mn = temp;
                                bestMatch = DataOperations.sequenceMap[i].name;
                            }
                        }
                    }

                    semaphore.WaitOne();
                    if (bestMatch.Equals(SequenceMatching.sequenceTest[k].name))
                            true_match++;

                        cnt++;
                    //Console.WriteLine(bestMatch);
                    semaphore.Release();
                }
            });

            stopwatch.Stop();
            if (stopwatch.Elapsed.TotalSeconds >= 1)
                Console.WriteLine("Time for Matching " + stopwatch.Elapsed.TotalSeconds + " S");
            else
            {
                Console.WriteLine("Time for Matching " + stopwatch.ElapsedMilliseconds + " ms");
            }
            double acc = (true_match / cnt) * 100;
            Console.WriteLine("Accuracy :" + acc);
            Time_For_load_training_Label.Text = timeTrain;
            time_For_loading_testing_label.Text = timeTest;
            time_matching_test_cases_label.Text = "Matching Time : " + stopwatch.Elapsed.TotalSeconds + " s";
            
            accuracy_label.Text = acc + "%";

            textBox2.Text = "";
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataOperations.data_base_sequence = DataOperations.read_js_file((Directory.GetCurrentDirectory() + "\\DataBase\\databaseFile.json"));
            }
            catch {
                Console.WriteLine("File Not Found");
            }

        }

        private void LoadAudio1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                isRecorded = false;
                path = open.FileName;
                //Open the selected audio file
                signal = AudioOperations.OpenAudioFile(path);
                signal = AudioOperations.RemoveSilence(signal);
                seq1 = AudioOperations.ExtractFeatures(signal);
                OPEN_FILE = true;///
                for (int i = 0; i < seq1.Frames.Length; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {

                        if (double.IsNaN(seq1.Frames[i].Features[j]) || double.IsInfinity(seq1.Frames[i].Features[j]))
                            throw new Exception("NaN");
                    }
                }

                MessageBox.Show("Audio Loaded Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


        private void LoadAudio2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                isRecorded = false;
                path = open.FileName;
                //Open the selected audio file
                signal = AudioOperations.OpenAudioFile(path);
                signal = AudioOperations.RemoveSilence(signal);
                seq2 = AudioOperations.ExtractFeatures(signal);
                OPEN_FILE = true;///
                for (int i = 0; i < seq2.Frames.Length; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {

                        if (double.IsNaN(seq2.Frames[i].Features[j]) || double.IsInfinity(seq2.Frames[i].Features[j]))
                            throw new Exception("NaN");
                    }
                }
                MessageBox.Show("Audio Loaded Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            return;
        }

        private void test_Click(object sender, EventArgs e)
        {
            
            if (seq1 == null)
            {
                MessageBox.Show("Please enter your first audio", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (seq2 == null)
            {
                MessageBox.Show("Please enter your Second audio", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PruningOrNot == 2)
            {
                MessageBox.Show("Please choose DTW Or DTW With Pruning", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PruningOrNot == 0)
            {
                DistanceForTwo = "";
                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                double Distance= SequenceMatching.DTW(seq1, seq2);
                Watch.Stop();
                long milisec = Watch.ElapsedMilliseconds;
                double seconds = Watch.Elapsed.TotalSeconds;
                double minutes = Watch.Elapsed.TotalMinutes;
                string ms = Convert.ToString(milisec);
                string s = Convert.ToString(seconds);
                string m = Convert.ToString(minutes);
                TimeForTwo = "milliseconds : " + ms + "\n";
                if (seconds >= 1)
                {
                    TimeForTwo += "seconds : " + s + "\n";
                }
                if (minutes >= 1)
                {
                    TimeForTwo += "minutes : " + m;
                }
                string ans = Convert.ToString(Distance);
                DistanceForTwo = "Distance : " + ans;
                label4.Text = DistanceForTwo;
                Time.Text = TimeForTwo;
            }
            else if (PruningOrNot == 1)
            {
                DistanceForTwo = "";
                if (Pwidth == -1)
                {
                    MessageBox.Show("Please enter Pruning Width", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    DistanceForTwo = "";
                    Stopwatch Watch = new Stopwatch();
                  
                    Watch.Start();
                    double Distance = SequenceMatching.DTWPruning(seq1, seq2, Pwidth);
                    Watch.Stop();
                    long milisec = Watch.ElapsedMilliseconds;
                    double seconds = Watch.Elapsed.TotalSeconds;
                    double minutes = Watch.Elapsed.TotalMinutes;
                    string ms = Convert.ToString(milisec);
                    string s = Convert.ToString(seconds);
                    string m = Convert.ToString(minutes);
                    TimeForTwo = "milliseconds : " + ms + "\n";
                    if (seconds >= 1)
                    {
                        TimeForTwo += "seconds : " + s + "\n";
                    }
                    if (minutes >= 1)
                    {
                        TimeForTwo += "minutes : " + m;
                    }
                    string ans = Convert.ToString(Distance);
                    DistanceForTwo = "Distance : " + ans;
                    label4.Text = DistanceForTwo;
                    Time.Text = TimeForTwo;
                }   
            }
            else
            {
                MessageBox.Show("Please choose with Pruning or not", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WithPruning_CheckedChanged_1(object sender, EventArgs e)
        {
            PruningOrNot = 1;
            forPruning = 1;
        }

        private void withDTW_CheckedChanged_1(object sender, EventArgs e)
        {
            forPruning = 0;
            PruningOrNot = 0;
            if (!string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Clear();                  
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(forPruning==1)
            {
                TextBox textBox = sender as TextBox;
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Please enter Pruning Width.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (int.TryParse(textBox.Text, out int value))
                {
                    Pwidth = value;
                }
                else
                {
                    MessageBox.Show("Please enter only numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (textBox.Text.Length > 0)
                    {
                        textBox.Clear();
                    }

                    Pwidth = 0;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            return;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (seq3 == null)
            {
                MessageBox.Show("Please enter an audio", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (FolderPath == null)
            {
                MessageBox.Show("Please enter a folder of audios", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PruningOrNot2 == 2)
            {
                MessageBox.Show("Please choose DTW Or DTW With Pruning", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (PruningOrNot2 == 0)               //DTW
            {
                label8.Text = "Time : ";

                TimeForoneansfolder = "";
                Stopwatch Watch;
                Distance = "";
                name = "";
                double min = double.PositiveInfinity;
                double t1=0.0;
                double t2=0.0;
                double t3=0.0;
                foreach (KeyValuePair<int, Sequence> i in audioMap)
                {
                    Watch= new Stopwatch();
                    Watch.Start();
                    double mn = SequenceMatching.DTW(seq3, i.Value);
                    Watch.Stop();
                    if (mn < min)
                    {
                        min = mn;
                        name = nameMAP[i.Key];
                    }
                    t1 = time1inms + Watch.ElapsedMilliseconds;
                    t2 = time2ins + Watch.Elapsed.TotalSeconds;
                    t3 = time3inm + Watch.Elapsed.TotalMinutes;
                }
                
                
                string ms = Convert.ToString(t1);
                string s = Convert.ToString(t2);
                string m = Convert.ToString(t3);
                string ans = Convert.ToString(min);
                TimeForoneansfolder = "milliseconds : " + ms + "\n";
                if (t2 >= 1)
                {
                    TimeForoneansfolder += "seconds : " + s + "\n";
                }
                if (t3 >= 1)
                {
                    TimeForoneansfolder += "minutes : " + m;
                }
                Distance = "Distance : " + ans;
                label6.Text = Distance;
                label7.Text = "Matched File : "+name;
                label8.Text = TimeForoneansfolder;
            }
            else if (PruningOrNot2 == 1)                  //Pruning
            {
                label8.Text = "Time : ";
                Stopwatch Watch;
                TimeForoneansfolder = "";
                Distance = "";
                name = "";
                double min = double.PositiveInfinity;
                
                double t1 = 0.0;
                double t2 = 0.0;
                double t3 = 0.0;
                foreach (KeyValuePair<int, Sequence> i in audioMap)
                {
                    Watch = new Stopwatch();
                    Watch.Start();
                    double mn = SequenceMatching.DTWPruning(seq3, i.Value,Pwidth2);
                    Watch.Stop();
                    if (mn < min)
                    {
                        min = mn;
                        name = nameMAP[i.Key];
                    }
                    t1 = time1inms + Watch.ElapsedMilliseconds;
                    t2 = time2ins + Watch.Elapsed.TotalSeconds;
                    t3 = time3inm + Watch.Elapsed.TotalMinutes;
                }
                string ms = Convert.ToString(t1);
                string s = Convert.ToString(t2);
                string m = Convert.ToString(t3);
                string ans = Convert.ToString(min);
                TimeForoneansfolder = "milliseconds : " + ms + "\n";
                if (t2 >= 1)
                {
                    TimeForoneansfolder += "seconds : " + s + "\n";
                }
                if (t3 >= 1)
                {
                    TimeForoneansfolder += "minutes : " + m;
                }
                Distance = "Distance : " + ans;
                label6.Text = "Distance : " + Distance;
                label7.Text = "Matched File : " + name;
                label8.Text = TimeForoneansfolder;
            }
            else
            {
                MessageBox.Show("Please choose with Pruning or not", "Missed Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            removeSil = 0;
            Stopwatch Watch = new Stopwatch();
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                isRecorded = false;
                path = open.FileName;
                //Open the selected audio file
               
                signal = AudioOperations.OpenAudioFile(path);
                if (removeSil == 1)
                {
                    signal = AudioOperations.RemoveSilence(signal);
                }
                Watch.Start();
                seq3 = AudioOperations.ExtractFeatures(signal);
                Watch.Stop();
                OPEN_FILE = true;///
                for (int i = 0; i < seq3.Frames.Length; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {

                        if (double.IsNaN(seq3.Frames[i].Features[j]) || double.IsInfinity(seq3.Frames[i].Features[j]))
                            throw new Exception("NaN");
                    }
                }
                time1inms += Watch.ElapsedMilliseconds;
                time2ins += Watch.Elapsed.TotalSeconds;
                time3inm += Watch.Elapsed.TotalMinutes;
                MessageBox.Show("Audio Loaded Successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog FD = new FolderBrowserDialog())
            {
                FD.Description = "Select a folder";
                FD.ShowNewFolderButton = true;
                FD.RootFolder = Environment.SpecialFolder.MyComputer;
                if (FD.ShowDialog() == DialogResult.OK)
                {
                    FolderPath = FD.SelectedPath;
                    MessageBox.Show($"Selected folder: {path}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No folder selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int index = 0;
            Stopwatch Watch2;

            //Watch.Start();
            foreach (string filePath in Directory.GetFiles(FolderPath, "*", SearchOption.TopDirectoryOnly))
            {
                Watch2 = new Stopwatch();
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                AudioSignal signal = AudioOperations.OpenAudioFile(filePath);
                //signal= AudioOperations.RemoveSilence(signal);
                Watch2.Start();
                Sequence sequence = AudioOperations.ExtractFeatures(signal);
                Watch2.Stop();
                // Add to dictionary
                time1inms += Watch2.ElapsedMilliseconds;
                time2ins += Watch2.Elapsed.TotalSeconds;
                time3inm += Watch2.Elapsed.TotalMinutes;
                audioMap[index] = sequence;
                nameMAP[index] = fileName;
                index++;
            }
            //Watch.Stop();
            
            Console.WriteLine("Doneeeeeeeee");
        }

        private void With_DTW_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Distance : ";
            label7.Text = "Matched File : ";
            label8.Text = "Time : ";
            forPruning2 = 0;
            PruningOrNot2 = 0;
            if (!string.IsNullOrWhiteSpace(width.Text))
            {
                width.Clear();
            }
        }

        private void With_Pruning_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Distance : " ;
            label7.Text = "Matched File : ";
            label8.Text = "Time : ";
            PruningOrNot2 = 1;
            forPruning2 = 1;
        }

        private void width_TextChanged(object sender, EventArgs e)
        {
            if (forPruning2 == 1)
            {
                TextBox width = sender as TextBox;
                if (string.IsNullOrWhiteSpace(width.Text))
                {
                    MessageBox.Show("Please enter Pruning Width.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (int.TryParse(width.Text, out int value))
                {
                    Pwidth2 = value;
                }
                else
                {
                    MessageBox.Show("Please enter only numeric values.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (width.Text.Length > 0)
                    {
                        width.Clear();
                    }
                    Pwidth2 = 0;
                }
            }
        }

        private void loadTrainingNFromJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadTrainingFileFromJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            Stopwatch stopwatch = new Stopwatch();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {


                    Console.WriteLine(fileDialog.FileName);
                    //DataOperations dataOperations = new DataOperations(fileDialog.FileName);
                    stopwatch.Start();
                    DataOperations.sequenceMap = DataOperations.read_js_file(fileDialog.FileName);


                    timeTrain = "Loading and Extract Train " + Convert.ToString(stopwatch.Elapsed.TotalSeconds) + " s";
                    Time_For_load_training_Label.Text = timeTrain;
                    Console.WriteLine("Time Loading And Extract: " + stopwatch.Elapsed.TotalSeconds + " s");


                    //Console.WriteLine(DataOperations.sequenceMap[0].sequences[0].Frames.Length);
                    //Console.WriteLine(DataOperations.sequenceMap[0].name);
                    //Console.WriteLine("count2 " + DataOperations.sequenceMap.Count);



                    //for (int i = 0; i < DataOperations.sequenceMap.Count; i++)
                    //{
                    //    Console.WriteLine(DataOperations.sequenceMap[i].sequences[0].Frames.Length);

                    //}

                    MessageBox.Show("loading complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {

                    MessageBox.Show("Error loading", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void loadTestingFileFromJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            Stopwatch stopwatch=new Stopwatch();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {



                    Console.WriteLine(fileDialog.FileName);
                    //DataOperations dataOperations = new DataOperations(fileDialog.FileName);
                    //dataOperations.LoadSequenceData(1);
                    Console.WriteLine("before");
                    stopwatch.Start();
                    SequenceMatching.sequenceTest = DataOperations.read_js_file(fileDialog.FileName);
                    stopwatch.Stop();

                    timeTest = "Loading and Extract Test " + Convert.ToString(stopwatch.Elapsed.TotalSeconds) + " s";
                    time_For_loading_testing_label.Text = timeTest;
                    Console.WriteLine("Time Loading And Extract Testing Set: " + stopwatch.Elapsed.TotalSeconds + " s");


                    Console.WriteLine("after");
                    //Console.WriteLine(SequenceMatching.sequenceTest[0].sequences[0].Frames.Length);
                    //Console.WriteLine(SequenceMatching.sequenceTest[0].name);
                    //Console.WriteLine($"count2 {DataOperations.sequenceMap.Count} ");



                    //for (int i = 0; i < DataOperations.sequenceMap.Count; i++)
                    //{
                    //    Console.WriteLine(DataOperations.sequenceMap[i].sequences[0].Frames.Length);

                    //}


                    MessageBox.Show("Data loading complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {

                    MessageBox.Show($"Error loading data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void resetDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                File.Delete(Directory.GetCurrentDirectory() + "\\DataBase\\databaseFile.json");
                MessageBox.Show("Database is Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                Console.WriteLine("DataBase Not Found");
            }
        }

        private void generateJsonByTrainingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "json";
            saveDialog.FileName = "training.json";
            saveDialog.Filter = "JSON files (*.json)|*.json";
            var path = saveDialog.ShowDialog();
            if (path == DialogResult.OK)
            {
                DataOperations.save_js_file(DataOperations.sequenceMap, saveDialog.FileName);
                MessageBox.Show("Training Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void generateJsonFileByTestingDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "json";
            saveDialog.FileName = "testing.json";
            saveDialog.Filter = "JSON files (*.json)|*.json";
            var path = saveDialog.ShowDialog();
            if (path == DialogResult.OK)
            {
                DataOperations.save_js_file(SequenceMatching.sequenceTest, saveDialog.FileName);
                MessageBox.Show("Testing Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Time_For_load_training_Label_Click(object sender, EventArgs e)
        {
            return;
        }

        private void run_sample_Click(object sender, EventArgs e)
        {
            return;
        }

        private void training_set_label_Click(object sender, EventArgs e)
        {
            return;return;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            return;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            return;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            return;
        }

        private void Time_Click(object sender, EventArgs e)
        {
            return;
        }

        private void accuracy_text_label_Click(object sender, EventArgs e)
        {
            return;
        }

        private void time_matching_test_cases_label_Click(object sender, EventArgs e)
        {
            return;
        }

        private void time_For_loading_testing_label_Click(object sender, EventArgs e)
        {
            return;
        }

        private void Testing_Label_Click(object sender, EventArgs e)
        {
            return;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            return;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            return;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            return;
        }

        private void username_box_Click(object sender, EventArgs e)
        {
            return;
        }

        private void accuracy_label_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
