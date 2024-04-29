using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PageFlipping : MonoBehaviour
{
    public GameObject[] pages; // Reference to the page GameObject
    public int currentPage = 0; // Current page number
    // Start is called before the first frame update
    public LevelLoader levelLoader;
    public int nextSceneIndex;

    void Start()
    {

        levelLoader = FindAnyObjectByType<LevelLoader>();
        // Set the first page to be active
        pages[0].SetActive(true);
        // Set all other pages to be inactive
        for (int i = 1; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        // on right arrow press, flip the page to the right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // If the current page is not the last page
            if (currentPage < pages.Length - 1)
            {
                // Set the current page to be inactive
                pages[currentPage].SetActive(false);
                // Set the next page to be active
                pages[currentPage + 1].SetActive(true);
                // Increment the current page number
                currentPage++;
            }
            else if (currentPage == pages.Length - 1)
            {
                // load the next scene
                levelLoader.LoadLevelByIndex(nextSceneIndex);
            }
        }
        // on left arrow press, flip the page to the left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // If the current page is not the first page
            if (currentPage > 0)
            {
                // Set the current page to be inactive
                pages[currentPage].SetActive(false);
                // Set the previous page to be active
                pages[currentPage - 1].SetActive(true);
                // Decrement the current page number
                currentPage--;
            }
        }
        
    }

    public void NextPage()
    {
        // If the current page is not the last page
        if (currentPage < pages.Length - 1)
        {
            // Set the current page to be inactive
            pages[currentPage].SetActive(false);
            // Set the next page to be active
            pages[currentPage + 1].SetActive(true);
            // Increment the current page number
            currentPage++;
        }
        else if (currentPage == pages.Length - 1)
        {
            // load the next scene
            levelLoader.LoadLevelByIndex(nextSceneIndex);
        }
    }
    public void PreviousPage()
    {
        // If the current page is not the first page
        if (currentPage > 0)
        {
            // Set the current page to be inactive
            pages[currentPage].SetActive(false);
            // Set the previous page to be active
            pages[currentPage - 1].SetActive(true);
            // Decrement the current page number
            currentPage--;
        }

    }
}
