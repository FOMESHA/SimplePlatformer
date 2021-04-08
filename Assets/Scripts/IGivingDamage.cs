using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGivingDamage
{
    interface GivingDamage
    {
        void GiveDamage(Collider2D collision);
    }
}
