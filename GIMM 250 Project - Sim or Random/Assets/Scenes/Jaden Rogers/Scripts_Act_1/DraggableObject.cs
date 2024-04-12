using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    private Item[] item;


    public void Start()
    {
        item = FindObjectsOfType<Item>();
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



    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        //Debug.Log("OnEndDrag");
        image.raycastTarget = true;

    }

}
