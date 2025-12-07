using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public static ui instance;
    public Slider healthslider;
    public TextMeshProUGUI health,ammo,killedenemiestext,downedhelicopterstext;
    public Image damageeffect;
    public float damagealpha = 0.3f, damagefadespeed = 3f;
    public GameObject pausescreen;
    public int killedenemies,downedhelicopters;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(damageeffect.color.a != 0)
        {
            damageeffect.color = new Color(damageeffect.color.r, damageeffect.color.g, damageeffect.color.b,Mathf.MoveTowards(damageeffect.color.a,0f,damagefadespeed*Time.deltaTime));
        }
        
    }
    public void showdamage()
    {
        damageeffect.color= new Color(damageeffect.color.r,damageeffect.color.g,damageeffect.color.b,0.3f);

    }
}
