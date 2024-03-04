using Fusion;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [SerializeField] NumberField HealthDisplay;
    private GameObject Shield;
    private bool isShieldTaken = false;

    [Tooltip("The mesh whose color should be changed.")]
    [SerializeField] MeshRenderer meshRendererToChange;

    [Networked(OnChanged = nameof(NetworkedHealthChanged))]
    public int NetworkedHealth { get; set; } = 100;
    private static void NetworkedHealthChanged(Changed<Health> changed)
    {
        // Here you would add code to update the player's healthbar.
        Debug.Log($"Health changed to: {changed.Behaviour.NetworkedHealth}");
        changed.Behaviour.HealthDisplay.SetNumber(changed.Behaviour.NetworkedHealth);
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    // All players can call this function; only the StateAuthority receives the call.
    public void DealDamageRpc(int damage)
    {
        // The code inside here will run on the client which owns this object (has state and input authority).
        Debug.Log("Received DealDamageRpc on StateAuthority, modifying Networked variable");
        if (isShieldTaken)
        {
            NetworkedHealth -= 0;
        }
        else
        {
            NetworkedHealth -= damage;
        }
        
    }

    [Networked(OnChanged = nameof(NetworkColorChanged))]
    public Color NetworkedColor { get; set; }
    private static void NetworkColorChanged(Changed<Health> changed)
    {
        changed.Behaviour.meshRendererToChange.material.color = changed.Behaviour.NetworkedColor;
    }

    private void OnTriggerEnter(Collider other) // if the player collide the shiled
    {
        if (other.tag == "Shield")
        {
            Shield = other.gameObject;
            Destroy(Shield);
            isShieldTaken = true; // flag
            var randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f); // change the color of the player that hold the shiled.
            // Changing the material color here directly does not work since this code is only executed on the client pressing the button and not on every client.
            // meshRendererToChange.material.color = randomColor;
            NetworkedColor = randomColor;
        }
    }
}

