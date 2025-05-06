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
    public static float recruitFriendlyCost;
    public static float riflemanFriendlyCost;
    
    [Space]
    
    [Header("Speeds")]
    [SerializeField] private float _recruitFriendlyspeed;
    [SerializeField] private float _riflemanFriendlyspeed;
    public static float recruitFriendlySpeed;
    public static float riflemanFriendlySpeed;
    
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
    public static GameObject recruitEnemyPrefab;
    public static GameObject riflemanEnemyPrefab;
    
    [Header("Costs")]
    [SerializeField] private float _recruitEnemyCost;
    [SerializeField] private float _riflemanEnemyCost;
    public static float recruitEnemyCost;
    public static float riflemanEnemyCost;
    
    [Header("Speeds")]
    [SerializeField] private float _recruitEnemyspeed;
    [SerializeField] private float _riflemanEnemyspeed;
    public static float recruitEnemySpeed;
    public static float riflemanEnemySpeed;
    
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
        
        recruitFriendlySpeed = _recruitFriendlyspeed;
        riflemanFriendlySpeed = _riflemanFriendlyspeed;



        enemyList = _enemyList;
        enemyCash = _enemyStartCash;

        enemyPrefabCostPairs = new List<EnemyPrefabCostPair>();

        recruitEnemyPrefab = _recruitEnemyPrefab;
        riflemanEnemyPrefab = _riflemanEnemyPrefab;
        
        recruitEnemyCost = _recruitEnemyCost;
        riflemanEnemyCost = _riflemanEnemyCost;

        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(recruitEnemyPrefab, recruitEnemyCost));
        enemyPrefabCostPairs.Add(new EnemyPrefabCostPair(riflemanEnemyPrefab, riflemanEnemyCost));
        
        recruitEnemySpeed = _recruitEnemyspeed;
        riflemanEnemySpeed = _riflemanEnemyspeed;
    }
}