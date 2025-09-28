using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string zoneID;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        DraggableText dt = eventData.pointerDrag.GetComponent<DraggableText>();
        if (dt != null)
        {
            DialogueManager.Instance.HandleDrag(dt.characterID, zoneID, eventData.pointerDrag.gameObject);
        }
    }
}
