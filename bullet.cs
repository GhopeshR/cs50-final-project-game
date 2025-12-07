using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletspeed,Lifetime;
    public Rigidbody rb;
    public int damage;
    public bool damageenemy, damageplayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        rb.velocity = transform.forward * bulletspeed;
        Lifetime -= Time.deltaTime;
        if(Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy" && damageenemy)
        {
            other.gameObject.GetComponent<enemyhealth>().DamageEnemy(damage);

        }
        if (other.gameObject.tag == "head" && damageenemy)
        {
            other.transform.parent.gameObject.GetComponent<enemyhealth>().DamageEnemy(damage*2);

        }
        if (other.gameObject.tag=="player"&& damageplayer)
        {
            playerhealth.instance.damageplayer(damage);

        }
        if (other.gameObject.tag == "helicopter" && damageenemy)
        {
            other.gameObject.GetComponent<enemyhealth>().DamageEnemy(damage);

        }
        Destroy(gameObject);
    }
}
