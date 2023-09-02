using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler, IDropHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnDropHandler = null;
    public Action<PointerEventData> OnPointerEnterHandler = null;
    public Action<PointerEventData> OnPointerExitHandler = null;

	public void OnPointerClick(PointerEventData eventData)
	{
		OnClickHandler?.Invoke(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		OnDragHandler?.Invoke(eventData);
	}

	public void OnDrop(PointerEventData eventData)
	{
		OnDropHandler?.Invoke(eventData);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		OnPointerEnterHandler?.Invoke(eventData);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		OnPointerExitHandler?.Invoke(eventData);
	}
}
