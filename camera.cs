using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform cameratarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameratarget.position;
        transform.rotation = cameratarget.rotation;

        
    }
}
