using Microsoft.ProjectOxford.SpeakerRecognition;
using Microsoft.ProjectOxford.SpeakerRecognition.Contract.Identification;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Speech.Recognition;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Threading;
using System.ComponentModel;

namespace SPIDIdentificationAPI_WPF_Samples
{
    /// <summary>
    /// Interaction logic for RecordConversationPage.xaml
    /// </summary>
    /// 




    public partial class RecordConversationPage : Page
    {
        
        WaveIn waveIn;
        static string _selectedFile;
        NAudio.Wave.WaveIn sourceStream = null;
        NAudio.Wave.DirectSoundOut waveOut = null;
        private SpeakerIdentificationServiceClient _serviceClient;
        int count = 0, count1=0;
        WaveFileWriter writer; // = new WaveFileWriter(_selectedFile, new WaveFormat(16000, 1));
        int previous = 0;
        BackgroundWorker bw;
        String audioText;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (waveOut != null)
            //{
            //    waveOut.Stop();
            //    waveOut.Dispose();
            //    waveOut = null;
            //}
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
                writer.Dispose();
                writer.Close();
                identify();
            }

        }    

        public RecordConversationPage()
        {
            InitializeComponent();
            _selectedFile = "abc0.wav";
            _speakersListFrame.Navigate(SpeakersListPage.SpeakersList);
            writer = new WaveFileWriter(_selectedFile, new WaveFormat(16000, 1));
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            _serviceClient = new SpeakerIdentificationServiceClient(window.ScenarioControl.SubscriptionKey);
            bw = new BackgroundWorker();

               bw.DoWork += new DoWorkEventHandler(
           delegate(object o, DoWorkEventArgs args)
           {
               BackgroundWorker b = o as BackgroundWorker;
               audioText = readAudio();
           });


                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
           delegate(object o, RunWorkerCompletedEventArgs args)
           {
               //textBlock.Text = audioText;
           });

                   
            bw.RunWorkerAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            sourceStream = new NAudio.Wave.WaveIn();
            sourceStream.DeviceNumber = 0;
            sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);//NAudio.Wave.WaveIn.GetCapabilities(0).Channels);
            sourceStream.DataAvailable += waveIn_DataAvailable;

            sourceStream.StartRecording();
            //NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(sourceStream);
            
            //waveOut = new NAudio.Wave.DirectSoundOut();
            //waveOut.Init(waveIn);

            //waveOut.Play();
        }


        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {

            int maxFileLength = this.sourceStream.WaveFormat.AverageBytesPerSecond * 5;

            int toWrite = e.BytesRecorded; //- previous;
            if (toWrite > 0)
            {
                if (toWrite < maxFileLength)
                {
                    writer.Write(e.Buffer, 0, toWrite);
                    previous += toWrite;
                }
                else
                {
                    writer.Write(e.Buffer, 0, maxFileLength);
                    previous += maxFileLength;
                }
                if(previous>=maxFileLength)
                {
                    writer.Flush();
                    writer.Dispose();
                    //writer.Close();
                    
                    identify();
                    _selectedFile = _selectedFile.Substring(0, _selectedFile.Length - 5) + count1 + ".wav";
                    writer = new WaveFileWriter(_selectedFile, new WaveFormat(16000, 1));
                    previous = 0;
                    count1++;
                }
            }
            else
            {
                sourceStream.StopRecording();
                writer.Dispose();
                writer.Close();
                identify();
                //writer.WriteData(e.Buffer, 0, e.BytesRecorded);
            }
            //if (recordingState == RecordingState.Recording)
              
        }














        public static void Concatenate(string outputFile, IEnumerable<string> sourceFiles)
        {
            byte[] buffer = new byte[1024];
            WaveFileWriter waveFileWriter = null;

            try
            {
                foreach (string sourceFile in sourceFiles)
                {
                    using (WaveFileReader reader = new WaveFileReader(sourceFile))
                    {
                        if (waveFileWriter == null)
                        {
                            // first time in create new Writer
                            waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
                        }
                        else
                        {
                            if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
                            {
                                throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                            }
                        }

                        int read;
                        while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            waveFileWriter.WriteData(buffer, 0, read);
                        }
                    }
                }
            }
            finally
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Dispose();
                }
            }

        }
        private async void identify()
        {
            MainWindow window = (MainWindow)Application.Current.MainWindow;
            try
            {
                
                window.Log("Identifying File...");
                Profile[] selectedProfiles = SpeakersListPage.SpeakersList.GetSelectedProfiles();
                Guid[] testProfileIds = new Guid[selectedProfiles.Length];
                for (int i = 0; i < testProfileIds.Length; i++)
                {
                    testProfileIds[i] = selectedProfiles[i].ProfileId;
                }

                List<string> list = new List<string>();
                for (int j = 0; j < 15; j++)
                    list.Add(_selectedFile);
                //list.Add(_selectedFile);
                string _selectedFile1 = _selectedFile.Substring(0, _selectedFile.Length - 4) + "1" + ".wav";
                Concatenate(_selectedFile1, list);

                OperationLocation processPollingLocation;
                using (Stream audioStream = File.OpenRead(_selectedFile1))
                {
                    //for (int i = 1; i <= 2;i++ )
                    //    audioStream.CopyTo(audioStream);
                    //_selectedFile = "";
                    processPollingLocation = await _serviceClient.IdentifyAsync(audioStream, testProfileIds);
                }

                IdentificationOperation identificationResponse = null;
                int numOfRetries = 15;
                TimeSpan timeBetweenRetries = TimeSpan.FromSeconds(5.0);
                while (numOfRetries > 0)
                {
                    await Task.Delay(timeBetweenRetries);
                    identificationResponse = await _serviceClient.CheckIdentificationStatusAsync(processPollingLocation);

                    if (identificationResponse.Status == Status.Succeeded)
                    {
                        break;
                    }
                    else if (identificationResponse.Status == Status.Failed)
                    {
                        throw new IdentificationException(identificationResponse.Message);
                    }
                    numOfRetries--;
                }
                if (numOfRetries <= 0)
                {
                    throw new IdentificationException("Identification operation timeout.");
                }

                window.Log("Identification Done.");
                tblock.Text = count + identificationResponse.ProcessingResult.IdentifiedProfileId.ToString();
                count++;
                //_identificationResultTxtBlk.Text = identificationResponse.ProcessingResult.IdentifiedProfileId.ToString();
                //_identificationConfidenceTxtBlk.Text = identificationResponse.ProcessingResult.Confidence.ToString();
                //_identificationResultStckPnl.Visibility = Visibility.Visible;
            }
            catch (IdentificationException ex)
            {
                window.Log("Speaker Identification Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                window.Log("Error: " + ex.Message);
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SpeakersListPage.SpeakersList.SetMultipleSelectionMode();
        }


        public string readAudio(){
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
            Grammar gr = new DictationGrammar();
            sre.LoadGrammar(gr);
            sre.SetInputToWaveFile("C:\\Users\\Daveo30\\Music\\nikhilshort.wav");
            sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
            sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
            sre.EndSilenceTimeout = new TimeSpan(100000000);
            sre.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                try
                {
                    var recText = sre.Recognize();
                    if (recText == null)
                    {
                        break;
                    }

                    sb.Append(recText.Text);
                }
                catch (Exception ex)
                {
                    //handle exception      
                    //...

                    break;
                }
            }
            return sb.ToString();
        }
 
    }
}
