using UnityEngine;

public class ammopickup : MonoBehaviour
{
    private bool collected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && !collected)
        {
            movement.instance.activegun.getammuntion();
            Destroy(gameObject);
            collected = true;
        }
    }
}
