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

            int numSelected = 0;
            foreach (Track track in GUI.Vegas.Project.Tracks)
            {
                foreach (TrackEvent trackEvent in track.Events)
                {
                    if (trackEvent.Selected == trackEvent.IsVideo())
                    {
                        Clip.videoEvent = (VideoEvent) trackEvent;
                        numSelected++;
                    }
                }
            }

            if (numSelected == 1)
            {
                GUI.MainGUI.Open();
            }
            else
            {
                MessageBox.Show("Please select 1 video clip to apply the oscillation/randomization");
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
