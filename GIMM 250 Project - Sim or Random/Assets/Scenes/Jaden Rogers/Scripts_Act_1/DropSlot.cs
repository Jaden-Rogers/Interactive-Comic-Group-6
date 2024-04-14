using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{

    public bool emptySlot = true;
    public int indexSlotNumber;
    public bool isHolsterSlot;
    public bool isAnswerSlot;
    private Item item;


    public void Start()
    {
        item = GetComponentInChildren<Item>();

    }

    public void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {

            GameObject dropped = eventData.pointerDrag;
            item = dropped.GetComponent<Item>();
            DraggableObject draggedItem = dropped.GetComponent<DraggableObject>();

            draggedItem.parentAfterDrag = transform;

        }
            emptySlot = false;
    }


}

