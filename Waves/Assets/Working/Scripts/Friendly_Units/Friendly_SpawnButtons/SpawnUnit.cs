using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private Button recruitButton;
    [SerializeField] private Button riflemanButton;

    [SerializeField] private GameObject recruit;
    [SerializeField] private GameObject rifleman;
    
    private float MAX_Y_SPAWN = 9.6f;
    
    void Start()
    {
        recruitButton.onClick.AddListener(onRecruitButtonClick);
        riflemanButton.onClick.AddListener(onRiflemanButtonClick);
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

    private void spawnFriendly(GameObject unit)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, 
            Random.value * MAX_Y_SPAWN, 
            transform.position.z);
        GameObject newFriendly = Instantiate(unit, spawnPosition, Quaternion.identity);
        GlobalVariables.friendlies.Add(newFriendly);
    }
}
