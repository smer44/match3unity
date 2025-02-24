using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    /// Update is called once per frame
    void Update()
    {
        
    }

    /// public runs from another script 
    [ContextMenu("Increase Score")]
    public void addScore(){
        playerScore += 1 ;
        scoreText.text = playerScore.ToString();


    }


    // this could be added in the separate logic screen : 

    public void restartGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void gameOver(){

        gameOverScreen.SetActive(true);
    }
}
