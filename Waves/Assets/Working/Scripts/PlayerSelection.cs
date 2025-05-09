using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private RectTransform selectionBox;
    private bool isClicked;
    private Vector3 startMousePosition;
    
    void Start()
    {
        isClicked = false;
        selectionBox.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Input.mousePosition;
            isClicked = true;
            selectionBox.gameObject.SetActive(true);
        }

        if (isClicked)
        {
            float boxWidth = Input.mousePosition.x - startMousePosition.x;
            float boxHeight = Input.mousePosition.y - startMousePosition.y;
            
            selectionBox.sizeDelta = new Vector2(Mathf.Abs(boxWidth), Mathf.Abs(boxHeight));
            selectionBox.anchoredPosition = (startMousePosition + Input.mousePosition) / 2;

            isInSelectionBox();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            selectionBox.gameObject.SetActive(false);
        }
    }
    
    public void isInSelectionBox()
    {
        if (isClicked)
        {
            float left = selectionBox.anchoredPosition.x - (selectionBox.sizeDelta.x / 2);
            float right = selectionBox.anchoredPosition.x + (selectionBox.sizeDelta.x / 2);
            float bottom = selectionBox.anchoredPosition.y - (selectionBox.sizeDelta.y / 2);
            float top = selectionBox.anchoredPosition.y + (selectionBox.sizeDelta.y / 2);

            foreach (GameObject friendly in GlobalVariables.friendlies)
            {
                Vector3 objPositionOnSreen = Camera.main.WorldToScreenPoint(friendly.transform.position);
                
                Debug.Log(left + " : " + right + " : " + top + " : " + bottom);
                Debug.Log(friendly + " : " + objPositionOnSreen);

                if (objPositionOnSreen.x > left && objPositionOnSreen.x < right
                                                && objPositionOnSreen.y > bottom && objPositionOnSreen.y < top)
                {
                    friendly.GetComponentInChildren<FriendlyStats>()._isSelected = true;
                }
            }
        }
    }
}
