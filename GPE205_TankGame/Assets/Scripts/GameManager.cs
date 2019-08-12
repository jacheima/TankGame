using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<GameObject> Players;

    public int playerOneLives = 3;
    public int playerTwoLives = 3;

    public int playerOneScore = 0;
    public int playerTwoScore = 0;

    public int highScore = 0;

    public bool singlePlayer = false;
    public bool multiplayer = false;

    //Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager instance = null;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // Use this for initialization


    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AddDamange(GameObject target, GameObject shooter)
    {
        target.GetComponent<PawnData>().health--; 

        if(target.GetComponent<PawnData>().health <= 0)
        {
            Destroy(target);
            AddPoints(shooter);
        }
    }

    public void AddPoints(GameObject theShooter)
    {
        if(theShooter.tag == "Player")
        {
            playerOneScore++;
        }

        if(theShooter.tag == "Player2")
        {
            playerTwoScore++;
        }

        if(theShooter.tag == "Enemy")
        {
            Debug.Log("An player has been killed");
        }
    }

    public void SinglePlayer()
    {
        singlePlayer = true;
        multiplayer = false;
        SceneManager.LoadScene(1);       
    }

    public void Multiplayer()
    {
        singlePlayer = false;
        multiplayer = true;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
