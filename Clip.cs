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
        public static ComboBox interpolationDropdown;

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

        public static List<OFXParameter> getUseableParametersOf (Effect effect)
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

        public static void MakeKeyframe(Object value, Timecode time, bool applyInterpolation)
        {
            if (activeParameter.ParameterType == OFXParameterType.Double)
            {
                OFXParameter<double, OFXDoubleKeyframe> param = (OFXParameter<double, OFXDoubleKeyframe>)activeParameter;
                param.SetValueAtTime(time, (double) value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Double2D)
            {
                OFXParameter<OFXDouble2D, OFXDouble2DKeyframe> param = (OFXParameter<OFXDouble2D, OFXDouble2DKeyframe>)activeParameter;
                param.SetValueAtTime(time, (OFXDouble2D) value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Double3D)
            {
                OFXParameter<OFXDouble3D, OFXDouble3DKeyframe> param = (OFXParameter<OFXDouble3D, OFXDouble3DKeyframe>)activeParameter;
                param.SetValueAtTime(time, (OFXDouble3D)value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Integer)
            {
                OFXParameter<int, OFXIntegerKeyframe> param = (OFXParameter<int, OFXIntegerKeyframe>)activeParameter;
                param.SetValueAtTime(time, (int)value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Integer2D)
            {
                OFXParameter<OFXInteger2D, OFXInteger2DKeyframe> param = (OFXParameter<OFXInteger2D, OFXInteger2DKeyframe>)activeParameter;
                param.SetValueAtTime(time, (OFXInteger2D)value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.Integer3D)
            {
                OFXParameter<OFXInteger3D, OFXInteger3DKeyframe> param = (OFXParameter<OFXInteger3D, OFXInteger3DKeyframe>)activeParameter;
                param.SetValueAtTime(time, (OFXInteger3D)value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.RGB)
            {
                OFXParameter<OFXColor, OFXRGBKeyframe> param = (OFXParameter<OFXColor, OFXRGBKeyframe>)activeParameter;
                param.SetValueAtTime(time, (OFXColor)value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else if (activeParameter.ParameterType == OFXParameterType.RGBA)
            {
                OFXParameter<OFXColor, OFXRGBAKeyframe> param = (OFXParameter<OFXColor, OFXRGBAKeyframe>)activeParameter;
                param.SetValueAtTime(time, (OFXColor)value);
                if (applyInterpolation)
                {
                    foreach (OFXKeyframe keyframe in param.Keyframes)
                    {
                        keyframe.Interpolation = interpolationType;
                    }
                }
            }
            else
            {
                throw new Exception("Unsupported OFX Parameter Type");
            }
        }
    }
}
