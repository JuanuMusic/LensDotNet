using LensDotNet.Client;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Examples.CLI
{
    internal static class ExploreProfiles
    {
        internal static async Task Run()
        {
            var config = new LensConfig(LensConfig.DEVELOPMENT_GQL_ENDPOINT);
            var client = new ProfileClient(config);
            var profiles = await client.ExploreProfiles();

            Console.WriteLine($"Found {profiles.Items.Length} profiles");
            foreach (var profile in profiles.Items)
            {
                Console.WriteLine($"name: {profile.Name} - owner: {profile.OwnedBy} - id: {profile.Id}");
            }

            Console.WriteLine("Explore Profiles completed.");
            Console.WriteLine(" Press any key to continue...");
            Console.Read();
        }
    }
}
