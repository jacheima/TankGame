using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;

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

    public GameObject gameOverPannel1;
    public GameObject gameOverPannel2;

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

            GameObject playerOne = Instantiate(player1, new Vector3(5f, 13f, 197f), Quaternion.identity);

            player1Lives--;

            if (player1Lives <= 0)
            {
                gameOverPannel1.SetActive(true);
                SceneManager.LoadScene(2);
            }

            UpdatePlayer1UI();
        }

        if (player2died)
        {
            GameObject playerTwo = Instantiate(player2, new Vector3(6f, 13f, 197f), Quaternion.identity);
            player2Lives--;

            if (player1Lives <= 0)
            {
                gameOverPannel2.SetActive(true);
                SceneManager.LoadScene(2);
            }

            UpdatePlayer2UI();
        }

    }


    public void KillThem()
    {

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
        player1 = GameObject.FindWithTag("Player").gameObject;
        player1IC = GameObject.FindWithTag("Player1IC").GetComponent<InputController>();
        player1Camera = GameObject.FindWithTag("Player1Camera").GetComponent<Camera>();

        player2 = GameObject.FindWithTag("Player2").gameObject;
        player2IC = GameObject.FindWithTag("Player2IC").GetComponent<Player2IC>();
        player2Camera = GameObject.FindWithTag("Player2Camera").GetComponent<Camera>();
        
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void UpdatePlayer1UI()
    {
       //player1ScoreText.text = player1Score.ToString();
        //player1LivesText.text = player1Lives.ToString();
    }

    void UpdatePlayer2UI()
    {
        //player2ScoreText.text = player2Score.ToString();
        //player2LivesText.text = player2Lives.ToString();
    }
}
