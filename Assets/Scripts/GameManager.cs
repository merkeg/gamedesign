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

    private List<int> levelSunList = new List<int>();
    private List<int> tempSunList = new List<int>();

    public int levelID = -1;
    public bool isAlive;

    private int LastLevel = -1;

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
        this.persistentFeathList[1] = new List<int>();
        this.persistentFeathList[2] = new List<int>();
        this.persistentFeathList[100] = new List<int>(); //Tut
        Debug.Log(this.persistentFeathList.ContainsKey(1));
    }
    void Start()
    {
        
    }

    public void Restart()
    {
        this.LoadLevel(this.LastLevel);
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

    ///Always call this when player dies since the death scene is specail and should not change the levelID. Becasue checkpoints must be reachable
    public void PlayerDeath()
    {
        this.isAlive = false;
        this.tempFeathList.Clear();
        this.tempSunList.Clear();
        SceneManager.LoadScene("LooseScene", LoadSceneMode.Single);
    }

    private void LoadScene(string sceneName, int levelID = -1, bool resetLevelFeatherListAndCheckPoint = true)
    {
        if(levelID > 0 && resetLevelFeatherListAndCheckPoint && this.levelID != levelID)
        {
            if(this.persistentFeathList.ContainsKey(levelID) == false)
            {
                this.persistentFeathList[levelID] = new List<int>();
            }

            this.levelPersistentFeathList = new List<int>(this.persistentFeathList[levelID]);
            this.tempFeathList.Clear();

            this.levelSunList.Clear();
            this.tempSunList.Clear();

            this.checkpoint = null;
        }
        this.levelID = levelID;
        this.isAlive = true;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void FeatherAllwoedToExist(GameObject feather, int featherId)
    {
        if(this.levelPersistentFeathList.Contains(featherId))
        {
            GameObject.Destroy(feather);
        }
    }

    public void SunAllowedToExist(GameObject sun, int sunId)
    {
        if(this.levelSunList.Contains(sunId))
        {
            GameObject.Destroy(sun);
        }
    }

    public void CollectFeather(int featherId)
    {
        this.tempFeathList.Add(featherId);
    }

    public void CollectSun(int sunId)
    {
        this.tempSunList.Add(sunId);
    }

    public void CheckpointReached(Vector3 checkpoint)
    {
        foreach(int featherId in this.tempFeathList)
        {
            this.levelPersistentFeathList.Add(featherId);
        }
        this.tempFeathList.Clear();

        foreach(int sunId in this.tempSunList)
        {
            this.levelSunList.Add(sunId);
        }
        this.tempSunList.Clear();

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

        this.levelSunList.Clear();
        this.tempSunList.Clear();
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
        this.persistentFeathList[1] = new List<int>();
        this.persistentFeathList[2] = new List<int>();
        this.persistentFeathList[100] = new List<int>(); //Tut
        //this.LoadScene("Hub");
        this.LoadLevelTutorial();
    }

    private void LoadLevel1()
    {
        this.LoadScene("Level1", 1);
        this.LastLevel = 1;
    }

    private void LoadLevel2()
    {
        this.LoadScene("Level2", 2);
        this.LastLevel = 2;
    }

    private void LoadLevelTutorial()
    {
        this.LoadScene("Tutorial", 100);
        this.LastLevel = 100;
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

            case 100:
                this.LoadLevelTutorial();
                break;

            case 999:
                Application.Quit();
                break;

            default:
                throw new System.Exception("This Level does not Exsist");
        }
            
    }

    public Vector3? GetCheckPoint()
    {
        return this.checkpoint;
    }

    public int GetFeatherCountForLevel(int level)
    {
        Debug.Log(level);
        if(this.persistentFeathList.ContainsKey(level))
        {
            Debug.Log(this.persistentFeathList[level].Count);
            return this.persistentFeathList[level].Count;
        }
        Debug.Log(this.persistentFeathList);
        return -1;
    }
}
