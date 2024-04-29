using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyWayOutCollision : MonoBehaviour
{
    PathManager pathManager;
    LevelLoader levelLoader;

    public int passedTestLevelIndex;
    public int failedTestLevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindAnyObjectByType<LevelLoader>();
        pathManager = GameObject.Find("PathManager").GetComponent<PathManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Player" && pathManager.passedTest)
        {
            pathManager.didSteal = true;
            levelLoader.LoadLevelByIndex(passedTestLevelIndex);
        }
        else if (collision.gameObject.tag == "Player" && !pathManager.passedTest)
        {
            pathManager.didSteal = true;
            levelLoader.LoadLevelByIndex(failedTestLevelIndex);
        }

    }
}
