using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float moveSpeed = 5 ;
    public float deadZone = -10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = transform.position + (Vector3.right * 10 );
    }

    // Update is called once per frame
    void Update()
    { // * Time.deltatime ensures that multiplication is the same no matter of the frame rate 
        transform.position = transform.position + (Vector3.left * moveSpeed ) * Time.deltaTime;

        if (transform.position.x < deadZone){
            Debug.Log("Pipe deleted");
            Destroy(gameObject);

        }
    }
}
