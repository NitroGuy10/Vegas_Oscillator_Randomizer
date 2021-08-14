using System;
using System.Collections.Generic;
using System.Linq;
using ScriptPortal.Vegas;
using System.Windows.Forms;

namespace Vegas_Oscillator_Randomizer
{
    public static class Clip
    {
        public static VideoEvent videoEvent;

        public static ComboBox effectDropdown;
        public static ComboBox parameterDropdown;
        public static ComboBox interpolationDropdown;
        public static RadioButton[] radioButtons;

        public static OFXParameterType[] useableParameterTypes = {
            OFXParameterType.Double, OFXParameterType.Double2D, OFXParameterType.Double3D,
            OFXParameterType.Integer, OFXParameterType.Integer2D, OFXParameterType.Integer3D,
            OFXParameterType.RGB, OFXParameterType.RGBA
        };

        private static Effect activeEffect
        {
            get
            {
                return useableEffects[effectDropdown.SelectedIndex];
            }
        }

        private static OFXParameter activeParameter
        {
            get
            {
                return useableParameters[parameterDropdown.SelectedIndex];
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
                        if (effect.IsOFX && getUseableParametersOf(effect).Count > 0)
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
                return getUseableParametersOf(activeEffect);
            }
        }

        public static List<OFXParameter> getUseableParametersOf(Effect effect)
        {
            List<OFXParameter> parameters = new List<OFXParameter>();
            foreach (OFXParameter parameter in effect.OFXEffect.Parameters)
            {
                if (parameter.CanAnimate && useableParameterTypes.Contains(parameter.ParameterType))
                {
                    parameters.Add(parameter);
                }
            }
            return parameters;
        }

        private static OFXInterpolationType interpolationType
        {
            get
            {
                return (OFXInterpolationType)(interpolationDropdown.SelectedIndex + 1);
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

        public static void MakeKeyframe(double value, Timecode time, bool interpolate, int forceInterpolationType = -1)
        {
            if (activeParameter.ParameterType == OFXParameterType.Double)
            {
                OFXParameter<double, OFXDoubleKeyframe> param = (OFXParameter<double, OFXDoubleKeyframe>)activeParameter;

                param.SetValueAtTime(time, value);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType)forceInterpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Double2D)
            {
                OFXParameter<OFXDouble2D, OFXDouble2DKeyframe> param = (OFXParameter<OFXDouble2D, OFXDouble2DKeyframe>)activeParameter;

                OFXDouble2D newValue = new OFXDouble2D();
                if (radioButtons[0].Checked)
                {
                    newValue.X = value;
                    newValue.Y = param.GetValueAtTime(time).Y;
                }
                else
                {
                    newValue.X = param.GetValueAtTime(time).X;
                    newValue.Y = value;
                }
                param.SetValueAtTime(time, newValue);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType) forceInterpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Double3D)
            {
                OFXParameter<OFXDouble3D, OFXDouble3DKeyframe> param = (OFXParameter<OFXDouble3D, OFXDouble3DKeyframe>)activeParameter;

                OFXDouble3D newValue = new OFXDouble3D();
                if (radioButtons[0].Checked)
                {
                    newValue.X = value;
                    newValue.Y = param.GetValueAtTime(time).Y;
                    newValue.Z = param.GetValueAtTime(time).Z;
                }
                else if (radioButtons[1].Checked)
                {
                    newValue.X = param.GetValueAtTime(time).X;
                    newValue.Y = value;
                    newValue.Z = param.GetValueAtTime(time).Z;
                }
                else
                {
                    newValue.X = param.GetValueAtTime(time).X;
                    newValue.Y = param.GetValueAtTime(time).Y;
                    newValue.Z = value;
                }
                param.SetValueAtTime(time, newValue);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType)forceInterpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Integer)
            {
                OFXParameter<int, OFXIntegerKeyframe> param = (OFXParameter<int, OFXIntegerKeyframe>)activeParameter;

                int intValue = (int)Math.Round(value);
                param.SetValueAtTime(time, intValue);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType)forceInterpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Integer2D)
            {
                OFXParameter<OFXInteger2D, OFXInteger2DKeyframe> param = (OFXParameter<OFXInteger2D, OFXInteger2DKeyframe>)activeParameter;

                int intValue = (int)Math.Round(value);
                OFXInteger2D newValue = new OFXInteger2D();
                if (radioButtons[0].Checked)
                {
                    newValue.X = intValue;
                    newValue.Y = param.GetValueAtTime(time).Y;
                }
                else
                {
                    newValue.X = param.GetValueAtTime(time).X;
                    newValue.Y = intValue;
                }
                param.SetValueAtTime(time, newValue);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType)forceInterpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Integer3D)
            {
                OFXParameter<OFXInteger3D, OFXInteger3DKeyframe> param = (OFXParameter<OFXInteger3D, OFXInteger3DKeyframe>)activeParameter;

                int intValue = (int)Math.Round(value);
                OFXInteger3D newValue = new OFXInteger3D();
                if (radioButtons[0].Checked)
                {
                    newValue.X = intValue;
                    newValue.Y = param.GetValueAtTime(time).Y;
                    newValue.Z = param.GetValueAtTime(time).Z;
                }
                else if (radioButtons[1].Checked)
                {
                    newValue.X = param.GetValueAtTime(time).X;
                    newValue.Y = intValue;
                    newValue.Z = param.GetValueAtTime(time).Z;
                }
                else
                {
                    newValue.X = param.GetValueAtTime(time).X;
                    newValue.Y = param.GetValueAtTime(time).Y;
                    newValue.Z = intValue;
                }
                param.SetValueAtTime(time, newValue);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType)forceInterpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.RGB)
            {
                OFXParameter<OFXColor, OFXRGBKeyframe> param = (OFXParameter<OFXColor, OFXRGBKeyframe>)activeParameter;

                OFXColor newValue = new OFXColor();
                if (radioButtons[0].Checked)
                {
                    newValue.R = value;
                    newValue.G = param.GetValueAtTime(time).G;
                    newValue.B = param.GetValueAtTime(time).B;
                    newValue.A = param.GetValueAtTime(time).A;
                }
                else if (radioButtons[1].Checked)
                {
                    newValue.R = param.GetValueAtTime(time).R;
                    newValue.G = value;
                    newValue.B = param.GetValueAtTime(time).B;
                    newValue.A = param.GetValueAtTime(time).A;
                }
                else
                {
                    newValue.R = param.GetValueAtTime(time).R;
                    newValue.G = param.GetValueAtTime(time).G;
                    newValue.B = value;
                    newValue.A = param.GetValueAtTime(time).A;
                }
                param.SetValueAtTime(time, newValue);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType)forceInterpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.RGBA)
            {
                OFXParameter<OFXColor, OFXRGBAKeyframe> param = (OFXParameter<OFXColor, OFXRGBAKeyframe>)activeParameter;

                OFXColor newValue = new OFXColor();
                if (radioButtons[0].Checked)
                {
                    newValue.R = value;
                    newValue.G = param.GetValueAtTime(time).G;
                    newValue.B = param.GetValueAtTime(time).B;
                    newValue.A = param.GetValueAtTime(time).A;
                }
                else if (radioButtons[1].Checked)
                {
                    newValue.R = param.GetValueAtTime(time).R;
                    newValue.G = value;
                    newValue.B = param.GetValueAtTime(time).B;
                    newValue.A = param.GetValueAtTime(time).A;
                }
                else if (radioButtons[2].Checked)
                {
                    newValue.R = param.GetValueAtTime(time).R;
                    newValue.G = param.GetValueAtTime(time).G;
                    newValue.B = value;
                    newValue.A = param.GetValueAtTime(time).A;
                }
                else
                {
                    newValue.R = param.GetValueAtTime(time).R;
                    newValue.G = param.GetValueAtTime(time).G;
                    newValue.B = param.GetValueAtTime(time).B;
                    newValue.A = value;
                }
                param.SetValueAtTime(time, newValue);

                if (interpolate)
                {
                    if (forceInterpolationType == -1)
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = interpolationType;
                    }
                    else
                    {
                        param.Keyframes[param.Keyframes.Count - 1].Interpolation = (OFXInterpolationType)forceInterpolationType;
                    }
                }
            }
            else
            {
                throw new Exception("Unsupported OFX Parameter Type");
            }
        }

        public static void SetUpRadioButtons()
        {
            if (activeParameter.ParameterType == OFXParameterType.Double || activeParameter.ParameterType == OFXParameterType.Integer)
            {
                setUpRadioButton(0, false);
                setUpRadioButton(1, false);
                setUpRadioButton(2, false);
                setUpRadioButton(3, false);
            }
            else if (activeParameter.ParameterType == OFXParameterType.Double2D || activeParameter.ParameterType == OFXParameterType.Integer2D)
            {
                setUpRadioButton(0, true, "X");
                setUpRadioButton(1, true, "Y");
                setUpRadioButton(2, false);
                setUpRadioButton(3, false);
            }
            else if (activeParameter.ParameterType == OFXParameterType.Double3D || activeParameter.ParameterType == OFXParameterType.Integer3D)
            {
                setUpRadioButton(0, true, "X");
                setUpRadioButton(1, true, "Y");
                setUpRadioButton(2, true, "Z");
                setUpRadioButton(3, false);
            }
            else if (activeParameter.ParameterType == OFXParameterType.RGB)
            {
                setUpRadioButton(0, true, "R");
                setUpRadioButton(1, true, "G");
                setUpRadioButton(2, true, "B");
                setUpRadioButton(3, false);
            }
            else if (activeParameter.ParameterType == OFXParameterType.RGBA)
            {
                setUpRadioButton(0, true, "R");
                setUpRadioButton(1, true, "G");
                setUpRadioButton(2, true, "B");
                setUpRadioButton(3, true, "A");
            }
            else
            {
                throw new Exception("Unsupported OFX Parameter Type");
            }
        }

        private static void setUpRadioButton(int radioButtonIndex, bool enabled, string text = "")
        {
            RadioButton radioButton = radioButtons[radioButtonIndex];

            radioButton.Enabled = enabled;
            radioButton.Visible = enabled;
            radioButton.Text = text;

            if (!enabled && radioButton.Checked)
            {
                radioButtons[0].Checked = true;
            }
        }
    }
}
