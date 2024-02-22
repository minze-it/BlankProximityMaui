using Microsoft.Maui.Controls.PlatformConfiguration;

namespace blankMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

#if WINDOWS
            var _proximityDevice = Windows.Networking.Proximity.ProximityDevice.GetDefault();
            var messageSubscriptionId = _proximityDevice.SubscribeForMessage("NDEF", (device, message) =>
            {
                System.Diagnostics.Debug.WriteLine("Hier");
            });
#endif
        }
    }

}
