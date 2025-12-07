using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour
{
    public static playerhealth instance;
    public int maxhealth, currenthealth;
    public float timeuntilfinalscreen = 1f;
    public string finalscreenscene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        currenthealth=maxhealth;
        ui.instance.healthslider.maxValue = maxhealth;
        ui.instance.healthslider.value = currenthealth;
        ui.instance.health.text= "Health:"+currenthealth+"/"+maxhealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damageplayer(int damage)
    {
        ui.instance.showdamage();
        currenthealth -= damage;
        if (currenthealth <= 0)
        {
            Debug.Log("game over");
            currenthealth = 0;
            //gameObject.SetActive(false)
            //GameManager.instance.PlayerDeath()
            StartCoroutine(WaitingForFinalScreen());
        }
        ui.instance.healthslider.value = currenthealth;
        ui.instance.health.text = "Health:" + currenthealth + "/" + maxhealth;
    }
    public void healplayer(int heal)
    {
        currenthealth += heal;
        if (currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }
        ui.instance.healthslider.value = currenthealth;
        ui.instance.health.text = "Health:" + currenthealth + "/" + maxhealth;

    }
    public IEnumerator WaitingForFinalScreen()
    {
        yield return new WaitForSeconds(timeuntilfinalscreen);
        SceneManager.LoadScene(finalscreenscene);
        Cursor.lockState = CursorLockMode.None;
    }
}
