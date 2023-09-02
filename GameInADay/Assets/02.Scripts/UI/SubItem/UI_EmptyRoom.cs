using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_EmptyRoom : UI_Base, IDropHandler
{
    private Image _image;
    public override void Init()
    {
        _image = GetComponent<Image>();
        _image.color = new(0.016f, 0.459f, 0.937f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        var facilityListItem = eventData.pointerDrag.GetComponent<UI_FacilityListItem>();
        if (facilityListItem != null)
        {
            var gameScene = Managers.Scene.CurrentScene.GetComponent<GameScene>();
            var facility = ModelAgencyFacilities.Get(facilityListItem.ID);
            if (gameScene.Pay(facility.Money)) {
                var job = new FacilityPayJob(facility.ID);
                job.OnEnd = () => {
                    if (gameScene.Pay(facility.RentalCost))
                    {
                        Debug.Log("렌탈료 냄");
                    }
                    else
                    {
                        Debug.LogError("렌탈료 못냄!!!");
                    }
                };
                gameScene.Simulator.AddJob(job);
                Debug.Log("배치: " + facility.FacilitiesName);
            }
        }
    }
}
