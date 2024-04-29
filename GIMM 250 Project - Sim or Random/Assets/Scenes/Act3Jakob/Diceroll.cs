using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diceroll : MonoBehaviour
{
    public TMPro.TextMeshProUGUI diceRollText;
    private LevelLoader levelLoader;
    private PathManager pathManager;
    public int[] nextSceneIndexes;

    // Start is called before the first frame update
    void Start()
    {
        pathManager = FindAnyObjectByType<PathManager>();
        levelLoader = FindAnyObjectByType<LevelLoader>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this method creates a random number between 1 and 6, and then loads the corresponding scene
    public void RollDice()
    {
        // generate a random number of either 1 or 2
        int diceRoll = Random.Range(1, 3);
        if (diceRoll == 1)
        {
            pathManager.isPromoted = true;
            diceRollText.text = "Lucky roll, you had good work performance!";
            StartCoroutine(LoadNextScene());

        }
        else if (diceRoll == 2)
        {
            pathManager.isPromoted = false;
            diceRollText.text = "Unlucky roll, you had bad work performance!";
            StartCoroutine(LoadNextScene());

        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2);
        if (pathManager.isPromoted && !pathManager.didSteal && pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[0]);
        }
        else if (!pathManager.isPromoted && !pathManager.didSteal && pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[1]);
        }
        else if (pathManager.isPromoted && pathManager.didSteal && pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[2]);
        }
        else if (!pathManager.isPromoted && pathManager.didSteal && pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[3]);
        }
        else if (pathManager.isPromoted && !pathManager.didSteal && !pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[4]);
        }
        else if (!pathManager.isPromoted && !pathManager.didSteal && !pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[5]);
        }
        else if (pathManager.isPromoted && pathManager.didSteal && !pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[6]);
        }
        else if (!pathManager.isPromoted && pathManager.didSteal && !pathManager.passedTest)
        {
            levelLoader.LoadLevelByIndex(nextSceneIndexes[7]);
        }
    }
}
