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
            // These list items correspond to integers 0-4 from enum Waveform
            oscWaveformDropdown.DataSource = new string[5] { "Sine", "Cosine", "Triangle", "Sawtooth", "Square" };
            // These list items correspond to integers 0-5 from enum FastNoiseLite.NoiseType
            noiseTypeDropdown.DataSource = new string[6] { "OpenSimplex", "OpenSimplex2S", "Cellular", "Perlin", "ValueCubic", "Value" };
            noiseTypeDropdown.SelectedIndex = 3;

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
                restrictInterpolation();

                ShowDialog();
            }
        }

        private bool VerifyDoubleBoxes(TextBox[] textBoxes, string[] names)
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
            if (invalidNumberBoxNames.Count == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("The following settings do not have valid numerical values: " + string.Join(", ", invalidNumberBoxNames));
                return false;
            }
        }

        private void restrictInterpolation()
        {
            interpolationDropdown.Enabled = true;
            if (tabControl.SelectedIndex == 0)
            {
                if (oscWaveformDropdown.SelectedIndex == 2)
                {
                    interpolationDropdown.SelectedIndex = 0;
                    interpolationDropdown.Enabled = false;
                }
                else if (oscWaveformDropdown.SelectedIndex == 4)
                {
                    interpolationDropdown.SelectedIndex = 5;
                    interpolationDropdown.Enabled = false;
                }
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Generator generator;
            if (tabControl.SelectedIndex == 0)
            {
                if (!VerifyDoubleBoxes(new TextBox[2] { oscAmplitudeBox, oscHeightBox }, new string[2] { "Amplitude", "Height" }))
                {
                    return;
                }
                generator = new Oscillator((Waveform)oscWaveformDropdown.SelectedIndex, double.Parse(oscAmplitudeBox.Text), double.Parse(oscHeightBox.Text));
            }
            else if (tabControl.SelectedIndex == 1)
            {
                if (!VerifyDoubleBoxes(new TextBox[2] { randMaxBox, randMinBox }, new string[2] { "Maximum", "Minimum" }))
                {
                    return;
                }
                if (randSeedBox.Text.Equals(""))
                {
                    generator = new Randomizer(0, double.Parse(randMinBox.Text), double.Parse(randMaxBox.Text), true);
                }
                else
                {
                    generator = new Randomizer(randSeedBox.Text.GetHashCode(), double.Parse(randMinBox.Text), double.Parse(randMaxBox.Text));
                }
            }
            else
            {
                if (!VerifyDoubleBoxes(new TextBox[3] { noiseMaxBox, noiseMinBox, noiseSpeedBox }, new string[3] { "Maximum", "Minimum", "Speed" }))
                {
                    return;
                }
                if (randSeedBox.Text.Equals(""))
                {
                    generator = new NoiseGenerator(0, (FastNoiseLite.NoiseType) noiseTypeDropdown.SelectedIndex, double.Parse(noiseMinBox.Text), double.Parse(noiseMaxBox.Text), double.Parse(noiseSpeedBox.Text), true);
                }
                else
                {
                    generator = new NoiseGenerator(randSeedBox.Text.GetHashCode(), (FastNoiseLite.NoiseType)noiseTypeDropdown.SelectedIndex, double.Parse(noiseMinBox.Text), double.Parse(noiseMaxBox.Text), double.Parse(noiseSpeedBox.Text));
                }
            }
            generator.Generate();

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

        private void oscWaveformDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            restrictInterpolation();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            restrictInterpolation();
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
