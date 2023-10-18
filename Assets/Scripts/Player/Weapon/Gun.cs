using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Gun : MonoBehaviour
{
    [SerializeField] private ParticleSystem ShootingSystem;

    [SerializeField] private Transform[] BulletSpawnPoint;

    [SerializeField] private Bullet bulletPrefabs;

    AudioSource m_shootingSound;

    private Animator Animator;

    [SerializeField] private float rate;
    float time;
    float spaceTime;

    public void Awake()
    {
        Animator = GetComponent<Animator>();
    }


    public void OnInit()
    {
        time = 0;
        spaceTime = 1 / rate;
    }
    private void Start()
    {
        m_shootingSound = GetComponent<AudioSource>();
    }

    public void OnAttack()
    {
        time += Time.deltaTime;

        if(time >= spaceTime)
        {
            time -= spaceTime;
            Shoot();
        }
    }

    public void Shoot()
    {
        for (int i = 0; i < BulletSpawnPoint.Length; i++) 
        {
            m_shootingSound.Play();

            //GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            //if (pooledProjectile != null)
            //{
            //    pooledProjectile.transform.position = BulletSpawnPoint[i].position;
            //    pooledProjectile.transform.rotation = BulletSpawnPoint[i].rotation;
            //    pooledProjectile.SetActive(true);
            //}

            PoolManager.Spawn(bulletPrefabs.gameObject, BulletSpawnPoint[i].position, BulletSpawnPoint[i].rotation);

            //Instantiate(bulletPrefabs, BulletSpawnPoint[i].position, BulletSpawnPoint[i].rotation);

            Animator.SetBool("IsShooting", true);
            ShootingSystem.Play();         
        }
    }

    public void StopShooting()
    {
        Animator.SetBool("IsShooting", false);
    }
}
