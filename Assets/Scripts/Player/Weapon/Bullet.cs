using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float damage;

    [SerializeField] BulletData bulletData;

    public Transform tf;

    private Rigidbody rb;

    public LayerMask Mask;

    private void Awake()
    {
        speed = bulletData.speedBullet;
        damage = bulletData.damageBullet;

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //Debug.Log("Position of the bullet: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position += Time.deltaTime * speed * direction;
        rb.velocity = tf.forward * speed;


        //Debug.Log("Position of the bullet: " + transform.position);
        //Debug.Log("Position of the bullet: " + transform.position);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, tf.forward, out hit, 0.5f, Mask))
        {
            HandleCollision(hit.collider);
            Debug.Log("-------Hit--------");
        }
        else
        {
            StartCoroutine(DestroyBulletAfterDelay(2.0f));
        }
        //Debug.Log("Position of the bullet: " + transform.position);
    }

    private void HandleCollision(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.OnTakeDamage(damage);
        }

        //gameObject.SetActive(false);
        PoolManager.Despawn(gameObject);
    }

    private IEnumerator DestroyBulletAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

      
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            PoolManager.Despawn(gameObject);
        }
    }

}
