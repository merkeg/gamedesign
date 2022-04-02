using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Dictionary<int, List<int>> persistentFeathList = new Dictionary<int, List<int>>();
    private List<int> levelPersistentFeathList = new List<int>();
    private List<int> tempFeathList = new List<int>();
    public int levelID = -1;
    public bool isAlive;

    private Vector3? checkpoint = null;

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
    }

    public void Restart()
    {
        this.LoadLevel1();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Total: " + this.getPesistentFeatherCount());
            Debug.Log("Level: " + this.GetFeatherCountCurrentLevel());
        }
    }

    public void PlayerDeath()
    {
        this.isAlive = false;
        tempFeathList.Clear();
        SceneManager.LoadScene("LooseScene", LoadSceneMode.Single);
    }

    private void LoadScene(string sceneName, int levelID = -1, bool resetLevelFeatherList = true)
    {
        if(levelID > 0 && resetLevelFeatherList)
        {
            if(this.persistentFeathList.ContainsKey(levelID) == false)
            {
                this.persistentFeathList[levelID] = new List<int>();
            }

            this.levelPersistentFeathList = new List<int>(this.persistentFeathList[levelID]);
            this.tempFeathList.Clear();
        }
        this.levelID = levelID;
        this.isAlive = true;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

        if(this.checkpoint != null)
        {
            Debug.Log("Wtf");
            GameObject player = GameObject.Find("Player");
            if(player != null)
            {
                Debug.Log("Shoppa");
                player.transform.position = (Vector3)this.checkpoint; // We need to wait till Scene is loaded, I think
            }
        }

        this.checkpoint = null;
    }

    public void FeatherAllwoedToExist(GameObject feather, int featherId)
    {
        if(this.levelPersistentFeathList.Contains(featherId))
        {
            GameObject.Destroy(feather);
        }
    }

    public void CollectFeather(int featherId)
    {
        this.tempFeathList.Add(featherId);
    }

    public void CheckpointReached(Vector3 checkpoint)
    {
        foreach(int featherId in this.tempFeathList)
        {
            this.levelPersistentFeathList.Add(featherId);
        }
        this.tempFeathList.Clear();
        //Set Checkpint Cords

        this.checkpoint = checkpoint;
    }

    public void LevelEndReached()
    {
        foreach(int featherId in this.tempFeathList)
        {
            if(this.levelPersistentFeathList.Contains(featherId) == false)
            {
                this.levelPersistentFeathList.Add(featherId);
            }   
        }
        
        foreach(int featherId in this.levelPersistentFeathList)
        {
            if(this.persistentFeathList[this.levelID].Contains(featherId) == false)
            {
                this.persistentFeathList[this.levelID].Add(featherId);
            }
        }

        this.tempFeathList.Clear();
        this.levelPersistentFeathList.Clear();
    }

    public int GetFeatherCountCurrentLevel()
    {
        return this.tempFeathList.Count + this.levelPersistentFeathList.Count;
    }

    public void LoadHub()
    {
        this.LoadScene("Hub");
    }

    public void ResetGame()
    {
        this.persistentFeathList.Clear();
        this.LoadScene("Hub");
    }

    private void LoadLevel1()
    {
        this.LoadScene("GameScene", 1);
    }

    private void LoadLevel2()
    {
        this.LoadScene("Level2", 2);
    }

    public int getPesistentFeatherCount()
    {
        int sum = 0;
        foreach (var feathers in this.persistentFeathList)
        {
            sum += feathers.Value.Count;
        }

        return sum;
    }

    public void LoadMainMenu()
    {
        this.LoadScene("StartScene");
    }

    public void LoadLevel(int level)
    {
        switch(level)
        {
            case 1:
                this.LoadLevel1();
                break;

            case 2:
                this.LoadLevel2();
                break;

            case 999:
                this.LoadMainMenu();
                break;

            default:
                throw new System.Exception("This Level does not Exsist");
        }
            
    }
}
