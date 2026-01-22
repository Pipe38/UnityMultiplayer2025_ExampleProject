using UnityEngine;
using TMPro;


public class SetClientOrHostOnlineBehaviour : MonoBehaviour
{
    public RelayManagementScript TargetRelayManager;
    public string RemoteHostJoinCode;
    public TMP_Text JoinCodeDebug;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JoinCodeDebug.text = TargetRelayManager.LastJoinCode;
    }

    public void StartAsHost()
    {
        TargetRelayManager.StartHost();
    }

    public void StartAsClient()
    {
        TargetRelayManager.StartClient(RemoteHostJoinCode);
    }
}
