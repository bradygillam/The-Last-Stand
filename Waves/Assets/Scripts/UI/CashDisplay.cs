using TMPro;
using UnityEngine;

public class CashDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cashDisplayText;
    
    void FixedUpdate()
    {
        updateCashValue();
    }

    private void updateCashValue()
    {
        cashDisplayText.text = "Cash: $" + Global.playerCash;
    }
}
