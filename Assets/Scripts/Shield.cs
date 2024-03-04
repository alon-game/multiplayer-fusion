/*using Fusion;
using UnityEngine;

public class Shield : NetworkBehaviour
{
    [SerializeField] GameObject shieldPrefab; // פריפאב של המגן
    [SerializeField] Transform shieldSpawnPoint; // נקודת ההופעה של המגן

    private bool isShieldTaken = false; // משתנה שיציין האם המגן כרגע תפוס
    private NetworkObject shieldInstance; // המופע של המגן

    // הפונקציה הזו תופעל ברגע ששחקן משתמש במגן
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void UseShieldRpc(Networker networker)
    {
        // בודקים שהמגן זמין ושעדיין לא נלקח
        if (!isShieldTaken)
        {
            // בודקים שהשחקן שקוח את המגן הוא באמת השחקן הנוכחי
            if (networker.IsLocalPlayer)
            {
                // יוצרים את המגן בתוך המשחק
                shieldInstance = NetworkManager.Instantiate(shieldPrefab, shieldSpawnPoint.position, Quaternion.identity);
                // מסמנים שהמגן כרגע תפוס
                isShieldTaken = true;
            }
        }
    }
}
*/