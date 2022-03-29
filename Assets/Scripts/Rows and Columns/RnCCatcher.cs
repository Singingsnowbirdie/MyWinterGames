using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RnCCatcher : MonoBehaviour
{
    GameObject color;
    GameObject image;

    RowsAndColumns controller;

    public GameObject Color { get => color; set => color = value; }
    public GameObject Image { get => image; set => image = value; }

    private void Awake()
    {
        controller = FindObjectOfType<RowsAndColumns>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<RnCMover>() != null)
        {
            if (other.GetComponent<RnCMover>().Color == color && other.GetComponent<RnCMover>().Image == image)
            {
                other.GetComponent<RnCMover>().TargetPosition = GetComponent<RectTransform>().position;
                other.GetComponent<RnCMover>().NewParent = gameObject;
                other.GetComponent<RnCMover>().IsCatched = true;
                controller.PlaceCard.Play();
                other.GetComponent<RnCMover>().CanvasGroup.blocksRaycasts = false;
                controller.PartsCount--;
            }
        }
    }
}
