using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptPortal.Vegas;
using System.Windows.Forms;

namespace Vegas_Oscillator_Randomizer
{
    public static class Clip
    {
        public static VideoEvent videoEvent;

        public static ComboBox effectDropdown;
        public static ComboBox parameterDropdown;

        /* 
         * TODO support the following parameter types
         * OFXDoubleParameter
         * OFXDouble2DParameter
         * OFXDouble3DParameter
         * OFXIntegerParameter
         * OFXInteger2DParameter
         * OFXInteger3DParameter
         * OFXRGBAParameter
         * OFXRGBParameter
         */

        public static Effect activeEffect
        {
            get
            {
                return videoEvent.Effects[effectDropdown.SelectedIndex];
            }
        }

        public static List<string> GetEffectNames()
        {
            List<string> effectNames = new List<string>();
            foreach (Effect effect in videoEvent.Effects)
            {
                effectNames.Add(effect.PlugIn.Name);
            }
            return effectNames;
        }

        public static List<string> GetParameterNames()
        {
            List<string> parameterNames = new List<string>();
            foreach (OFXParameter parameter in activeEffect.OFXEffect.Parameters)
            {
                parameterNames.Add(parameter.Name);
            }
            return parameterNames;
        }
    }
}
