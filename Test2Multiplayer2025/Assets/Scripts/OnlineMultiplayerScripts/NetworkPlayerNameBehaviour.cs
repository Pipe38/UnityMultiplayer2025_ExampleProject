using UnityEngine;
using Unity.Netcode;
using TMPro;

public class NetworkPlayerNameBehaviour : NetworkBehaviour
{
    public NetworkVariable<string> NetworkPlayerName = new NetworkVariable<string>();
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
        TargetText.text = NetworkPlayerName.Value;
    }

    public void SetPlayerName(string inPlayerName)
    {
        if (IsLocalPlayer)
        {
            PlayerName = inPlayerName;
            NetworkPlayerName.Value = PlayerName;
        }
    }

    private void OnDestroy()
    {
        GameManager.Singleton.InstancedPlayerNameBehaviour.Remove(this);
    }
}
