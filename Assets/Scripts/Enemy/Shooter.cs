using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Range(0.5f, 4)]
    public float CooldownTime;

    [Range(0.5f, 2)]
    public float DeltaTimeMultiplier = 1;

    public GameObject Bullet;
    public Direction Direction;
    
    private float _cooldown;
    
    void Start()
    {
        _cooldown = CooldownTime;
    }

    void Update()
    {
        _cooldown += Time.deltaTime * DeltaTimeMultiplier;

        if (_cooldown > CooldownTime)
        {
            _cooldown = 0;
            // Do spawn bullet
            GameObject obj = Instantiate(Bullet, transform.position, Quaternion.identity, transform);
            Bullet bullet = obj.GetComponent<Bullet>();
            bullet.Direction = Direction;
        }
    }
}
