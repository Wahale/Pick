using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;

    private SpawnItemInSlot spawnItem;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private BoxCollider2D collider2d;
    public  bool youLose;
    private Equals equals;
    private void Awake()
    {
        equals = GameObject.Find("Container").GetComponent<Equals>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        collider2d = GetComponent<BoxCollider2D>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        spawnItem = GameObject.Find("Container").GetComponent<SpawnItemInSlot>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        collider2d.enabled = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        collider2d.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (equals.returnToSpawnPoint)
        {
            gameObject.transform.position = spawnItem.spawnPoints[Random.Range(0, spawnItem.spawnPoints.Length)].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (equals.isLose)
        {
            if (collision.CompareTag("Item") || collision.CompareTag("Player"))
            {
                Debug.Log("youLose");
                equals.buttonRestart.SetActive(true);
            }
        }
    }
}
