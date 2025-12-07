using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject enemytospawn;
    public float timetospawn;
    private float spawncounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawncounter=timetospawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawncounter-=Time.deltaTime;
        if(spawncounter<=0)
        {
            spawncounter = timetospawn;
            Instantiate(enemytospawn,transform.position,transform.rotation);
        }
    }
}
