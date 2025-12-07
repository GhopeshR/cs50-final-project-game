using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public string firstlevel="level1";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playgame()
    {
        SceneManager.LoadScene(firstlevel);
    }
    public void quitgame()
    {
        Application.Quit();

    }
}
