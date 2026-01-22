using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SetClientOrHostOnlineBehaviour : MonoBehaviour
{
    public RelayManagementScript TargetRelayManager;
    public string RemoteHostJoinCode;
    public TMP_Text JoinCodeDebug;
    public Button StartClientButton;
    public TMP_InputField JoinCodeInputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JoinCodeDebug.text = TargetRelayManager.LastJoinCode;
        StartClientButton.interactable = !string.IsNullOrEmpty(JoinCodeInputField.text);
        RemoteHostJoinCode = JoinCodeInputField.text;
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
