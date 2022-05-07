using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLooser : MonoBehaviour
{
    public float lightLossPerSecond = 0.05f;
    private VignetteInterface vignetteInterface;
    // Start is called before the first frame update
    void Start()
    {
        this.vignetteInterface = FindObjectOfType<VignetteInterface>();
        this.vignetteInterface.AddVignetteValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        vignetteInterface.AddVignetteValue(this.lightLossPerSecond * Time.deltaTime);
        if (vignetteInterface.GetIntensity() >= 1)
        {
            GameManager.Instance.PlayerDeath();
        }
    }
}
