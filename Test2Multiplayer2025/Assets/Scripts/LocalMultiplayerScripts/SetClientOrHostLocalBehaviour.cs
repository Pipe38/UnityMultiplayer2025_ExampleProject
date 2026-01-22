using UnityEngine;
using Unity.Netcode;

public class SetClientOrHostLocalBehaviour : MonoBehaviour
{
    public NetworkManager TargetManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartHost()
    {
        TargetManager.StartHost();
    }

    public void StartClient()
    {
        TargetManager.StartClient();
    }
}
