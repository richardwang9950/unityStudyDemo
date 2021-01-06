using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    /// <summary>
    /// 调用Instantiate方法时不会调用start   所以要在Awake中调用
    /// </summary>
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //移动100后销毁
        //if (transform.position.magnitude > 100.0f)
        //{
        //    Destroy(gameObject);
        //}
        Destroy(gameObject,3f);
    }

    public void Launch(Vector2 direction,float force) {
        rigidbody2d.AddForce(direction*force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Projectile Collision with" + collision.gameObject);
        EnemyController e = collision.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
