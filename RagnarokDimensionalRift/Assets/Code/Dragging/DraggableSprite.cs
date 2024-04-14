using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableSprite : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;
    private Transform targetCell;

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        isDragging = false;
        SnapToNearestCell();
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset;
            transform.position = targetPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DropZone"))
        {
            targetCell = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DropZone") && targetCell == collision.transform)
        {
            targetCell = null;
        }
    }

    private void SnapToNearestCell()
    {
        if (targetCell != null)
        {
            transform.position = targetCell.position;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

