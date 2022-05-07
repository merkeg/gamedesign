using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Load Scene GameScene when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.Restart();
        }
    }
}
