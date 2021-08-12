using System;
using System.Windows.Forms;
using ScriptPortal.Vegas;

namespace Vegas_Oscillator_Randomizer
{
    public class EntryPoint
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new GUI());
            if (GUI.MainGUI == null)
            {
                GUI.MainGUI = new GUI();
            }

            GUI.MainGUI.Open();
        }
        public void FromVegas(Vegas vegas)
        {
            if (GUI.Vegas == null)
            {
                GUI.Vegas = vegas;
            }
            Main();
        }
    }
}
