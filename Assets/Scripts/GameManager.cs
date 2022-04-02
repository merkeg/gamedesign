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
        this.isAlive = true;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayerDeath()
    {
        this.isAlive = false;
        tempFeathList.Clear();
        SceneManager.LoadScene("LooseScene", LoadSceneMode.Single);
    }

    public void LoadScene(string sceneName, int levelID = -1)
    {
        if(levelID > 0 && levelID != this.levelID)
        {
            if(this.persistentFeathList.ContainsKey(levelID) == false)
            {
                this.persistentFeathList[levelID] = new List<int>();
            }

            this.levelPersistentFeathList = this.persistentFeathList[levelID];
            this.tempFeathList.Clear();
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

    public void CollectFeather(int featherId)
    {
        this.tempFeathList.Add(featherId);
    }

    public void CheckpointReached()
    {
        foreach(int featherId in this.tempFeathList)
        {
            this.levelPersistentFeathList.Add(featherId);
        }

        //Set Checkpint Cords
    }

    public void LevelEndReached()
    {
        foreach(int featherId in this.tempFeathList)
        {
            this.levelPersistentFeathList.Add(featherId);
        }
        
        foreach(int featherId in this.levelPersistentFeathList)
        {
            this.persistentFeathList[this.levelID].Add(featherId);
        }
    }

    public int GetFeatherCountCurrentLevel()
    {
        return this.tempFeathList.Count;
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

    public void LoadLevel1()
    {
        this.LoadScene("GameScene", 1);
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
}
