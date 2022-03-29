using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    [SerializeField] int zoneNum;
    WinterHouses game;

    private void Awake()
    {
        game = FindObjectOfType<WinterHouses>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<ItemMover>() != null)
        {
            if (other.GetComponent<ItemMover>().ChildNum == zoneNum)
            {
                other.GetComponent<ItemMover>().TargetPosition = GetComponent<RectTransform>().position;
                other.GetComponent<ItemMover>().NewParent = gameObject;
                other.GetComponent<ItemMover>().IsCatched = true;
                game.PlaceItem.Play();
                other.GetComponent<ItemMover>().CanvasGroup.blocksRaycasts = false;
            }

        }
    }

}

