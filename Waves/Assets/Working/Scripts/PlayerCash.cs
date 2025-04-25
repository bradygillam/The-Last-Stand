using System;
using UnityEngine;
using TMPro;

public class PlayerCash : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cashText;

    void Start()
    {
        InvokeRepeating("IncreaseCash", 2.5f, 2.5f);
    }

    void Update()
    {
        cashText.text = $"Cash: {GlobalVariables.playerCash}";
    }

    private void IncreaseCash()
    {
        GlobalVariables.playerCash += 50;
    }
}