using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UsableSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public List<GameObject> allowedItems;

    private AudioSource audioSource;
    [SerializeField] private AudioClip SFX_Correct;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (item != null && item.transform.parent != transform)
            item = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            if (!allowedItems.Contains(item))
            {
                item = DragAndDrop.itemDragging;
                item.transform.position = item.GetComponent<DragAndDrop>().startPosition;

                Debug.Log("Reproducir sonido de error");
            }
            if (allowedItems.Contains(item))
            {
                Debug.Log("deberia destruir");
                Destroy(item);
                item = null;

                audioSource.PlayOneShot(SFX_Correct);
                Debug.Log("reproducir sonido de correcto");
            }
        }
    }
}
