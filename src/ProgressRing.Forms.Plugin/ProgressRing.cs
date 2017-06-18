using Xamarin.Forms;

namespace ProgressRingControl.Forms.Plugin
{
    public class ProgressRing : ProgressBar
    {
		// Source: https://www.jimbobbennett.io/animating-xamarin-forms-progress-bars/
		public static readonly BindableProperty AnimatedProgressProperty = BindableProperty.Create("AnimatedProgress", typeof(double),
                                                                                                   typeof(ProgressRing), 0.5);
        public double AnimatedProgress
        {
            get { return (double)base.GetValue(AnimatedProgressProperty); }
            set {
				ViewExtensions.CancelAnimations(this);
				ProgressTo(value, 800, Easing.SinOut);
            }
        }

        public static readonly BindableProperty RingProgressColorProperty = BindableProperty.Create("RingProgressColor", typeof(Color),
                                                                                                   typeof(ProgressRing), Color.FromRgb(234, 105, 92));
        public Color RingProgressColor {
            get { return (Color)base.GetValue(RingProgressColorProperty); }
            set { base.SetValue(RingProgressColorProperty, value); }
        }

        public static readonly BindableProperty RingBaseColorProperty = BindableProperty.Create("RingBaseColor", typeof(Color), 
                                                                                            typeof(ProgressRing), Color.FromRgb(46, 60, 76));
        public Color RingBaseColor {
            get { return (Color)base.GetValue(RingBaseColorProperty); } 
            set { base.SetValue(RingBaseColorProperty, value); }
        }

		public static readonly BindableProperty RingThicknessProperty = BindableProperty.Create("RingThickness", typeof(double),
                                                                                                typeof(ProgressRing), 5.0);
        public double RingThickness {
            get { return (double)base.GetValue(RingThicknessProperty); }
            set { base.SetValue(RingThicknessProperty, value); }
        }
    }
}
