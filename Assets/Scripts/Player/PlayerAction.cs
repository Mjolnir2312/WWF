using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private Gun Gun;

    [SerializeField] public AudioClip GunShoot;

    private void Start()
    {
        Gun?.OnInit();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Gun?.OnAttack();
        }
        else
        {
            Gun?.StopShooting();
        }
    }
}
