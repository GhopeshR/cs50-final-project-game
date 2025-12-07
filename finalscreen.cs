using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalscreen : MonoBehaviour
{
    public string gamescene;
    public TextMeshProUGUI killcount,downedhelos;
    public static finalscreen instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        finalscreen.instance.killcount.text = "Killed Enemies:"+0;
        finalscreen.instance.downedhelos.text = "Killed Enemies:" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        finalscreen.instance.killcount.text = "Killed Enemies:" + ui.instance.killedenemies;
        finalscreen.instance.downedhelos.text = "Downed Helos:" + ui.instance.downedhelicopters;
    }
    public void playagain()
    {
        SceneManager.LoadScene(gamescene);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
