/*using Fusion;
using UnityEngine;

public class Shield : NetworkBehaviour
{
    [SerializeField] GameObject shieldPrefab; // ������ �� ����
    [SerializeField] Transform shieldSpawnPoint; // ����� ������ �� ����

    private bool isShieldTaken = false; // ����� ������ ��� ���� ���� ����
    private NetworkObject shieldInstance; // ����� �� ����

    // �������� ��� ����� ���� ����� ����� ����
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void UseShieldRpc(Networker networker)
    {
        // ������ ����� ���� ������� �� ����
        if (!isShieldTaken)
        {
            // ������ ������ ���� �� ���� ��� ���� ����� ������
            if (networker.IsLocalPlayer)
            {
                // ������ �� ���� ���� �����
                shieldInstance = NetworkManager.Instantiate(shieldPrefab, shieldSpawnPoint.position, Quaternion.identity);
                // ������ ����� ���� ����
                isShieldTaken = true;
            }
        }
    }
}
*/