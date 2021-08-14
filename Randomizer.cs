using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegas_Oscillator_Randomizer
{
    public class Randomizer : Generator
    {
        private Random random;
        private double min;
        private double max;

        public Randomizer(int seed, double min, double max, bool randomSeed = false)
        {
            if (randomSeed)
            {
                random = new Random();
            }
            else
            {
                random = new Random(seed);
            }
            this.min = min;
            this.max = max;
        }

        public override double GetValue(int iteration)
        {
            // TODO this doesn't work
            return random.NextDouble() * (max - min) + min;
        }

        public override int GetInterpolation(int iteration)
        {
            return -1;
        }

        public override Timecode GetTime(int iteration)
        {
            return Timecode.FromFrames(iteration * FrequencyControl.wavelengthFrames);
        }
    }
}
