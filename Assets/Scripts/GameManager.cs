using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int featherCount = 0;
    public bool isAlive;
    public float lightLossPerSecond = 0.5f;
    private VignetteInterface vignetteInterface;
    // Start is called before the first frame updatepublic static GameManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        this.vignetteInterface = FindObjectOfType<VignetteInterface>();
        this.vignetteInterface.AddVignetteValue(-5f);
    }

    public void Restart()
    {
        this.featherCount = 0;
        this.vignetteInterface.AddVignetteValue(-5f);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        vignetteInterface.AddVignetteValue(this.lightLossPerSecond * Time.deltaTime);
        if (vignetteInterface.GetIntensity() >= 1)
        {
            SceneManager.LoadScene("LooseScene", LoadSceneMode.Single);
        }
        Debug.Log(this.featherCount);
    }
}
