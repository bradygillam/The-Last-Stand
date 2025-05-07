using System.Collections;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static ArrayList enemies;
    public static ArrayList friendlies;
    
    [Header("Game Stats")]
    [SerializeField] private float _playerCash;
    [SerializeField] private int _waveNumber;
    public static float playerCash;
    public static int waveNumber;
    
    private void Awake()
    {
        enemies = new ArrayList();
        friendlies = new ArrayList();
        
        playerCash = _playerCash;
        waveNumber = _waveNumber;
    }
}