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
    
    [Space]
    
    [Header("Friendly Unit Costs")]
    
    [Header("Costs")]
    [SerializeField] private float _recruitFriendlyCost;
    [SerializeField] private float _riflemanFriendlyCost;
    [SerializeField] private float _marineFriendlyCost;
    [SerializeField] private float _specialForcesFriendlyCost;
    [SerializeField] private float _machineGunnerFriendlyCost;
    [SerializeField] private float _sniperFriendlyCost;
    public static float recruitFriendlyCost;
    public static float riflemanFriendlyCost;
    public static float marineFriendlyCost;
    public static float specialForcesFriendlyCost;
    public static float machineGunnerFriendlyCost;
    public static float sniperFriendlyCost;
    
    [Space]
    
    [Header("Speeds")]
    [SerializeField] private float _recruitFriendlyspeed;
    public static float recruitFriendlyspeed;
    
    private void Awake()
    {
        enemies = new ArrayList();
        friendlies = new ArrayList();
        
        playerCash = _playerCash;
        waveNumber = _waveNumber;
        waveStartTime = _waveStartTime;
        waveRepeatTime = _waveRepeatTime;
        
        recruitFriendlyCost = _recruitFriendlyCost;
        riflemanFriendlyCost = _riflemanFriendlyCost;
        marineFriendlyCost = _marineFriendlyCost;
        specialForcesFriendlyCost = _specialForcesFriendlyCost;
        machineGunnerFriendlyCost = _machineGunnerFriendlyCost;
        sniperFriendlyCost = _sniperFriendlyCost;
        
        recruitFriendlyspeed = _recruitFriendlyspeed;
    }
}