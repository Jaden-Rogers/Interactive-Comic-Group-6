using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    private Item[] item;
    public TextMeshProUGUI numberText;
    public Canvas canvas;
    public GameObject particles;
    public GameObject numberUI;
    public GameObject[] particleSystems;
    public GameObject[] numberUIs;

    public void Start()
    {
        item = FindObjectsOfType<Item>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        particleSystems = GameObject.FindGameObjectsWithTag("ParticleSystem");
        numberUIs = GameObject.FindGameObjectsWithTag("NumberUI");
        transform.tag = transform.parent.tag;
        numberText.alpha = 0;


    }

    private void Update()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        //Debug.Log("OnBeginDrag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        particles.SetActive(false);
        numberUI.SetActive(true);

        foreach (GameObject particle in particleSystems)
        {
            particle.SetActive(false);
        }
        numberText.alpha = 1;



    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;



    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvas.renderMode = RenderMode.WorldSpace;
        transform.SetParent(parentAfterDrag);
        //Debug.Log("OnEndDrag");
        image.raycastTarget = true;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        transform.tag = transform.parent.tag;


        foreach (GameObject particle in particleSystems)
        {
            Debug.Log(particle.transform.parent.tag);
            if (particle.transform.parent.tag == "AnswerSlot")
            {
                particle.SetActive(false);
                
            }
            if (particle.transform.parent.tag == "HolsterSlot")
            {
                particle.SetActive(true);
            }
        }

        Debug.Log(numberUI.transform.parent.tag);
        if (parentAfterDrag.tag == "AnswerSlot")
        {
            numberText.alpha = 1;
        }
        else if (parentAfterDrag.tag == "HolsterSlot")
        {
            numberText.alpha = 0;
        }


    }

}
