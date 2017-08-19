using Xamarin.Forms;

namespace ProgressRingControl.Forms.Plugin
{
    // Version 0.2: 
    // DONE: AnimatedProgress / Progress: Test if value coerce is necessary (not necessary)
    // DONE: Add Animation easing property (for binding) + use in AnimatedProgress
    // DONE: Add animation time property (for binding) + use in AnimatedProgress
    // DONE: Fix Length property order thingy bug
    // DONE: Add Easing Property for xaml
	// DONE: Switch pcl to netstandard
    // TODO: Write documentation for xaml easing method thing
    // TODO: Write FAQ
    // TODO: Add circle fill

    public class ProgressRing : ProgressBar
    {
        #region Properties

        // Source: https://www.jimbobbennett.io/animating-xamarin-forms-progress-bars/
        /// <summary>
        /// Let's you animate from the current progress to a new progress using
        /// the values of the properties AnimationLength and AnimationEasing.
        /// </summary>
        public static readonly BindableProperty AnimatedProgressProperty = BindableProperty.Create("AnimatedProgress", typeof(double),
                                                                                                   typeof(ProgressRing), 0.0,
                                                                                                   propertyChanged: HandleAnimatedProgressChanged);
        public double AnimatedProgress
        {
            get { return (double)base.GetValue(AnimatedProgressProperty); }
            set
            {
                base.SetValue(AnimatedProgressProperty, value);

                StartProgressToAnimation();
            }
        }

        /// <summary>
        /// Set's the animation length that is used when using the AnimatedProgress
        /// property to animate to a certain progress.
        /// </summary>
        public static readonly BindableProperty AnimationLengthProperty = BindableProperty.Create("AnimationLength", typeof(uint),
                                                                                                  typeof(ProgressRing), (uint)800,
                                                                                                  propertyChanged: HandleAnimationLengthChanged);
        public uint AnimationLength
        {
            get { return (uint)base.GetValue(AnimationLengthProperty); }
            set { base.SetValue(AnimationLengthProperty, value); }
        }

        /// <summary>
        /// Set's the easing function that is used when using the AnimatedProgress
        /// property to animate to a certain progress.
        /// </summary>
        public static readonly BindableProperty AnimationEasingProperty = BindableProperty.Create("AnimationEasing", typeof(uint),
                                                                                                  typeof(ProgressRing), (uint)0,
                                                                                                  propertyChanged: HandleAnimationEasingChanged);

        public Easing AnimationEasing
        {
            get {
                var intValue = (uint) base.GetValue(AnimationEasingProperty);
                var easingMethod = ProgressRingUtils.IntToEasingMethod((int)intValue);

                return easingMethod;
            }
            set {
                var easingMethod = ProgressRingUtils.EasingMethodToInt(value);

                base.SetValue(AnimationEasingProperty, easingMethod); 
            }
        }

        /// <summary>
        /// Sets the ring's progress color. 
        /// HINT: The ring progress color covers the ring base color
        /// </summary>
        public static readonly BindableProperty RingProgressColorProperty = BindableProperty.Create("RingProgressColor", typeof(Color),
                                                                                                    typeof(ProgressRing), Color.FromRgb(234, 105, 92));
        public Color RingProgressColor
        {
            get { return (Color)base.GetValue(RingProgressColorProperty); }
            set { base.SetValue(RingProgressColorProperty, value); }
        }

        /// <summary>
        /// Sets the ring's base (background) color.
        /// </summary>
        public static readonly BindableProperty RingBaseColorProperty = BindableProperty.Create("RingBaseColor", typeof(Color),
                                                                                                typeof(ProgressRing), Color.FromRgb(46, 60, 76));
        public Color RingBaseColor
        {
            get { return (Color)base.GetValue(RingBaseColorProperty); }
            set { base.SetValue(RingBaseColorProperty, value); }
        }

        /// <summary>
        /// Sets the thickness of the progress Ring. The thickness "grows" into the
        /// center of the ring (so the outer dimensions are not incluenced by the
        /// ring thickess.
        /// </summary>
        public static readonly BindableProperty RingThicknessProperty = BindableProperty.Create("RingThickness", typeof(double),
                                                                                                typeof(ProgressRing), 5.0);
        public double RingThickness
        {
            get { return (double)base.GetValue(RingThicknessProperty); }
            set { base.SetValue(RingThicknessProperty, value); }
        }

        #endregion

        #region Animation

        public void StartProgressToAnimation() {
			ViewExtensions.CancelAnimations(this);
			var length = base.GetValue(AnimationLengthProperty);

			ProgressTo(AnimatedProgress, AnimationLength, AnimationEasing);
        }

        #endregion

        #region static handlers

        static void HandleAnimatedProgressChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progress = (ProgressRing)bindable;
            progress.AnimatedProgress = (double)newValue;
        }

        static void HandleAnimationLengthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progressRing = (ProgressRing)bindable;

            var animationIsRunning = progressRing.AnimationIsRunning("Progress");

            // If the progress animation is already running
            // rerun it with the new length value.
            if (animationIsRunning)
                progressRing.StartProgressToAnimation();
        }

        static void HandleAnimationEasingChanged(BindableObject bindable, object oldValue, object newValue)
		{
            var progressRing = (ProgressRing)bindable;
			var animationIsRunning = progressRing.AnimationIsRunning("Progress");

			// If the progress animation is already running
			// rerun it with the new length value.
			if (animationIsRunning)
				progressRing.StartProgressToAnimation();
		}

        #endregion

    }
}
