using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManagerScript : MonoBehaviour
{
    public float separationRadius = 1f;
    public float separationMoveFactor = .5f;

    // Currently usused. tried to see if I could
    // influence mobs to go another direction when stuck out of range
    public float separationSlipFactor = .5f;
}
