using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //wil look for the first game object 
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //Debug.Log("logic + " + logic);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        //add
        if (collision.gameObject.layer == 3){
            Debug.Log("Collided + ");
            logic.addScore();

        }

    }

}
