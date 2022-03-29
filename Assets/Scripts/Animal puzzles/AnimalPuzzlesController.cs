using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPuzzlesController : MonoBehaviour
{
    int levelNum;
    int partsCount;
    GameObject levelPrefab;
    GameObject levelPanel;

    [SerializeField] GameObject levelsContainer;
    [SerializeField] GameObject nextBttn;

    void Start()
    {
        levelNum = Random.Range(1, 6);
        levelPrefab = Resources.Load<GameObject>("Prefabs/Animal puzzles/Level " + levelNum);
        levelPanel = Instantiate(levelPrefab);
        levelPanel.transform.SetParent(levelsContainer.transform, false);
        partsCount = 0;
    }

    public void CheckLevelCompletion()
    {
        partsCount++;
        if (levelPanel.GetComponent<Level>().Parts == partsCount)
        {
            StartCoroutine(LevelComplete());
        }
    }

    IEnumerator LevelComplete()
    {
        levelPanel.transform.GetChild(0).GetComponent<Animation>().Play("Animals puzzles 1");
        yield return new WaitForSeconds(1f);
        nextBttn.SetActive(true);
        nextBttn.transform.GetChild(0).gameObject.GetComponent<Animation>().Play("Bigger");
        nextBttn.transform.GetChild(1).gameObject.GetComponent<Animation>().Play("Bigger");
        nextBttn.transform.GetChild(2).gameObject.GetComponent<Animation>().Play("Bigger");
        nextBttn.transform.GetChild(3).gameObject.GetComponent<Animation>().Play("Bigger");
    }

    public void PressNextBttn()
    {
        nextBttn.SetActive(false);
        bool TheSameNumber = true;
        while (TheSameNumber)
        {
            int newNum = Random.Range(1, 5);
            if (newNum != levelNum)
            {
                TheSameNumber = false;
                levelNum = newNum;
                levelPrefab = Resources.Load<GameObject>("Prefabs/Animal puzzles/Level " + levelNum);
                levelPanel = Instantiate(levelPrefab);
                levelPanel.transform.SetParent(levelsContainer.transform, false);
                partsCount = 0;
                Destroy(levelsContainer.transform.GetChild(0).gameObject);
            }
        }
    }
}
