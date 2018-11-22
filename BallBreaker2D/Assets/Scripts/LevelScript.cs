using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

    [SerializeField] int totalBlocksBroken;
    // Use this for initialization
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CheckBreakableBlocks(){
        totalBlocksBroken++;
    }

    public void BlockDestroyed()
    {
        totalBlocksBroken--;
        if(totalBlocksBroken <= 0){
            sceneLoader.LoadNextScene();
        }
    }

}
