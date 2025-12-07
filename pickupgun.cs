using UnityEngine;

public class pickupgun : MonoBehaviour
{
    public gun gun;
    public GameObject gunpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            gunpoint.SetActive(false);
            movement.instance.gunpickup(gun);

        }
        
    }
}
