using System;
using System.Threading.Tasks;
using UnityEngine;

using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Relay;

using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Relay.Models;

public class RelayManagementScript : MonoBehaviour
{
    [Header("Relay")]
    [Tooltip("Numero massimo di client che si possono connettere all'host (non conta l'host).")]
    public int MaxConnections = 3;

    [Tooltip("udp | dtls | wss  (dtls consigliato; wss per WebGL/Web platform).")]
    public string ConnectionType = "dtls";

    [Header("Debug")]
    public string LastJoinCode;

    bool relayInitialized;

    async Task EnsureServicesAndAuth()
    {
        if (relayInitialized) return;

        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        relayInitialized = true;

        Debug.Log($"UGS init ok. PlayerId={AuthenticationService.Instance.PlayerId}");
    }

    public async void StartHost()
    {
        try
        {
            await EnsureServicesAndAuth();

            // Crea allocation
            var allocation = await RelayService.Instance.CreateAllocationAsync(MaxConnections);

            // Configura transport con i dati Relay
            var utp = NetworkManager.Singleton.GetComponent<UnityTransport>();
            utp.SetRelayServerData(AllocationUtils.ToRelayServerData(allocation, ConnectionType));

            // Ottieni join code
            LastJoinCode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

            // Avvia host
            bool ok = NetworkManager.Singleton.StartHost();
            Debug.Log(ok
                ? $"HOST avviato. JoinCode = {LastJoinCode}"
                : "StartHost() fallito.");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public async void StartClient(string joinCode)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(joinCode))
            {
                Debug.LogError("JoinCode vuoto.");
                return;
            }

            await EnsureServicesAndAuth();

            // Join allocation con join code
            var joinAllocation = await RelayService.Instance.JoinAllocationAsync(joinCode: joinCode);

            // Configura transport con i dati Relay
            var utp = NetworkManager.Singleton.GetComponent<UnityTransport>();
            utp.SetRelayServerData(AllocationUtils.ToRelayServerData(joinAllocation, ConnectionType));

            // Avvia client
            bool ok = NetworkManager.Singleton.StartClient();
            Debug.Log(ok
                ? $"CLIENT avviato. JoinCode = {joinCode}"
                : "StartClient() fallito.");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
