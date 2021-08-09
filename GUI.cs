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
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            // Apply();
            Close();
        }
    }
}
