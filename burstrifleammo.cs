using UnityEngine;

public class burstrifleammo : MonoBehaviour
{
    public static burstrifleammo instance;
    public void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fireshot3();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void fireshot3()
    {
        movement.instance.fireshot();
        movement.instance.fireshot();
        movement.instance.fireshot();
    }
}
