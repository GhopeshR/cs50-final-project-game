using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public int currenthealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageEnemy(int damage)
    {
        currenthealth -= damage;
        Debug.Log(currenthealth);

        if (currenthealth <= 0)
        {
            if (gameObject.tag=="helicopter")
            {
                ui.instance.downedhelicopters++;
                gamemanager.instance.killedhelos++;
                ui.instance.downedhelicopterstext.text="Downed helicopters:"+gamemanager.instance.killedhelos;
            }
            else
            {
                ui.instance.killedenemies++;
                gamemanager.instance.killedenemies++;
                ui.instance.killedenemiestext.text = "Killed Enemies:" + gamemanager.instance.killedenemies;
            }
            Destroy(gameObject);
        }

    }
}
