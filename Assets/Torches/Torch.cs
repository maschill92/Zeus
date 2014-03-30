﻿using UnityEngine;
using System.Collections;

public class Torch : Activatable {
	private Light[] lights;
	private ParticleSystem flames;
	public int row;
	public int column;
	private bool isActive = true;
	private LightsOn puzzleManager;

	public bool Active
	{
		get { return isActive; }
	}

	void Awake ()
	{
		//print (row +  ", " + column);
		lights = gameObject.GetComponentsInChildren<Light>();
		flames = gameObject.GetComponentInChildren<ParticleSystem>();
		if ((row == 0 || row == 2) || (column == 0 || column == 2))
		{
			lights[0].enabled = false;
			lights[1].enabled = false;
			lights[2].enabled = false;
			flames.Pause();
			flames.Clear();
			isActive = false;
		}

		puzzleManager = GameObject.FindObjectOfType<LightsOn>();
	}
	
	public override void Deactivate()
	{
		isActive = false;
		lights[0].enabled = false;
		lights[1].enabled = false;
		lights[2].enabled = false;
		flames.Pause();
		flames.Clear();
		puzzleManager.TorchToggled(row, column);
	}

	public override void Activate()
	{
		isActive = true;
		lights[0].enabled = true;
		lights[1].enabled = true;
		flames.Play();
		puzzleManager.TorchToggled(row, column);
	}

	public void Toggle()
	{
		if (isActive)
		{
			Deactivate();
		}
		else 
		{
			Activate();
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			Activate();
		}
		else if (Input.GetKeyDown(KeyCode.K))
		{
			Deactivate();
		}
	}
}