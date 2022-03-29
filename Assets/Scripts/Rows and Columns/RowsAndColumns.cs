using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RowsAndColumns : MonoBehaviour
{
    GridLayoutGroup grid;

    GameObject image;
    GameObject color;
    GameObject innerPanel;

    [SerializeField] GameObject gridPanel;
    [SerializeField] GameObject partsPanel;
    [SerializeField] GameObject bcgrdPanel;
    [SerializeField] GameObject nextBttn;
    [SerializeField] GameObject bcgroundMusik;
    [SerializeField] AudioSource bttnClick;
    [SerializeField] AudioSource placeCard;

    AudioSource currentMusik;

    int level;
    int columnsCount;
    int linesCount;
    int partsCount;

    List<GameObject> colors;
    List<GameObject> images;
    List<GameObject> parts;

    public int PartsCount { get => partsCount; set => partsCount = value; }
    public AudioSource PlaceCard { get => placeCard; set => placeCard = value; }

    void Start()
    {
        level = 1;
        LevelCheck();
        StartCoroutine(Fixer());
        PlayMusic();
    }


    public void Update()
    {
        if (partsCount == 0)
        {
            nextBttn.SetActive(true);
            nextBttn.transform.GetChild(0).gameObject.GetComponent<Animation>().Play("Bigger");
            nextBttn.transform.GetChild(1).gameObject.GetComponent<Animation>().Play("Bigger");
            nextBttn.transform.GetChild(2).gameObject.GetComponent<Animation>().Play("Bigger");
            nextBttn.transform.GetChild(3).gameObject.GetComponent<Animation>().Play("Bigger");
        }
    }

    public void NextBttn()
    {
        bttnClick.Play();
        level++;
        LevelCheck();
        StartCoroutine(Fixer());
        nextBttn.SetActive(false);
    }

    void LevelCheck()
    {
        Debug.Log("LevelCheck");
        if (level == 1)
        {
            columnsCount = 3;
            linesCount = 3;
            PartsCount = 4;
        }
        else if (level == 2)
        {
            columnsCount = 4;
            linesCount = 3;
            PartsCount = 6;
        }
        else if (level == 3)
        {
            columnsCount = 4;
            linesCount = 4;
            PartsCount = 9;
        }
        else if (level == 4)
        {
            columnsCount = 5;
            linesCount = 4;
            PartsCount = 12;
        }
        else if (level > 4)
        {
            columnsCount = 6;
            linesCount = 4;
            PartsCount = 15;
        }
    }

    IEnumerator Fixer()
    {
        Debug.Log("Fixer");
        if (innerPanel != null)
        {
            Debug.Log("Destroy inner panel");
            Destroy(innerPanel);
        }

        innerPanel = Instantiate(Resources.Load<GameObject>("Prefabs/Rows and Columns/Panel"));
        innerPanel.transform.SetParent(gridPanel.transform, false);

        Debug.Log("Create inner panel");
        yield return null;
        GridCustomize();
        yield return null;
        CreatingGrid();
        yield return null;
        CreatingParts();
    }

    void GridCustomize()
    {
        Debug.Log("Grid Customize");

        grid = innerPanel.gameObject.GetComponent<GridLayoutGroup>();
        grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        grid.constraintCount = columnsCount;
    }

    void CreatingGrid()
    {
        Debug.Log("Creating Grid");

        GameObject[,] myArray = new GameObject[linesCount, columnsCount];

        colors = new List<GameObject>();
        images = new List<GameObject>();

        for (int i = 0; i < linesCount; i++)
        {
            for (int f = 0; f < columnsCount; f++)
            {
                if (i == 0)
                {
                    myArray[i, f] = Instantiate(Resources.Load<GameObject>("Prefabs/Rows and Columns/Color 00"));
                    if (f != 0)
                    {
                        bool foundTheSameImage = true;
                        while (foundTheSameImage)
                        {
                            int randomImg = Random.Range(1, 23);
                            image = Resources.Load<GameObject>("Prefabs/Rows and Columns/Image " + randomImg);
                            if (!images.Contains(image))
                            {
                                foundTheSameImage = false;
                                images.Add(image);
                                GameObject colorChild = Instantiate(image);
                                colorChild.transform.SetParent(myArray[i, f].transform, false);
                            }
                        }
                    }
                }
                else
                {
                    if (f == 0)
                    {
                        bool foundTheSameColor = true;
                        while (foundTheSameColor)
                        {
                            int randomColor = Random.Range(1, 16);
                            color = Resources.Load<GameObject>("Prefabs/Rows and Columns/Color " + randomColor);
                            if (!colors.Contains(color))
                            {
                                foundTheSameColor = false;
                                colors.Add(color);
                                myArray[i, f] = Instantiate(color);
                                Destroy(myArray[i, f].GetComponent<RnCMover>());
                            }
                        }
                    }
                    else
                    {
                        myArray[i, f] = Instantiate(Resources.Load<GameObject>("Prefabs/Rows and Columns/Color 0"));
                        myArray[i, f].gameObject.GetComponent<RnCCatcher>().Color = colors[i - 1];
                        myArray[i, f].gameObject.GetComponent<RnCCatcher>().Image = images[f - 1];
                    }
                }
                myArray[i, f].transform.SetParent(innerPanel.transform, false);
            }
        }
    }

    void CreatingParts()
    {
        Debug.Log("Creating Parts");

        parts = new List<GameObject>();

        for (int i = 0; i < colors.Count; i++)
        {
            for (int f = 0; f < images.Count; f++)
            {
                GameObject partColor = colors[i];
                GameObject partImage = images[f];
                GameObject part = Instantiate(partColor);
                part.GetComponent<RnCMover>().Color = partColor;
                GameObject partChild = Instantiate(partImage);
                part.GetComponent<RnCMover>().Image = partImage;
                partChild.transform.SetParent(part.transform, false);
                parts.Add(part);
            }
        }

        while (parts.Count > 0)
        {
            int randomPart = Random.Range(1, parts.Count + 1);
            GameObject featuredItem = parts[randomPart - 1];
            featuredItem.transform.SetParent(partsPanel.transform, false);
            parts.RemoveAt(randomPart - 1);
        }
    }

    public void HomeBttn()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeBcgrdBttn()
    {
        bttnClick.Play();
        bcgrdPanel.transform.GetChild(0).transform.SetAsLastSibling();
    }

    public void PlayMusic()
    {
        int i = Random.Range(0, 2);
        currentMusik = bcgroundMusik.transform.GetChild(i).GetComponent<AudioSource>();
        currentMusik.Play();
    }
}

