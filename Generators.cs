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
        public void Generate()
        {
            int iteration = 0;
            while (GetTime(iteration) <= Clip.videoEvent.Length)
            {
                Clip.MakeKeyframe(GetValue(iteration), GetTime(iteration), true, GetInterpolation(iteration));
                iteration++;
            }
        }
        public abstract double GetValue(int iteration);
        public abstract int GetInterpolation(int iteration);
        public abstract Timecode GetTime(int iteration);
    }

    public enum Waveform
    {
        Sine,
        Cosine,
        Triangle,
        Sawtooth,
        Square
    }

    public class Oscillator : Generator
    {
        private double amplitude;
        private double height;
        private Waveform waveform;
        private int FrameDistance;
        public Oscillator(Waveform waveform, double amplitude, double height)
        {
            this.waveform = waveform;
            this.amplitude = amplitude;
            this.height = height;

            if (waveform == Waveform.Sine || waveform == Waveform.Cosine)
            {
                FrameDistance = 1;
            }
            else if (waveform == Waveform.Triangle)
            {
                FrameDistance = Math.Max(FrequencyControl.wavelengthFrames / 4, 1);
            }
            else if (waveform == Waveform.Square)
            {
                FrameDistance = Math.Max(FrequencyControl.wavelengthFrames / 2, 1);
            }
            else  // if sawtooth
            {
                //FrameDistance = 1;
                //FrameDistance = Math.Max(FrequencyControl.wavelengthFrames - 1, 1);
            }
        }

        public override double GetValue(int iteration)
        {
            if (waveform == Waveform.Sine)
            {
                return amplitude * Math.Sin(2 * iteration * Math.PI / FrequencyControl.wavelengthFrames) + height;
            }
            else if (waveform == Waveform.Cosine)
            {
                return amplitude * Math.Cos(2 * iteration * Math.PI / FrequencyControl.wavelengthFrames) + height;
            }
            else if (waveform == Waveform.Triangle)
            {
                int cycle = iteration % 4;
                if (cycle == 0 || cycle == 2)
                {
                    return height;
                }
                else if (cycle == 1)
                {
                    return height + amplitude;
                }
                else  // if cycle == 3
                {
                    return height - amplitude;
                }
            }
            else if (waveform == Waveform.Sawtooth)
            {
                int cycle = iteration % 2;
                if (cycle == 1)
                {
                    return height - amplitude;
                }
                else
                {
                    return height + amplitude;
                }
            }
            else  // if square
            {
                int cycle = iteration % 2;
                if (cycle == 0)
                {
                    return height + amplitude;
                }
                else  // if cycle == 1
                {
                    return height - amplitude;
                }
            }
        }

        public override int GetInterpolation(int iteration)
        {
            if (waveform == Waveform.Sawtooth && iteration % 2 == 0)
            {
                return 6;  // "hold" interpolation
            }
            return -1;
        }

        public override Timecode GetTime(int iteration)
        {
            if (waveform == Waveform.Sawtooth)
            {
                int numFrames = (iteration / 2) * FrequencyControl.wavelengthFrames;
                if (iteration % 2 == 0)
                {
                    numFrames++;
                }
                return Timecode.FromFrames(numFrames);
            }
            return Timecode.FromFrames(iteration * FrameDistance);
        }
    }
}
