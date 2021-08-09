using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vegas_Oscillator_Randomizer
{
    public class SliderControl
    {
        public static Dictionary<string, SliderControl> SliderControls = new Dictionary<string, SliderControl>();

        public TrackBar slider;
        public TextBox textBox;
        public double sliderScalar;
        public string name;
        public double defaultValue;
        private double value;

        public SliderControl(TrackBar slider, TextBox textBox, double sliderScalar, double defaultValue, string name)
        {
            this.slider = slider;
            this.textBox = textBox;
            this.sliderScalar = sliderScalar;
            this.defaultValue = defaultValue;
            this.name = name;
            Value = defaultValue;

            SliderControls[name] = this;
        }

        public void UpdateFromSlider()
        {
            Value = slider.Value * sliderScalar;
        }

        public void UpdateFromTextBox()
        {
            try
            {
                Value = Double.Parse(textBox.Text);
            }
            catch (Exception)
            {
                Value = Value;
            }
        }

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                textBox.Text = value.ToString();
                slider.Value = Math.Min(Math.Max((int)Math.Round(value / sliderScalar), slider.Minimum), slider.Maximum);
            }
        }
    }
}
