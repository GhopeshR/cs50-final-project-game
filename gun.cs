using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bullet;
    public bool canautofire;
    public float firerate;
    [HideInInspector]
    public float firecounter;
    public int currentammo,pickupamount;
    public Transform firepoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firecounter > 0)
        {
            firecounter -= Time.deltaTime;
        }
        
    }
    public void getammuntion()
    {
        currentammo += pickupamount;
        ui.instance.ammo.text = "Ammo:" + " " + currentammo;
    }
}
