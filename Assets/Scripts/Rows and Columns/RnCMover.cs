using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class RnCMover : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] GameObject color;
    [SerializeField] GameObject image;

    GameObject myParent;
    GameObject newParent;

    RectTransform rectTransform;
    Canvas canvas;
    CanvasGroup canvasGroup;

    Vector3 targetPosition;

    bool isCatched = false;

    float speed = 600f;

    public GameObject Color { get => color; set => color = value; }
    public GameObject Image { get => image; set => image = value; }
    public bool IsCatched { get => isCatched; set => isCatched = value; }
    public Vector3 TargetPosition { get => targetPosition; set => targetPosition = value; }
    public GameObject NewParent { get => newParent; set => newParent = value; }
    public CanvasGroup CanvasGroup { get => canvasGroup; set => canvasGroup = value; }

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (isCatched == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        myParent = transform.parent.gameObject;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
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
            transform.SetParent(myParent.transform);
        }
        else
        {
            transform.SetParent(NewParent.transform);
        }
    }


}
