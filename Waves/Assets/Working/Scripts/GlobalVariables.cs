using System.Collections;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static ArrayList enemies;
    public static ArrayList friendlies;
    
    [Header("Game Stats")]
    [SerializeField] private float _playerCash;
    [SerializeField] private int _waveNumber;
    [SerializeField] private int _waveStartTime;
    [SerializeField] private int _waveRepeatTime;
    public static float playerCash;
    public static int waveNumber;
    public static int waveStartTime;
    public static int waveRepeatTime;
    
    private void Awake()
    {
        enemies = new ArrayList();
        friendlies = new ArrayList();
        
        playerCash = _playerCash;
        waveNumber = _waveNumber;
        waveStartTime = _waveStartTime;
        waveRepeatTime = _waveRepeatTime;
    }
}