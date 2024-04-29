using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public bool passedTest;
    public bool didSteal;
    public bool isPromoted;

    // Start is called before the first frame update
    void Start()
    {
        // if there is another instance of the path manager, destroy this one
        if (FindObjectsOfType<PathManager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
}
