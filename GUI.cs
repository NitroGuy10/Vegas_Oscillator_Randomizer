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

        // TODO switch between "one cycle every" and "new value every" in frequency labels based on currently open tab

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

        private void applyBtn_Click(object sender, EventArgs e)
        {
            // Apply();
            Clip.MakeKeyframe(0.0, Timecode.FromFrames(0), false);
            Clip.MakeKeyframe(180.0, Clip.videoEvent.Length, true);
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
    }
}
