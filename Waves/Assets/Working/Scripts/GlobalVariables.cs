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
    
    [Space]
    
    [Header("Friendly Unit Costs")]
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
    
    private void Awake()
    {
        enemies = new ArrayList();
        friendlies = new ArrayList();
        
        playerCash = _playerCash;
        waveNumber = _waveNumber;
        
        recruitFriendlyCost = _recruitFriendlyCost;
        riflemanFriendlyCost = _riflemanFriendlyCost;
        marineFriendlyCost = _marineFriendlyCost;
        specialForcesFriendlyCost = _specialForcesFriendlyCost;
        machineGunnerFriendlyCost = _machineGunnerFriendlyCost;
        sniperFriendlyCost = _sniperFriendlyCost;
    }
}