using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public GameObject bullet;
    public Transform tf_bullet;

    public GameObject enemy;
    public Transform tf_enemy;

    private void Awake()
    {
        PoolManager.Preload(bullet, 30, tf_bullet);

        PoolManager.Preload(enemy, 20, tf_enemy);
    }
}
