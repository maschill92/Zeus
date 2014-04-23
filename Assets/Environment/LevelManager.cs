using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public void Reset()
    {
        FindObjectOfType<FallingPlatformManager>().Reset();
    }
}
