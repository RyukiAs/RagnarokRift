using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GodSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            Transform parent = this.gameObject.transform.parent;
            Transform holder = parent.Find("HoldActiveGods");
            RectTransform rectTransformHolder = holder.GetComponent<RectTransform>();

            RectTransform draggedRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
            RectTransform holdGod = GetComponent<RectTransform>();
            

            Vector2 offset = new Vector2(
                (rectTransformHolder.rect.width) / 2f,
                (rectTransformHolder.rect.height + 1.5f*draggedRectTransform.rect.height) / -1f
            );
            
            //Debug.Log(offset);

            draggedRectTransform.anchoredPosition = holdGod.anchoredPosition + offset;

            ShowLaborListGods script = eventData.pointerDrag.GetComponent<ShowLaborListGods>();
            if (script != null)
            {
                Debug.Log("Found ShowLaborListGods script");
            }
            God god = script.godPass;
            if (god != null )
            {
                Debug.Log("setting postion to " + holdGod.anchoredPosition);
                god.position = holdGod.anchoredPosition;
            }
            else
            {
                Debug.Log("Cannot Find God in eventData");
            }

        }
    }
}
