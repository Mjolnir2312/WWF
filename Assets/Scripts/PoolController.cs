using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public GameObject bullet;
    public Transform tf_bullet;

    private void Awake()
    {
        PoolManager.Preload(bullet, 30, tf_bullet);
    }
}
