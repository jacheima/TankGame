using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Enemies;

    public bool singlePlayer = false;
    public bool multiPlayer = false;

    public bool player1died = false;
    public bool player2died = false;

    public int player1Score = 0;
    public int player2Score = 0;

    public int player1Lives = 3;
    public int player2Lives = 3;

    public GameObject player1;
    public GameObject player2;

    public Camera player1Camera;
    public Camera player2Camera;

    public InputController player1IC;
    public Player2IC player2IC;

    public GameObject gameOverPanel;

    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text player1LivesText;
    public Text player2LivesText;


    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            Debug.Log("Creating a Game Manager");

            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (player1died)
        {

            player1.transform.localPosition = new Vector3(5f, 13f, 197f);
            player1Camera.transform.localPosition = new Vector3(5f, 17f, 192f);
            player1.SetActive(true);
            player1died = false;
            player1.gameObject.GetComponent<PawnData>().health = 10f;

            player1Lives--;

            if (player1Lives <= 0)
            {
                player1Camera.rect = new Rect(0f, 0f, 1f, 1f);
                gameOverPanel.SetActive(true);

            }

            UpdatePlayer1UI();
        }

        if (player2died)
        {
            player2.transform.position = new Vector3(6f, 13f, 197f);
            player2Camera.transform.position = new Vector3(6.5f, 17f, 192f);
            player2.SetActive(true);
            player2died = false;

            player2Lives--;

            if (player2Lives <= 0)
            {
                player1Camera.rect = new Rect(0f, 0f, 1f, 1f);
                gameOverPanel.SetActive(true);
            }

            UpdatePlayer2UI();
        }

    }

    public void StartSinglePlayer()
    {
        singlePlayer = true;
        multiPlayer = false;

        SceneManager.LoadScene(1);

    }

    public void StartMultiPlayer()
    {
        singlePlayer = false;
        multiPlayer = true;

       

        SceneManager.LoadScene(1);
    }

    public void OptionsMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GetStuff()
    {
        player1 = GameObject.FindWithTag("Player");
        if (player1 != null)
        {
            player1IC = GameObject.FindWithTag("Player1IC").GetComponent<InputController>();
            player1Camera = GameObject.FindWithTag("Player1Camera").GetComponent<Camera>();
        }

        player2 = GameObject.FindWithTag("Player2");
        if (player2 != null)
        {
            player2IC = GameObject.FindWithTag("Player2IC").GetComponent<Player2IC>();
            player2Camera = GameObject.FindWithTag("Player2Camera").GetComponent<Camera>();
        }

        gameOverPanel = GameObject.FindWithTag("GameOverPanel");

        player1ScoreText = GameObject.FindWithTag("P1ScoreTxt").GetComponent<Text>();
        player1LivesText = GameObject.FindWithTag("P1LivesTxt").GetComponent<Text>();

        player1LivesText.text = player1Lives.ToString();
        player1ScoreText.text = player1Score.ToString();

        player2ScoreText = GameObject.FindWithTag("P2ScoreTxt").GetComponent<Text>();
        player2LivesText = GameObject.FindWithTag("P2LivesTxt").GetComponent<Text>();

        player2LivesText.text = player2Lives.ToString();
        player2ScoreText.text = player2Score.ToString();

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void UpdatePlayer1UI()
    {
        player1ScoreText.text = player1Score.ToString();
        player1LivesText.text = player1Lives.ToString();
    }

    void UpdatePlayer2UI()
    {
        player2ScoreText.text = player2Score.ToString();
        player2LivesText.text = player2Lives.ToString();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
