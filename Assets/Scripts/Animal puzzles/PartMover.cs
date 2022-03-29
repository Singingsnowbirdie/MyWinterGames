using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PartMover : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    [SerializeField] int partNum;

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

    public bool IsCatched { get => isCatched; set => isCatched = value; }
    public Vector3 TargetPosition { get => targetPosition; set => targetPosition = value; }
    public CanvasGroup CanvasGroup { get => canvasGroup; set => canvasGroup = value; }
    public GameObject NewParent { get => newParent; set => newParent = value; }
    public int PartNum { get => partNum; set => partNum = value; }

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        CanvasGroup = GetComponent<CanvasGroup>();
        myParent = transform.parent.gameObject;
        rectTransform = myParent.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (returnToStartingPosition == true)
        {
            myParent.transform.position = Vector3.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);
        }
        if (isCatched == true)
        {
            myParent.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startingPosition = rectTransform.position;
        returnToStartingPosition = false;
        myParent.transform.SetAsLastSibling();
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
        }
        else
        {
            myParent.transform.SetParent(NewParent.transform);
        }
    }
}

