using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private RectTransform selectionBox;
    [SerializeField] private RectTransform targetLine;
    private bool isClickedBox;
    private bool isClickedLine;
    private Vector3 startMousePositionBox;
    private Vector3 startMousePositionLine;
    private List<GameObject> selectedUnits;
    
    void Start()
    {
        isClickedBox = false;
        isClickedLine = false;
        selectionBox.gameObject.SetActive(false);
        targetLine.gameObject.SetActive(false);
        selectedUnits = new List<GameObject>();
    }

    void Update()
    {
        selectionBoxHandler();
        targetLineHandler();
    }

    private void selectionBoxHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectedUnits.Clear();
            startMousePositionBox = Input.mousePosition;
            isClickedBox = true;
            selectionBox.gameObject.SetActive(true);
        }

        if (isClickedBox)
        {
            float boxWidth = Input.mousePosition.x - startMousePositionBox.x;
            float boxHeight = Input.mousePosition.y - startMousePositionBox.y;
            
            selectionBox.sizeDelta = new Vector2(Mathf.Abs(boxWidth), Mathf.Abs(boxHeight));
            selectionBox.anchoredPosition = (startMousePositionBox + Input.mousePosition) / 2;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isInSelectionBox();
            isClickedBox = false;
            selectionBox.gameObject.SetActive(false);
        }
    }
    
    private void isInSelectionBox()
    {
        if (isClickedBox)
        {
            float left = selectionBox.anchoredPosition.x - (selectionBox.sizeDelta.x / 2);
            float right = selectionBox.anchoredPosition.x + (selectionBox.sizeDelta.x / 2);
            float bottom = selectionBox.anchoredPosition.y - (selectionBox.sizeDelta.y / 2);
            float top = selectionBox.anchoredPosition.y + (selectionBox.sizeDelta.y / 2);

            foreach (GameObject friendly in GlobalVariables.friendlies)
            {
                Vector3 objPositionOnSreen = Camera.main.WorldToScreenPoint(friendly.transform.position);

                if (objPositionOnSreen.x > left && objPositionOnSreen.x < right
                                                && objPositionOnSreen.y > bottom && objPositionOnSreen.y < top 
                                                && friendly.GetComponentInChildren<FriendlyStats>()._health > 0)
                {
                    friendly.GetComponentInChildren<FriendlyStats>()._isSelected = true;
                    selectedUnits.Add(friendly);
                }
            }
        }
    }

    private void targetLineHandler()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startMousePositionLine = Input.mousePosition;
            isClickedLine = true;
            targetLine.gameObject.SetActive(true);
        }

        if (isClickedLine)
        {
            float distance = Vector2.Distance(startMousePositionLine, Input.mousePosition);
            Vector2 direction = startMousePositionLine - Input.mousePosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            targetLine.eulerAngles = new Vector3(0, 0, angle + 90);
            targetLine.sizeDelta = new Vector2(5f, distance);
            targetLine.anchoredPosition = (startMousePositionLine + Input.mousePosition) / 2;
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            findTargetPositions();
            isClickedLine = false;
            targetLine.gameObject.SetActive(false);
        }
    }

    private void findTargetPositions()
    {
        if (selectedUnits.Count > 0)
        {
            Vector3 targetIteration, targetPosition;
            for (int i = 0; i < selectedUnits.Count - 1; i++)
            {
                targetIteration = (Input.mousePosition - startMousePositionLine) / (selectedUnits.Count-1);
                targetPosition = Camera.main.ScreenToWorldPoint(startMousePositionLine + (i * targetIteration));
                targetPosition.z = 0;
                selectedUnits[i].GetComponentInChildren<FriendlyStats>()._targetPosition = targetPosition;
            }
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            selectedUnits[selectedUnits.Count - 1].GetComponentInChildren<FriendlyStats>()._targetPosition = targetPosition;
        }
    }
}
