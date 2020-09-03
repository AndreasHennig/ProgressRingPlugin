using Microsoft.Toolkit.Uwp.UI.Controls;
using ProgressRingControl.Forms.Plugin;
using ProgressRingControl.Forms.Plugin.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ProgressRing), typeof(ProgressRingRenderer))]
namespace ProgressRingControl.Forms.Plugin.UWP
{

    public class ProgressRingRenderer : ViewRenderer<ProgressRing, RadialProgressBar>
    {
        RadialProgressBar ring;
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressRing> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                ring = new RadialProgressBar();
                ring.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ring.Thickness = e.NewElement.RingThickness;
                ring.IsEnabled = true;
                ring.Minimum = 0;
                ring.Maximum = 1;
                SetNativeControl(ring);
            }
        }
        
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ProgressRing.ProgressProperty.PropertyName)
            {
                ring.Value = (double)(sender as ProgressRing).Progress;
                ring.Thickness = (double)(sender as ProgressRing).RingThickness;
            }
            if (e.PropertyName == ProgressBar.ProgressProperty.PropertyName ||
                e.PropertyName == ProgressRing.RingThicknessProperty.PropertyName ||
                e.PropertyName == ProgressRing.RingBaseColorProperty.PropertyName ||
                e.PropertyName == ProgressRing.RingProgressColorProperty.PropertyName)
            {
                this.InvalidateArrange();
                //Invalidate();
            }

            if (e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                //_sizeChanged = true;
                // Invalidate();
                this.InvalidateMeasure();
                this.InvalidateArrange();
            }
        }
    }
}
