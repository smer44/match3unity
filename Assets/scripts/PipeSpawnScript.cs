using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

        // attention - works every frame 

        if (timer < spawnRate){

            timer = timer + Time.deltaTime;// or +=
        }
        else{
            timer = 0;
            spawnPipe();
        }
        
    }

    void spawnPipe(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), transform.position.z), transform.rotation);


    }
}
