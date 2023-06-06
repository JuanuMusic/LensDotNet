using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LensDotNet.Client;
using System;
using TMPro;
using System.Text;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    LensDotNet.Client.ProfileClient profileClient;
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        profileClient = new ProfileClient(new LensDotNet.Config.LensConfig(new System.Uri("https://api-mumbai.lens.dev")));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void LoadData() {
        textMeshProUGUI.SetText("Loading...");
        var response = await profileClient.ExploreProfiles();
        if(response == null)
        {
            Debug.LogError("RESPONSE IS NULL");
            return;
        }

        if(response.Items != null)
        {
            if(response.Items.Length == 0)
            {
                Debug.LogError("NO ITEMS");
            }
            else
            {
                StringBuilder bldr = new StringBuilder();
                foreach(var item in response.Items)
                {
                    bldr.AppendLine($"Profile: {item.Name} - ID: {item.Id}");
                }
                
                textMeshProUGUI.SetText(bldr.ToString());
            }
        }
    }
}
