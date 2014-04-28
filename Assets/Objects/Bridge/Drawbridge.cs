using UnityEngine;
using System.Collections;

public class Drawbridge : Activatable {

    public override void Activate()
    {
        GetComponent<Animator>().SetBool("Lower Bridge", true);
    }

    public override void Deactivate()
    {
    }
}
