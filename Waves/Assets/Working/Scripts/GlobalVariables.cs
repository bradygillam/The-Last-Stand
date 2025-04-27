using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
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

    [Space]
    
    [Header("Friendly Unit Costs")]
    [SerializeField] private float _recruitSpeed;
    [SerializeField] private float _riflemanSpeed;
    [SerializeField] private float _marineSpeed;
    [SerializeField] private float _specialForcesSpeed;
    [SerializeField] private float _machineGunnerSpeed;
    [SerializeField] private float _sniperSpeed;
    public static float recruitSpeed;
    public static float riflemanSpeed;
    public static float marineSpeed;
    public static float specialForcesSpeed;
    public static float machineGunnerSpeed;
    public static float sniperSpeed;
    
    private void Awake()
    {
        playerCash = _playerCash;
        waveNumber = _waveNumber;
        
        recruitFriendlyCost = _recruitFriendlyCost;
        riflemanFriendlyCost = _riflemanFriendlyCost;
        marineFriendlyCost = _marineFriendlyCost;
        specialForcesFriendlyCost = _specialForcesFriendlyCost;
        machineGunnerFriendlyCost = _machineGunnerFriendlyCost;
        sniperFriendlyCost = _sniperFriendlyCost;
        
        recruitSpeed = _recruitSpeed;
        riflemanSpeed = _riflemanSpeed;
        marineSpeed = _marineSpeed;
        specialForcesSpeed = _specialForcesSpeed;
        machineGunnerSpeed = _machineGunnerSpeed;
        sniperSpeed = _sniperSpeed;
    }
}