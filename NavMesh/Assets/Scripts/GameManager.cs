using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles game logic (start, finish, collectables, communicates with UI, and handles sfx
/// </summary>
public class GameManager : MonoBehaviour
{
    #region Public Variables
    public int startingScore = 200;                 //Score to start with
    public int numberOfCoins = 4;                   //How many collectables to win? 
    public float secondsBetweenReduction;           //How many seconds between point reduction?
    public int scoreReductionValue;                 //How many points to reduce?
    public Text scoreText;                          //Text displaying the score
    public CanvasGroup popupGroup;                  //Displays the initial and final instructions
    public Text popupText;                          //Pop up text for instructions
    
    [HideInInspector]
    public bool initialWait = true;                 //Bool handling initial game logic
    [HideInInspector]
    public bool gameOver = false;                   //Bool handling end game logic

    #endregion
    #region Private Variables
    private float score = 0;
    private readonly float initialWaitTime = 3.5f;
    private IEnumerator popupCoroutine;
    private IEnumerator scoreCoroutine;

    #endregion


    /// <summary>
    /// Start is called before the first frame update. Set all the UI and coroutines
    /// </summary>
    void Start()
    {
        initialWait = true;

        //Set initial score/time
        score = startingScore;
        UpdateScore();
        //Start initial coroutines
        popupCoroutine = InstructionFade(0, initialWaitTime, 2);
        StartCoroutine(popupCoroutine);
        scoreCoroutine = ScoreReducer(initialWaitTime);
        StartCoroutine(scoreCoroutine);
    }

    /// <summary>
    /// Update is called once per frame. Look for quitting or restarting input.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// When an item is collected, update the score text
    /// </summary>
    private void UpdateScore()
    {
        scoreText.text =  score.ToString();
    }

    /// <summary>
    /// Finish game logic - apply message, stop player controller, stop changing the score.
    /// </summary>
    private void FinishGame()
    {
        popupText.text = "FINAL SCORE = " + score.ToString() + "\n PRESS 'R' TO RESTART";
        popupCoroutine = InstructionFade(1, 0, 2);
        StartCoroutine(popupCoroutine);
        gameOver = true;
    }




    /// <summary>
    /// Handles collecting items
    /// </summary>
    /// <param name="value"></param>The value of the collected item
    public void CollectItem(float value, AudioClip clip)
    {
        if(gameOver)
        {
            return;
        }
        score += value;
        GetComponent<AudioSource>().PlayOneShot(clip, 0.7f);
        numberOfCoins--;
        UpdateScore();
        //If that's the last coin, the game is over. 
        if(numberOfCoins <= 0)
        {
            FinishGame();
        }
    }

    /// <summary>
    /// Fade the popup canvas
    /// </summary>
    /// <param name="finalAlpha"></param>Either 1 or 0 (on or off)
    /// <param name="waitTime"></param> How long before fading?
    /// <param name="timeToFade"></param> How long does it take to fade?
    /// <returns></returns>
    private IEnumerator InstructionFade(float finalAlpha, float waitTime, float timeToFade)
    {
        yield return new WaitForSeconds(waitTime);
        float startingAlpha = popupGroup.alpha;
        float t = 0;
        while(popupGroup.alpha != finalAlpha)
        {
            t += Time.deltaTime;
            popupGroup.alpha = Mathf.Lerp(startingAlpha, finalAlpha, t / timeToFade);
            yield return new WaitForEndOfFrame();
        }
        initialWait = false;
        yield return null;
    }


    /// <summary>
    /// Everytime the amount of time passes that decreases the score, decrease it a certain amount. 
    /// </summary>
    /// <returns></returns>
    private IEnumerator ScoreReducer(float waitTime)
    {
        //Wait the amount of time equal to the instructions before starting
        yield return new WaitForSeconds(waitTime);

        while (!gameOver)
        {
            score -= scoreReductionValue;
            UpdateScore();
            yield return new WaitForSeconds(secondsBetweenReduction);
        }
    }




}
