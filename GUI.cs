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

            // new SettingControl(horizontalOffsetSlider, horizontalOffsetTextBox, 0.001, 0, "Horizontal Offset");
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            // Apply();
            Close();
        }

        /*
        private void horizontalOffsetSlider_Scroll(object sender, EventArgs e)
        {
            if (SliderControl.SettingControls.ContainsKey("Horizontal Offset"))
            {
                SliderControl.SettingControls["Horizontal Offset"].UpdateFromSlider();
            }
        }

        private void horizontalOffsetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SliderControl.SettingControls["Horizontal Offset"].UpdateFromTextBox();
                e.Handled = true;
            }
        }
        */
    }
}
