using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptPortal.Vegas;

namespace Vegas_Oscillator_Randomizer
{
    public abstract class Generator
    {
        public abstract double GetValue(int iteration);
    }

    public enum Waveform
    {
        Sine,
        Cosine,
        Sawtooth,
        Triangle,
        Square
    }

    public class Oscillator : Generator
    {
        public Waveform Waveform;
        public double Amplitude;
        public double Height;

        public Oscillator (Waveform waveform, double amplitude, double height)
        {
            Waveform = waveform;
            Amplitude = amplitude;
            Height = height;
        }
        public override double GetValue(int iteration)
        {
            // TODO implement this
            return 0;
        }
    }
}
