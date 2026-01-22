using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public List<NetworkPlayerNameBehaviour> InstancedPlayerNameBehaviour = new List<NetworkPlayerNameBehaviour>();

    private void OnEnable()
    {
        Singleton = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerName(string inputName)
    {
        for (int i = 0; i < InstancedPlayerNameBehaviour.Count; i++)
        {
            if (InstancedPlayerNameBehaviour[i] != null)
            {
                InstancedPlayerNameBehaviour[i].SetPlayerName(inputName);
            }
        }
    }
}
