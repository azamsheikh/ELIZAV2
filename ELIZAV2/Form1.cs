using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace ELIZAV2
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        string status = "1";
        String listening = "0";


        public Form1()
        {

            //   String actCode = getfromurl("http://azamitaweb.com/stringlightcommandput.php");
            String actCode = "wakanda";
            // String actCode = "lol";

            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new String[] {"lumos", "alyssa", "eliza", "music please", "lights please", "hello", "good", "how are you", "aliza", "open youtube", "fuck you", "open browser", "close browser", "activate code 9 9 8 8", "deactivate code 9 9 8 8", "light down everything", "light up everything", "cube alarm", actCode });

            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch { return; }


            s.SelectVoiceByHints(VoiceGender.Female);


            //String ssline = getfromurl("http://demolamp.atwebpages.com/lampget.php");

            s.Speak("I am here");
            InitializeComponent();
        }


        public void say(String h)
        {
            s.Speak(h);

        }

        private void rec_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
        top:
            String q = e.Result.Text;
            String r = q.ToLower();
            label1.Text = r;
            if (r == "activate code 9 9 8 8")
            {
                say("voice assistant activated");
                status = "1";
            }
            else if (r == "deactivate code 9 9 8 8")
            {
                if (status == "1")
                {
                    say("voice assistant deactivated");
                    status = "0";
                }
            }
            else
            {
                if (status == "1")
                {
                    if (r == "aliza" || r == "eliza" || r == "elly" || r == "alley" || r == "ally" || r == "alyssa")
                    {

                        try
                        {
                            // say("yes");   /////removed for irritation
                            listening = "1";
                            button1.BackColor = Color.Green;
                            // say("how can i help");
                            // serialPort1.PortName = "COM12";
                            // serialPort1.Open();
                            // serialPort1.Write("1");
                            // serialPort1.Close();



                        }
                        catch { }
                    }




                    else
                    {

                        if (listening == "1")
                        {

                            if (r == "open browser")
                            {
                                // say("Hello");
                                System.Diagnostics.Process.Start("chrome");
                            }

                            if (r == "lights please" || r == "light please")
                            {
                                try
                                {
                                    String ssline = getfromurl(" http://azamitaweb.com/lightsget.php");
                                    if (ssline == "off")
                                    {
                                        ssline = getfromurl("http://azamitaweb.com/commandput.php?command=on");
                                    }

                                    if (ssline == "on")
                                    {
                                        ssline = getfromurl("http://azamitaweb.com/commandput.php?command=off");
                                    }
                                }
                                catch { }


                            }

                            if (r == "open youtube")
                            {
                                ProcessStartInfo ProcessInfo;
                                Process Process;
                                ProcessInfo = new ProcessStartInfo("chrome.exe", "/K " + "http://www.youtube.com");
                                ProcessInfo.CreateNoWindow = true;
                                ProcessInfo.UseShellExecute = true;
                                Process = Process.Start(ProcessInfo);
                            }

                            if (r == "music please")
                            {
                                ProcessStartInfo ProcessInfo;
                                Process Process;
                                ProcessInfo = new ProcessStartInfo("chrome.exe", "/K " + "https://www.youtube.com/watch?v=3EFDJZ5TZl4&list=PLBPxrZ1AB7HgzVRLWwPMhossqYcHIJV2x");
                                ProcessInfo.CreateNoWindow = true;
                                ProcessInfo.UseShellExecute = true;
                                Process = Process.Start(ProcessInfo);
                            }

                            if (r == "close browser")
                            {

                                ProcessStartInfo ProcessInfo;
                                Process Process;
                                ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + "taskkill /im chrome.exe /t /f & exit");
                                ProcessInfo.CreateNoWindow = true;
                                ProcessInfo.UseShellExecute = true;
                                Process = Process.Start(ProcessInfo);
                            }

                            if (r == "fuck you")
                            {
                                //say("fuck you you bloody fuck you bloody, you bloody fuck you bloody bastard, banchood");
                                // System.Diagnostics.Process.Start("cmd");
                            }

                            if (r == "light down everything")
                            {
                                try
                                {
                                    String ssline = getfromurl("http://azamitaweb.com/commandput.php?command=off");

                                    ssline = getfromurl("http://azamitaweb.com/stringlightcommandput.php?command=off");
                                }
                                catch { }
                            }

                            if (r == "light up everything")
                            {
                                try
                                {
                                    String ssline = getfromurl("http://azamitaweb.com/commandput.php?command=on");
                                    Task.Delay(5000).Wait();
                                    ssline = getfromurl("http://azamitaweb.com/stringlightcommandput.php?command=on");
                                }
                                catch { }
                            }


                            if (r == "cube alarm")
                            {
                                try
                                {
                                    String ssline = getfromurl("http://azamitaweb.com/cubealarm.php?process=cubesolvestatusupdate&cubesolvestatus=solved");
                                    Task.Delay(2000).Wait();
                                    ssline = getfromurl("http://azamitaweb.com/cubealarm.php?process=alarmstatusupdate&alarmstatus=off");
                                    Task.Delay(2000).Wait();
                                    ssline = getfromurl("http://azamitaweb.com/cubealarm.php?process=cubesolvestatusupdate&cubesolvestatus=unsolved");
                                }
                                catch { }


                            }



                            else
                            {
                                //say("what?");
                            }






                            listening = "0";
                            button1.BackColor = Color.Red;
                        }

                    }











                }

                else
                {

                }
            }









        }


        public String getfromurl(String uurl)
        {

            string sURL;
            sURL = uurl;
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;
            wrGETURL.Proxy = WebProxy.GetDefaultProxy();
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string sLine = "";
            sLine = objReader.ReadLine();
            return sLine;





        }





        private void Form1_Load(object sender, EventArgs e)
        {
            // serialPort1.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }
    }
}
