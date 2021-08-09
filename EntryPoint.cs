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

            if (GUI.Vegas == null)
            {
                GUI.MainGUI.ShowDialog();
            }
            else
            {
                int numSelected = 0;
                foreach (Track track in GUI.Vegas.Project.Tracks)
                {
                    foreach (TrackEvent trackEvent in track.Events)
                    {
                        if (trackEvent.Selected)
                        {
                            numSelected++;
                        }
                    }
                }

                if (numSelected == 1)
                {
                    GUI.MainGUI.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select 1 clip to apply the oscillation/randomization");
                }
            }
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
