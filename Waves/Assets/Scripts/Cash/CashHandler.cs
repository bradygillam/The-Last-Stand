using UnityEngine;

public class CashHandler : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("increaseCash", 1, 2);
    }
    
    private void increaseCash()
    {
        Global.playerCash += 50f;
    }
}
