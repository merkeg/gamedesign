using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretEndingToggle : MonoBehaviour
{
    public GameObject Collision;
    public GameObject SecCollision;
    public GameObject SecFoil;
    public GameObject SecFolilNoLight;
    public GameObject SecLight;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.getPesistentFeatherCount() >= 15)
        {
            Collision.SetActive(false);
            SecCollision.SetActive(true);
            SecFoil.SetActive(true);
            SecFolilNoLight.SetActive(true);
            SecLight.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
