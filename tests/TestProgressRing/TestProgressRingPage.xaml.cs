using ProgressRingControl.Forms.Plugin;
using Xamarin.Forms;

namespace TestProgressRing
{
    public partial class TestProgressRingPage : ContentPage
    {
        public TestProgressRingPage()
        {
            InitializeComponent();

            Content = new ProgressRing();
        }
    }
}
