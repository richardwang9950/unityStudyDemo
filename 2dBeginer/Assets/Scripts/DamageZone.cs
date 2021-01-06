using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // Start is called before the first frame update
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        RubyController ctrl=collision.gameObject.GetComponent<RubyController>();
        if (ctrl == null) return;
        if (ctrl.health > 0) {
            ctrl.ChangeHealth(-1);
        }
    }
}
