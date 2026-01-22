using UnityEngine;
using Unity.Netcode;

public class BasicMultiplayerCharacterController : NetworkBehaviour
{
    public float MovementSpid = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            transform.Translate((new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * MovementSpid) * Time.deltaTime);
        }
    }
}
