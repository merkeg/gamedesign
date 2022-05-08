using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        this.panel = this.gameObject.transform.GetChild(0).gameObject;
        this.panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                this.Resume();
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                this.panel.SetActive(true);
            }
        }

    }

    public void Resume()
    {
        this.panel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Resume");
    }

    public void Hub()
    {
        Debug.Log("Hub;");
        this.Resume();
        GameManager.Instance.LoadHub();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
