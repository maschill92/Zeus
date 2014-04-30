using UnityEngine;
using System.Collections;

public class CrushingWall : Activatable {

    public float totalDistanceToMove = 3.125f;
    public float speed = -0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }

    public override void Deactivate()
    {
        throw new System.NotImplementedException();
    }
}
