﻿using UnityEngine;
using System.Collections;

public abstract class Activatable : AbstractResetable {

	public abstract void Activate();
	public abstract void Deactivate();
}
