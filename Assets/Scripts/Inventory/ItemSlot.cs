using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] Image image;
    [SerializeField] ItemTooltip tooltip;

    public event Action<Items> OnRightClickEvent;

    private Items _item;
    public Items Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.itemIcon;
                image.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Item);
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

        if (tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item is EquippableItems)
        {
            tooltip.ShowToolTip((EquippableItems)Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }
}
