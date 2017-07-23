using Xamarin.Forms;

namespace ProgressRingControl.Forms.Plugin
{
    // Version 0.2: 
	// TODO: Add validation method for progress values
	// TODO: Add Animation easing property (for binding) + use in AnimatedProgress
	// TODO: Add animation time property (for binding) + use in AnimatedProgress
	// TODO: Add circle fill

	public class ProgressRing : ProgressBar
    {
        #region Properties

        // Source: https://www.jimbobbennett.io/animating-xamarin-forms-progress-bars/
        public static readonly BindableProperty AnimatedProgressProperty = BindableProperty.Create("AnimatedProgress", typeof(double),
                                                                                                   typeof(ProgressRing), 0.5,
                                                                                                   propertyChanged: HandleAnimatedProgressBindablePropertyChanged);
        public double AnimatedProgress
        {
            get { return (double)base.GetValue(AnimatedProgressProperty); }
            set
            {
                base.SetValue(AnimatedProgressProperty, value);

                ViewExtensions.CancelAnimations(this);
                ProgressTo(value, 800, Easing.SinOut);
            }
        }

        public static readonly BindableProperty RingProgressColorProperty = BindableProperty.Create("RingProgressColor", typeof(Color),
                                                                                                    typeof(ProgressRing), Color.FromRgb(234, 105, 92));
        public Color RingProgressColor
        {
            get { return (Color)base.GetValue(RingProgressColorProperty); }
            set { base.SetValue(RingProgressColorProperty, value); }
        }

        public static readonly BindableProperty RingBaseColorProperty = BindableProperty.Create("RingBaseColor", typeof(Color),
                                                                                                typeof(ProgressRing), Color.FromRgb(46, 60, 76));
        public Color RingBaseColor
        {
            get { return (Color)base.GetValue(RingBaseColorProperty); }
            set { base.SetValue(RingBaseColorProperty, value); }
        }

        public static readonly BindableProperty RingThicknessProperty = BindableProperty.Create("RingThickness", typeof(double),
                                                                                                typeof(ProgressRing), 5.0);
        public double RingThickness
        {
            get { return (double)base.GetValue(RingThicknessProperty); }
            set { base.SetValue(RingThicknessProperty, value); }
        }

		#endregion

		static void HandleAnimatedProgressBindablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var progress = (ProgressRing)bindable;
		    progress.AnimatedProgress = (double)newValue;
		}
	}
}
