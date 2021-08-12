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

        // TODO USE THE GENERIC OFXParameter<> for animating

        public static Effect activeEffect
        {
            get
            {
                return useableEffects[effectDropdown.SelectedIndex];
            }
        }

        public static List<Effect> useableEffects
        {
            get
            {
                List<Effect> effects = new List<Effect>();
                foreach (Effect effect in videoEvent.Effects)
                {
                    try  // Sometimes, non-OFX effects will throw an exception when reading IsOFX
                    {
                        if (effect.IsOFX)
                        {
                            effects.Add(effect);
                        }
                    }
                    catch (Exception) { }
                }
                return effects;
            }
        }

        public static List<OFXParameter> useableParameters
        {
            get
            {
                List<OFXParameter> parameters = new List<OFXParameter>();
                foreach (OFXParameter parameter in activeEffect.OFXEffect.Parameters)
                {
                    if (parameter.CanAnimate)
                    {
                        parameters.Add(parameter);
                    }
                }
                return parameters;
            }
        }

        public static List<string> GetEffectNames()
        {
            List<string> effectNames = new List<string>();
            foreach (Effect effect in useableEffects)
            {
                effectNames.Add(effect.PlugIn.Name);
            }
            return effectNames;
        }

        public static List<string> GetParameterNames()
        {
            List<string> parameterNames = new List<string>();
            foreach (OFXParameter parameter in useableParameters)
            {
                parameterNames.Add(parameter.Name);
            }
            return parameterNames;
        }
    }
}
