using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private Button recruitButton;
    [SerializeField] private Button riflemanButton;
    [SerializeField] private Button marineButton;
    [SerializeField] private Button specialForcesButton;
    [SerializeField] private Button machineGunnerButton;
    [SerializeField] private Button sniperButton;

    [SerializeField] private GameObject recruit;
    [SerializeField] private GameObject rifleman;
    [SerializeField] private GameObject marine;
    [SerializeField] private GameObject specialForces;
    [SerializeField] private GameObject machineGunner;
    [SerializeField] private GameObject sniper;
    
    private float MAX_Y_SPAWN = 9.6f;
    
    void Start()
    {
        recruitButton.onClick.AddListener(onRecruitButtonClick);
        riflemanButton.onClick.AddListener(onRiflemanButtonClick);
        marineButton.onClick.AddListener(onMarineButtonClick);
        specialForcesButton.onClick.AddListener(onSpecialForcesButtonClick);
        machineGunnerButton.onClick.AddListener(onMachineGunnerButtonClick);
        sniperButton.onClick.AddListener(onSniperButtonClick);
    }

    private void onRecruitButtonClick()
    {
        if (GlobalVariables.playerCash >= GlobalVariables.recruitFriendlyCost)
        {
            spawnFriendly(recruit);
            GlobalVariables.playerCash -= GlobalVariables.recruitFriendlyCost;
        }
    }
    
    private void onRiflemanButtonClick()
    {
        if (GlobalVariables.playerCash >= GlobalVariables.riflemanFriendlyCost)
        {
            spawnFriendly(rifleman);
            GlobalVariables.playerCash -= GlobalVariables.riflemanFriendlyCost;
        }
    }
    
    private void onMarineButtonClick()
    {
        if (GlobalVariables.playerCash >= GlobalVariables.marineFriendlyCost)
        {
            spawnFriendly(marine);
            GlobalVariables.playerCash -= GlobalVariables.marineFriendlyCost;
        }
    }
    
    private void onSpecialForcesButtonClick()
    {
        if (GlobalVariables.playerCash >= GlobalVariables.specialForcesFriendlyCost)
        {
            spawnFriendly(specialForces);
            GlobalVariables.playerCash -= GlobalVariables.specialForcesFriendlyCost;
        }
    }
    
    private void onMachineGunnerButtonClick()
    {
        if (GlobalVariables.playerCash >= GlobalVariables.machineGunnerFriendlyCost)
        {
            spawnFriendly(machineGunner);
            GlobalVariables.playerCash -= GlobalVariables.machineGunnerFriendlyCost;
        }
    }
    
    private void onSniperButtonClick()
    {
        if (GlobalVariables.playerCash >= GlobalVariables.sniperFriendlyCost)
        {
            spawnFriendly(sniper);
            GlobalVariables.playerCash -= GlobalVariables.sniperFriendlyCost;
        }
    }

    private void spawnFriendly(GameObject unit)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, 
            Random.value * MAX_Y_SPAWN, 
            transform.position.z);
        GameObject newFriendly = Instantiate(unit, spawnPosition, Quaternion.identity);
        GlobalVariables.friendlies.Add(newFriendly);
    }
}
