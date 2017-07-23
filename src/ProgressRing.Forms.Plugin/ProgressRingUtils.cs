using System;
using Xamarin.Forms;

namespace ProgressRingControl.Forms.Plugin
{
    public static class ProgressRingUtils
    {

        /// <summary>
        /// Dirty little function that converts a Xamarin.Forms static easing function 
        /// to a corresponding int value how it's supposed to be set in the AnimationEasing property in XAML.
        /// </summary>
        /// <returns>The method to int.</returns>
        /// <param name="easingMethod">Easing method.</param>
        public static int EasingMethodToInt(Easing easingMethod) {
            int easingMethodInt;

            if (easingMethod == Easing.BounceIn)
                easingMethodInt = 1;
            else if (easingMethod == Easing.BounceOut)
                easingMethodInt = 2;
            else if (easingMethod == Easing.CubicIn)
                easingMethodInt = 3;
            else if (easingMethod == Easing.CubicInOut)
                easingMethodInt = 4;
            else if (easingMethod == Easing.CubicOut)
                easingMethodInt = 5;
            else if (easingMethod == Easing.SinIn)
                easingMethodInt = 6;
            else if (easingMethod == Easing.SinInOut)
                easingMethodInt = 7;
            else if (easingMethod == Easing.SinOut)
                easingMethodInt = 8;
            else if (easingMethod == Easing.SpringIn)
                easingMethodInt = 9;
            else if (easingMethod == Easing.SpringOut)
                easingMethodInt = 10;
            else
                easingMethodInt = 0; // Easing.Linear

            return easingMethodInt;
        }

        /// <summary>
        /// Another dirty little function that converts an int how it's supposed to be set
        /// in the AnimationEasing property to an actual Xamarin.Forms easing function.
        /// </summary>
        /// <returns>A Xamarin.Forms easing function.</returns>
        /// <param name="value">Value.</param>
        public static Easing IntToEasingMethod(int value) {
            Easing easingMethod;

            switch (value)
            {
                case 1:
                    easingMethod = Easing.BounceIn;
                    break;
				case 2:
                    easingMethod = Easing.BounceOut;
					break;
				case 3:
                    easingMethod = Easing.CubicIn;
					break;
				case 4:
                    easingMethod = Easing.CubicInOut;
					break;
				case 5:
                    easingMethod = Easing.CubicOut;
					break;
				case 6:
                    easingMethod = Easing.SinIn;
					break;
				case 7:
                    easingMethod = Easing.SinInOut;
					break;
				case 8:
                    easingMethod = Easing.SinOut;
					break;
				case 9:
                    easingMethod = Easing.SpringIn;
					break;
				case 10:
                    easingMethod = Easing.SpringOut;
					break;
                default:
                    easingMethod = Easing.Linear;
                    break;
            }

            return easingMethod;
        }
    }
}
