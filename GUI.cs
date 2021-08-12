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

            FrequencyControl.wavelengthFramesBox = wavelengthFramesBox;
            FrequencyControl.wavelengthSecondsBox = wavelengthSecondsBox;
            FrequencyControl.hzBox = hzBox;
            FrequencyControl.bpmBox = bpmBox;
            FrequencyControl.Update("", "60");

            Clip.effectDropdown = effectDropdown;
            Clip.parameterDropdown = parameterDropdown;
            // TODO depending on the type of the parameter chosen, enable/disable the radio buttons
        }

        public void Open ()
        {
            effectDropdown.DataSource = Clip.GetEffectNames();
            parameterDropdown.DataSource = Clip.GetParameterNames();

            ShowDialog();
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            // Apply();
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
    }
}
