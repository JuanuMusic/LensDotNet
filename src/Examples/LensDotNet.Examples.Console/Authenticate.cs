using LensDotNet.Client;
using LensDotNet.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LensDotNet.Examples.CLI
{
    internal static class Authenticate
    {
        internal static async Task Run() {

            var config = new LensConfig(LensConfig.DEVELOPMENT_GQL_ENDPOINT);
            AuthenticationClient authClient = new AuthenticationClient(config);

            bool addressValid = false;
            string address = "";
            while (!addressValid)
            {
                Console.WriteLine("Enter your Lens address:");
                address = Console.ReadLine().Trim();

                if (address.Length == 0)
                {
                    System.Console.WriteLine("Please enter a valid address");
                }
                else
                {
                    try
                    {
                        var uri = new Uri($"lens:{address}");
                        if (uri.Scheme == "lens")
                        {
                            addressValid = true;
                        }
                        else
                        {
                            System.Console.WriteLine("Please enter a valid address");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid address");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Requesting challenge for address: {address}...");
            var challenge = await authClient.GenerateChallenge(address);

            if (challenge == null || challenge.Text == null)
            {
                Console.WriteLine("Invalid address");
                return;
            }

            Console.WriteLine("Please copy and sign the following text: ");
            Console.WriteLine(challenge.Text);
            Console.WriteLine();

            bool signedValid = false;
            string signed = "";
            while (!signedValid)
            {
                Console.WriteLine($"Enter your signed challenge for {address}: ");
                signed = Console.ReadLine().Trim();
                if (signed.Length == 0)
                {
                    System.Console.WriteLine("Please enter a valid signature");
                }
                else
                {
                    signedValid = true;
                }
            }

            await authClient.Authenticate(address, signed);

            PublicationClient client = new PublicationClient(config, authClient);
            System.Console.WriteLine("Bye bye");

        }
    }
}
