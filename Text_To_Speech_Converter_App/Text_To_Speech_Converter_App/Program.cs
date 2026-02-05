using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;// For Text to Speech functionality

namespace Text_To_Speech_Converter_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, welcome to the Text to Speech Converter Application developed in .NET Framework!");
            //changing voice
            synth.Volume = 70;  // 0...100
            synth.SelectVoiceByHints(VoiceGender.Female);
            synth.Speak("This is a good girl voice.");
        }
    }
}
