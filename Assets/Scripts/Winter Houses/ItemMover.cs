using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemMover : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    [SerializeField] int childNum;
    [SerializeField] GameObject mainPanel;

    Canvas canvas;
    CanvasGroup canvasGroup;

    Vector3 startingPosition;
    Vector3 targetPosition;

    GameObject myParent;
    GameObject newParent;
    RectTransform rectTransform;

    bool returnToStartingPosition = false;
    bool isCatched;
    float speed = 600f;

    public int ChildNum { get => childNum; set => childNum = value; }
    public bool IsCatched { get => isCatched; set => isCatched = value; }
    public Vector3 TargetPosition { get => targetPosition; set => targetPosition = value; }
    public CanvasGroup CanvasGroup { get => canvasGroup; set => canvasGroup = value; }
    public GameObject NewParent { get => newParent; set => newParent = value; }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (returnToStartingPosition == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);
        }
        if (isCatched == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startingPosition = rectTransform.position;
        returnToStartingPosition = false;
        myParent = transform.parent.gameObject;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        mainPanel.transform.GetChild(childNum).gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCatched == false)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsCatched == false)
        {
            returnToStartingPosition = true;
            transform.SetParent(myParent.transform);
            mainPanel.transform.GetChild(childNum).gameObject.SetActive(false);
        }
        else
        {
            transform.SetParent(NewParent.transform);
        }
    }
}

