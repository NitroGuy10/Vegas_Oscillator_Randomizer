using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ScriptPortal.Vegas;

namespace Vegas_Oscillator_Randomizer
{
    public partial class GUI : Form
    {
        public static GUI MainGUI;
        public static Vegas Vegas;

        public GUI()
        {
            InitializeComponent();

            // These list items correspond to integers 1-6 from enum OFXInterpolationType
            interpolationDropdown.DataSource = new string[6] { "Linear", "Fast", "Slow", "Smooth", "Sharp", "Hold" };

            FrequencyControl.wavelengthFramesBox = wavelengthFramesBox;
            FrequencyControl.wavelengthSecondsBox = wavelengthSecondsBox;
            FrequencyControl.hzBox = hzBox;
            FrequencyControl.bpmBox = bpmBox;
            FrequencyControl.Update("", "60");

            Clip.effectDropdown = effectDropdown;
            Clip.parameterDropdown = parameterDropdown;
            Clip.interpolationDropdown = interpolationDropdown;
            Clip.radioButtons = new RadioButton[4] { firstRadiobtn, secondRadiobtn, thirdRadiobtn, fourthRadiobtn };
        }

        public void Open()
        {
            int numSelected = 0;
            foreach (Track track in GUI.Vegas.Project.Tracks)
            {
                foreach (TrackEvent trackEvent in track.Events)
                {
                    if (trackEvent.Selected == trackEvent.IsVideo())
                    {
                        Clip.videoEvent = (VideoEvent)trackEvent;
                        numSelected++;
                    }
                }
            }

            if (numSelected != 1)
            {
                MessageBox.Show("Please select 1 video clip to apply the oscillation/randomization.");
            }
            else if (Clip.useableEffects.Count == 0)
            {
                MessageBox.Show("The selected video clip has no useable effects/parameters. If it DOES have effects, they are not OpenFX-based and therefore not useable with this script.");
            }
            else
            {
                effectDropdown.DataSource = Clip.GetEffectNames();
                parameterDropdown.DataSource = Clip.GetParameterNames();

                Clip.SetUpRadioButtons();

                ShowDialog();
            }
        }

        private string VerifyNumberBoxes(TextBox[] textBoxes, string[] names)
        {
            List<string> invalidNumberBoxNames = new List<string>();
            for (int i = 0; i < textBoxes.Length; i++)
            {
                try
                {
                    double.Parse(textBoxes[i].Text);
                }
                catch (FormatException)
                {
                    invalidNumberBoxNames.Add(names[i]);
                }
            }
            return string.Join(", ", invalidNumberBoxNames);
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Generator generator;
            if (tabControl.SelectedIndex == 0)
            {
                string invalidNumberBoxNames = VerifyNumberBoxes(new TextBox[2] { oscAmplitudeBox, oscHeightBox }, new string[2] { "Amplitude", "Height" });
                if (!invalidNumberBoxNames.Equals(""))
                {
                    MessageBox.Show("The following settings do not have valid numerical values: " + invalidNumberBoxNames);
                    return;
                }
                generator = new Oscillator(Waveform.Sine, double.Parse(oscAmplitudeBox.Text), double.Parse(oscHeightBox.Text));
            }
            else if (tabControl.SelectedIndex == 1)
            {
                // TODO new Randomizer()
                generator = new Oscillator(Waveform.Sine, 0, 0);
            }
            else
            {
                // TODO new NoiseGenerator()
                generator = new Oscillator(Waveform.Sine, 0, 0);
            }
            int iteration = 0;
            while (Timecode.FromFrames(iteration * FrequencyControl.wavelengthFrames) <= Clip.videoEvent.Length)
            {
                // Apply interpolation only if this is the final iteration through this loop
                bool applyInterpolation = Timecode.FromFrames((iteration + 1) * FrequencyControl.wavelengthFrames) > Clip.videoEvent.Length;

                Clip.MakeKeyframe(generator.GetValue(iteration), Timecode.FromFrames(iteration * FrequencyControl.wavelengthFrames), applyInterpolation);
                iteration++;
            }

            Close();
        }

        private void wavelengthFramesBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrequencyControl.Update("Wavelength in frames", wavelengthFramesBox.Text);
            }
        }

        private void wavelengthSecondsBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrequencyControl.Update("Wavelength in seconds", wavelengthSecondsBox.Text);
            }
        }

        private void hzBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrequencyControl.Update("Hertz", hzBox.Text);
            }
        }

        private void bpmBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FrequencyControl.Update("Beats per minute", bpmBox.Text);
            }
        }

        private void effectDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameterDropdown.DataSource = Clip.GetParameterNames();
        }

        private void parameterDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clip.SetUpRadioButtons();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                wavelengthLabel1.Text = "One cycle every";
                wavelengthLabel2.Text = "One cycle every";
            }
            else if (tabControl.SelectedIndex == 1)
            {
                wavelengthLabel1.Text = "New value every";
                wavelengthLabel2.Text = "New value every";
            }
            else if (tabControl.SelectedIndex == 2)
            {
                wavelengthLabel1.Text = "Keyframe every";
                wavelengthLabel2.Text = "Keyframe every";
            }
        }
    }
}
