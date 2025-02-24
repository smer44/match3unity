using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Shuh tutorial";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && birdIsAlive){

            myRigidbody.linearVelocity = Vector2.up * flapStrength;

        }
        

        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        logic.gameOver();
        birdIsAlive = false;

    }

}
