using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger : " + other);
        RubyController ctrl = other.GetComponent<RubyController>();
        if (ctrl != null)
        {
            if (ctrl.health < ctrl.maxHealth) {
                ctrl.ChangeHealth(1);
                ctrl.PlayEffect();
                ctrl.PlaySound(collectedClip);
                Destroy(gameObject,1f);
            }
        }
    }
}
