using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public void Reset()
    {
        AbstractResetable[] restables = FindObjectsOfType<AbstractResetable>();
        foreach (AbstractResetable item in restables)
        {
			print(item.name);
            item.Reset();
        }
    }
}
