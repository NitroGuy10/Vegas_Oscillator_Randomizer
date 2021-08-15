using System;
using ScriptPortal.Vegas;

namespace Vegas_Oscillator_Randomizer
{
    public class NoiseGenerator : Generator
    {
        private double min;
        private double max;
        private double speed;
        private FastNoiseLite noise;

        public NoiseGenerator(int seed, FastNoiseLite.NoiseType noiseType, double min, double max, double speed, bool randomSeed = false)
        {
            if (randomSeed)
            {
                noise = new FastNoiseLite(new Random().Next(int.MinValue, int.MaxValue));
            }
            else
            {
                noise = new FastNoiseLite();
            }
            noise.SetNoiseType(noiseType);
            this.min = min;
            this.max = max;
            this.speed = speed;
        }

        public override double GetValue(int iteration)
        {
            return ((noise.GetNoise((float) (iteration * speed), 0) + 1) / 2) * (max - min) + min;
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
