using UnityEngine;
using Unity.Netcode;

public class RandomPlayerColour : NetworkBehaviour
{
    NetworkVariable<Color> NetworkPlayerColor = new NetworkVariable<Color>();
    public Color PlayerColor;
    public Renderer PlayerRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IsLocalPlayer)
        {
            PlayerColor = Random.ColorHSV();
            NetworkPlayerColor.Value = PlayerColor;
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerRenderer.material.color = NetworkPlayerColor.Value;
    }
}
