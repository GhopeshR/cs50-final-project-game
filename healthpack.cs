using UnityEngine;

public class healthpack : MonoBehaviour
{
    public int heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            playerhealth.instance.healplayer(heal);
            Destroy(gameObject);
        }
    }
}
