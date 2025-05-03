using System.Collections;
using System.Collections.Generic;
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
    
    [Header("Friendly Unit")]
    
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
    [SerializeField] private float _riflemanFriendlyspeed;
    [SerializeField] private float _marineFriendlyspeed;
    [SerializeField] private float _specialForcesFriendlyspeed;
    [SerializeField] private float _machineGunnerFriendlyspeed;
    [SerializeField] private float _sniperFriendlySpeed;
    public static float recruitFriendlySpeed;
    public static float riflemanFriendlySpeed;
    public static float marineFriendlySpeed;
    public static float specialForcesFriendlySpeed;
    public static float machineGunnerFriendlySpeed;
    public static float sniperFriendlySpeed;
    
    [Space]
    [Space]
    [Space]

    [Header("Enemy Unit")]
    
    [Header("Spawn")]
    [SerializeField] private GameObject[] _enemyList;
    [SerializeField] private float _enemyStartCash;
    public static GameObject[] enemyList;
    public static float enemyCash;
    public static List<EnemyPrefabCostPair> enemyPrefabCostPairs;
    
    [Header("Prefabs")]
    [SerializeField] private GameObject _recruitEnemyPrefab;
    [SerializeField] private GameObject _riflemanEnemyPrefab;
    [SerializeField] private GameObject _marineEnemyPrefab;
    [SerializeField] private GameObject _specialForcesEnemyPrefab;
    [SerializeField] private GameObject _machineGunnerEnemyPrefab;
    [SerializeField] private GameObject _sniperEnemyPrefab;
    public static GameObject recruitEnemyPrefab;
    public static GameObject riflemanEnemyPrefab;
    public static GameObject marineEnemyPrefab;
    public static GameObject specialForcesEnemyPrefab;
    public static GameObject machineGunnerEnemyPrefab;
    public static GameObject sniperEnemyPrefab;
    
    [Header("Costs")]
    [SerializeField] private float _recruitEnemyCost;
    [SerializeField] private float _riflemanEnemyCost;
    [SerializeField] private float _marineEnemyCost;
    [SerializeField] private float _specialForcesEnemyCost;
    [SerializeField] private float _machineGunnerEnemyCost;
    [SerializeField] private float _sniperEnemyCost;
    public static float recruitEnemyCost;
    public static float riflemanEnemyCost;
    public static float marineEnemyCost;
    public static float specialForcesEnemyCost;
    public static float machineGunnerEnemyCost;
    public static float sniperEnemyCost;
    
    [Header("Speeds")]
    [SerializeField] private float _recruitEnemyspeed;
    [SerializeField] private float _riflemanEnemyspeed;
    [SerializeField] private float _marineEnemyspeed;
    [SerializeField] private float _specialForcesEnemyspeed;
    [SerializeField] private float _machineGunnerEnemyspeed;
    [SerializeField] private float _sniperEnemySpeed;
    public static float recruitEnemySpeed;
    public static float riflemanEnemySpeed;
    public static float marineEnemySpeed;
    public static float specialForcesEnemySpeed;
    public static float machineGunnerEnemySpeed;
    public static float sniperEnemySpeed;
    
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
        
        recruitFriendlySpeed = _recruitFriendlyspeed;
        riflemanFriendlySpeed = _riflemanFriendlyspeed;
        marineFriendlySpeed = _marineFriendlyspeed;
        specialForcesFriendlySpeed = _specialForcesFriendlyspeed;
        machineGunnerFriendlySpeed = _machineGunnerFriendlyspeed;
        sniperFriendlySpeed = _sniperFriendlySpeed;



        enemyList = _enemyList;
        enemyCash = _enemyStartCash;

        enemyPrefabCostPairs = new List<EnemyPrefabCostPair>();

        recruitEnemyPrefab = _recruitEnemyPrefab;
        riflemanEnemyPrefab = _riflemanEnemyPrefab;
        marineEnemyPrefab = _marineEnemyPrefab;
        specialForcesEnemyPrefab = _specialForcesEnemyPrefab;
        machineGunnerEnemyPrefab = _machineGunnerEnemyPrefab;
        sniperEnemyPrefab = _sniperEnemyPrefab;
        
        recruitEnemyCost = _recruitEnemyCost;
        riflemanEnemyCost = _riflemanEnemyCost;
        marineEnemyCost = _marineEnemyCost;
        specialForcesEnemyCost = _specialForcesEnemyCost;
        machineGunnerEnemyCost = _machineGunnerEnemyCost;
        sniperEnemyCost = _sniperEnemyCost;

        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(recruitEnemyPrefab, recruitEnemyCost));
        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(riflemanEnemyPrefab, riflemanEnemyCost));
        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(marineEnemyPrefab, marineEnemyCost));
        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(specialForcesEnemyPrefab, specialForcesEnemyCost));
        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(machineGunnerEnemyPrefab, machineGunnerEnemyCost));
        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(sniperEnemyPrefab, sniperEnemyCost));
        
        recruitEnemySpeed = _recruitEnemyspeed;
        riflemanEnemySpeed = _riflemanEnemyspeed;
        marineEnemySpeed = _marineEnemyspeed;
        specialForcesEnemySpeed = _specialForcesEnemyspeed;
        machineGunnerEnemySpeed = _machineGunnerEnemyspeed;
        sniperEnemySpeed = _sniperEnemySpeed;
    }
}