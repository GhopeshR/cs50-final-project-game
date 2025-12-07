using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;
    public float waitafterdeath=3f;
    public int killedenemies;
    public int killedhelos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseunpause();
        }
        
    }
    public void playerdeath()
    {
        StartCoroutine(playerdeathcoroutine());

    }
    public IEnumerator playerdeathcoroutine()
    {
        yield return new WaitForSeconds(waitafterdeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void pauseunpause()
    {
        if (ui.instance.pausescreen.activeInHierarchy)
        {
            ui.instance.pausescreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        else
        {
            ui.instance.pausescreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}
