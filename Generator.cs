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
}
