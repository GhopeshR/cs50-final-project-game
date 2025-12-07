using UnityEngine;
using UnityEngine.AI;

public class enemymovement : MonoBehaviour
{
    public float movespeed,stoppingdistance;
    private Vector3 target;
    public NavMeshAgent agent;
    public GameObject bullet;
    public Transform firepoint;
    public float firerate;
    private float firecount;
    public Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = movement.instance.transform.position;
        //target.y = transform.position.y;
        agent.destination = target;
        //transform.LookAt(target);
        //rb.linearVelocity = transform.forward * movespeed;
        if (Vector3.Distance(transform.position, target) > stoppingdistance)
        {
            agent.destination = target;
        }
        else
        {
            agent.destination = transform.position;
        }
        firecount-=Time.deltaTime;
        if (firecount <= 0)
        {
            firecount = firerate;
            firepoint.LookAt(movement.instance.transform.position + new Vector3(0f, 1f,0f));
            Vector3 targetdirection = movement.instance.transform.position-transform.position;
            float angle = Vector3.SignedAngle(targetdirection, transform.forward, Vector3.up);
            if (Mathf.Abs(angle) < 45f)
            {
                Instantiate(bullet, firepoint.position, firepoint.rotation);
            }
            else
            {
                agent.destination = target;
            }
            if(agent.remainingDistance < 0.3f)
            {
                animator.SetBool("ismoving", false);
            }
            else
            {
                animator.SetBool("ismoving", true);
            }
        }
        
    }
}
