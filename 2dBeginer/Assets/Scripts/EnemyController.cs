using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Animator animator;

    float timer;
    int direction = 1;

    bool broken=true;

    public ParticleSystem smokeEffect;
    public ParticleSystem hitEffect;

    public AudioClip fixedSound;
    public AudioClip walkSound;

    AudioSource audioSound;
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSound = GetComponent<AudioSource>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;
        }
        //实现来回走
        timer -= Time.deltaTime;
        if (timer < 0) {
            direction = -direction;
            timer = changeTime;
        }
    }
    private void FixedUpdate()
    {
        if (!broken)
        {
            return;
        }
        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
          
            position.y = position.y + speed * Time.fixedDeltaTime * direction;
        }
        else {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x = position.x + speed * Time.fixedDeltaTime * direction;
        }
        
        rigidbody2D.MovePosition(position);
        if (!audioSound.isPlaying) {
            audioSound.PlayOneShot(walkSound);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
        audioSound.PlayOneShot(fixedSound);
        hitEffect.Play();
    }
}
