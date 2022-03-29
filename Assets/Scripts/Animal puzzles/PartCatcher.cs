using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCatcher : MonoBehaviour
{
    [SerializeField] int zoneNum;
    GameObject parent;
    AnimalPuzzlesController game;

    private void Awake()
    {
        parent = transform.parent.gameObject;
        game = FindObjectOfType<AnimalPuzzlesController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PartMover>() != null)
        {
            if (other.GetComponent<PartMover>().PartNum == zoneNum)
            {
                other.GetComponent<PartMover>().TargetPosition = parent.GetComponent<RectTransform>().position;
                other.GetComponent<PartMover>().NewParent = parent;
                other.GetComponent<PartMover>().IsCatched = true;
                other.GetComponent<PartMover>().CanvasGroup.blocksRaycasts = false;
                game.CheckLevelCompletion();
            }

        }
    }

}

