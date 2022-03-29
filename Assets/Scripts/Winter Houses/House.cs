using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] GameObject houseImg;
    [SerializeField] GameObject snowImg;

    WinterHouses game;

    private void Awake()
    {
        game = FindObjectOfType<WinterHouses>();
    }

    void Start()
    {
        StartCoroutine(SetActiveHouse());
    }

    IEnumerator SetActiveHouse()
    {
        yield return new WaitForSeconds(0.1f);
        houseImg.SetActive(true);
    }

    public void SetActiveSnowBttn()
    {
        game.BttnClick.Play();
        if (snowImg.activeSelf)
        {
            snowImg.SetActive(false);
        }
        else
        {
            snowImg.SetActive(true);
        }


    }
}
