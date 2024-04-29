using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueOnVideoEnd : MonoBehaviour
{
    public float timeToWait = 45;
    public LevelLoader SceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ContinueAfterVideo());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ContinueAfterVideo()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneLoader.LoadNextLevel();
    }

}
