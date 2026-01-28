using UnityEngine;
using Unity.Netcode;
using TMPro;
using Unity.Collections;

public class NetworkPlayerNameBehaviour : NetworkBehaviour
{
    NetworkVariable<FixedString64Bytes> NetworkPlayerName = new NetworkVariable<FixedString64Bytes>("", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
    public string PlayerName;
    public TMP_Text TargetText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GameManager.Singleton.InstancedPlayerNameBehaviour.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerName = NetworkPlayerName.Value.ToString();
    
        TargetText.text = PlayerName;
    }

    public void SetPlayerName(string inPlayerName)
    {
        if (IsLocalPlayer)
        {
            PlayerName = inPlayerName;
            NetworkPlayerName.Value = PlayerName;
        }
    }

   
}
