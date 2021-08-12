using System;
using System.Windows.Forms;

namespace Vegas_Oscillator_Randomizer
{
    public static class FrequencyControl
    {
        public static int wavelengthFrames = 60;

        public static TextBox wavelengthFramesBox;
        public static TextBox wavelengthSecondsBox;
        public static TextBox hzBox;
        public static TextBox bpmBox;

        public static void Update(string source, string value)
        {
            // Depending on which TextBox was updated, determine the wavelength in frames using the correct conversion
            // If the TextBox's value is not a valid number, it will revert to its previous value (by not updating wavelengthFrames)
            if (source.Equals("Wavelength in frames"))
            {
                try
                {
                    int numFrames = int.Parse(value);
                    if (numFrames != 0)
                    {
                        wavelengthFrames = numFrames;
                    }
                }
                catch (Exception) { }
            }
            else if (source.Equals("Wavelength in seconds"))
            {
                try
                {
                    double numSeconds = double.Parse(value);
                    if (numSeconds != 0)
                    {
                        wavelengthFrames = ToFrames(numSeconds);
                    }
                }
                catch (Exception) { }
            }
            else if (source.Equals("Hertz"))
            {
                try
                {
                    double hertz = int.Parse(value);
                    if (hertz != 0)
                    {
                        wavelengthFrames = ToFrames(1 / hertz);
                    }
                }
                catch (Exception) { }
            }
            else if (source.Equals("Beats per minute"))
            {
                try
                {
                    double bpm = int.Parse(value);
                    if (bpm != 0)
                    {
                        wavelengthFrames = ToFrames(60 / bpm);
                    }
                }
                catch (Exception) { }
            }

            // Update all boxes using the newly found wavelength in frames
            wavelengthFramesBox.Text = wavelengthFrames.ToString();
            wavelengthSecondsBox.Text = ToSeconds(wavelengthFrames).ToString();
            hzBox.Text = (1 / ToSeconds(wavelengthFrames)).ToString();
            bpmBox.Text = (60 / ToSeconds(wavelengthFrames)).ToString();
        }

        public static int ToFrames (double seconds)
        {
            return (int) Math.Round(seconds * GUI.Vegas.Project.Video.FrameRate);
        }

        public static double ToSeconds(int frames)
        {
            return frames / GUI.Vegas.Project.Video.FrameRate;
        }
    }
}
