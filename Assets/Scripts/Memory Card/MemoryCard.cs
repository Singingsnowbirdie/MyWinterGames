using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MemoryCard : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject bcgrdPanel;
    [SerializeField] GameObject cardsPanel;


    [Header("Bttns")]
    [SerializeField] GameObject hardModeBttn;
    [SerializeField] GameObject nextBttn;

    [Header("Audio")]
    [SerializeField] AudioSource difficultyIncreasedRu;
    [SerializeField] AudioSource difficultyRedusedRu;
    [SerializeField] AudioSource difficultyIncreasedEng;
    [SerializeField] AudioSource difficultyRedusedEng;
    [SerializeField] GameObject bcgroundMusik;
    [SerializeField] AudioSource bttnClick;
    [SerializeField] AudioSource paperTurn;

    AudioSource currentMusik;

    GameObject[] cards;
    GameObject openCard;

    Sprite[] cardShirts;
    Sprite[] cardFaces;
    Sprite cardShirt;

    int shirtNum;
    int foundСards;

    bool hardMode;

    public GameObject OpenCard { get => openCard; set => openCard = value; }
    public int FoundСards { get => foundСards; set => foundСards = value; }
    public bool HardMode { get => hardMode; set => hardMode = value; }
    public AudioSource PaperTurn { get => paperTurn; set => paperTurn = value; }

    private void Awake()
    {
        cardShirts = new Sprite[4];
        cardShirts[0] = Resources.LoadAll<Sprite>("Sprites/Memory card/3112438")[0];
        cardShirts[1] = Resources.LoadAll<Sprite>("Sprites/Memory card/3112438")[1];
        cardShirts[2] = Resources.LoadAll<Sprite>("Sprites/Memory card/3112438")[2];
        cardShirts[3] = Resources.LoadAll<Sprite>("Sprites/Memory card/3112438")[3];

        cardFaces = new Sprite[6];
        cardFaces[0] = Resources.LoadAll<Sprite>("Sprites/Memory card/199288-OYQW5I-404")[0];
        cardFaces[1] = Resources.LoadAll<Sprite>("Sprites/Memory card/199288-OYQW5I-404")[1];
        cardFaces[2] = Resources.LoadAll<Sprite>("Sprites/Memory card/199288-OYQW5I-404")[2];
        cardFaces[3] = Resources.LoadAll<Sprite>("Sprites/Memory card/199288-OYQW5I-404")[3];
        cardFaces[4] = Resources.LoadAll<Sprite>("Sprites/Memory card/199288-OYQW5I-404")[4];
        cardFaces[5] = Resources.LoadAll<Sprite>("Sprites/Memory card/199288-OYQW5I-404")[5];

        cards = new GameObject[12];

        shirtNum = 1;
        FoundСards = 0;
        HardMode = false;
    }
    void Start()
    {
        PlayMusic();
        ShooseCardShirts();
        ShooseCardFaces();
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

    public void ChangeShirtBttn()
    {
        bttnClick.Play();
        if (shirtNum < 4)
        {
            shirtNum++;
        }
        else
        {
            shirtNum = 1;
        }

        ShooseCardShirts();
    }

    public void ShooseCardShirts()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cardShirt = cardShirts[shirtNum - 1];
            cardsPanel.transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().sprite = cardShirt;
        }
    }
    public void ShooseCardFaces()
    {
        for (int i = 0; i < cardFaces.Length; i++)
        {
            for (int f = 0; f < 2; f++)
            {
                bool go = true;
                while (go)
                {
                    int randomCard = Random.Range(1, 13);
                    GameObject card = cardsPanel.transform.GetChild(randomCard - 1).gameObject;
                    if (card.GetComponent<Card>().Face == null)
                    {
                        go = false;
                        card.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = cardFaces[i];
                        card.GetComponent<Card>().Face = cardFaces[i];
                    }
                }
            }
        }
    }

    public void ChangeLevel()
    {
        HardMode = !HardMode;
        StartCoroutine(ProtectBttn());
        if (!HardMode)
        {
            hardModeBttn.transform.GetChild(0).gameObject.SetActive(true);
            hardModeBttn.transform.GetChild(1).gameObject.SetActive(false);
            if (LocalizationManager.currentLanguage == "ru_RU")
            {
                difficultyRedusedRu.Play();
            }
            else
            {
                difficultyRedusedEng.Play();
            }
        }
        else
        {
            hardModeBttn.transform.GetChild(0).gameObject.SetActive(false);
            hardModeBttn.transform.GetChild(1).gameObject.SetActive(true);
            if (LocalizationManager.currentLanguage == "ru_RU")
            {
                difficultyIncreasedRu.Play();
            }
            else
            {
                difficultyIncreasedEng.Play();
            }

        }
    }

    IEnumerator ProtectBttn()
    {
        hardModeBttn.GetComponent<CanvasGroup>().blocksRaycasts = false;
        yield return new WaitForSeconds(2);
        hardModeBttn.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void CheckProgress()
    {
        if (foundСards == 6)
        {
            StartCoroutine(ShowNextBttn());
        }
    }

    IEnumerator ShowNextBttn()
    {
        yield return new WaitForSeconds(1);
        nextBttn.SetActive(true);
        nextBttn.transform.GetChild(0).gameObject.GetComponent<Animation>().Play("Bigger");
        nextBttn.transform.GetChild(1).gameObject.GetComponent<Animation>().Play("Bigger");
        nextBttn.transform.GetChild(2).gameObject.GetComponent<Animation>().Play("Bigger");
        nextBttn.transform.GetChild(3).gameObject.GetComponent<Animation>().Play("Bigger");
    }

    public void NextBttn()
    {
        bttnClick.Play();
        StartCoroutine(NextGame());
    }

    IEnumerator NextGame()
    {
        nextBttn.SetActive(false);
        for (int i = 0; i < cards.Length; i++)
        {
            PaperTurn.Play();
            cardsPanel.transform.GetChild(i).gameObject.GetComponent<Animation>().Play("Flip Card To Shirt");
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < cards.Length; i++)
        {
            cardsPanel.transform.GetChild(i).GetComponent<Card>().Face = null;
            cardsPanel.transform.GetChild(i).GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        ShooseCardFaces();
    }

    public void PlayMusic()
    {
        int i = Random.Range(0, 2);
        currentMusik = bcgroundMusik.transform.GetChild(i).GetComponent<AudioSource>();
        currentMusik.Play();
    }

}
