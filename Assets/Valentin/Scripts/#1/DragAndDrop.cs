using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image image;
    public static GameObject itemDragging;

    public Vector3 startPosition;
    Transform startParent;
    Transform dragParent;

    private AudioSource audioSource;
    [SerializeField] private AudioClip SFX_PickedObject;
    [SerializeField] private AudioClip SFX_Error;


    void Start()
    {
        image = GetComponent<Image>();

        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;

        audioSource = GetComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 170);

        itemDragging = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        transform.SetParent(dragParent);

        audioSource.PlayOneShot(SFX_PickedObject);
        Debug.Log("Reproducir sonido de objeto recogido");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 255);

        itemDragging = null;
        if (transform.parent == dragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);

            audioSource.PlayOneShot(SFX_Error);
            Debug.Log("Reproducir sonido de error");
        }
    }
}
