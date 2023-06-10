using LensDotNet.Client;
using LensDotNet.Config;
using System.Text;

namespace LensDotNet.Examples.MAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var config = new LensConfig(LensConfig.DEVELOPMENT_GQL_ENDPOINT);
            var client = new LensClient(config);
            var profiles = await client.Explore.ExploreProfiles();

            StringBuilder bldr = new StringBuilder();
                bldr.AppendLine($"Found {profiles.Items.Length} profiles");
            foreach (var profile in profiles.Items)
            {
                bldr.AppendLine($"name: {profile.Name} - owner: {profile.OwnedBy} - id: {profile.Id}");
            }

            lblOutput.Text = bldr.ToString();

            SemanticScreenReader.Announce(CounterBtn.Text);

            SemanticScreenReader.Announce(lblOutput.Text);
        }
    }
}