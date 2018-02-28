using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler,IPointerExitHandler,IPointerEnterHandler {

    public DragHandler.Element typeofelement = DragHandler.Element.Food;

    public DogManager DogManager;
    public Showering showering;

    public GameObject foodplane;
    public GameObject waterplane;

    #region IDropHandler implementation
    public void OnDrop (PointerEventData eventData)
	{
        DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
        if (d.typeofelement == DragHandler.Element.Food)
        {
            Debug.Log("Food Dropped");
            d.parentToReturnTo = d.parentToReturnTo.transform;
            foodplane.SetActive(true);

            if (DogManager.Fullness != 1)
            {
                DogManager.ExperienceToAdd(5);
                
            }
        }

        else if (d.typeofelement == DragHandler.Element.Water)
        {
            Debug.Log("Water Dropped");
            d.parentToReturnTo = d.parentToReturnTo.transform;
            waterplane.SetActive(true);

            if (DogManager.Fullness != 1)
            {
                DogManager.ExperienceToAdd(5);
            }
        }

    }
	#endregion

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
        //Debug.Log("OnPointerEnter");

        if (DragHandler.itemBeingDragged != null)
        {
            DragHandler b = eventData.pointerDrag.GetComponent<DragHandler>();
            
            if (b != null)
            {
                if (b.typeofelement == DragHandler.Element.Shower)
                {
                    showering.GetComponent<Showering>().BubbleSpawn();
                    DogManager.GetComponent<DogManager>().AddHygiene();

                    if (DogManager.Hygiene >= 0.9f && DogManager.Hygiene < 1f)
                    {
                        DogManager.ExperienceToAdd(5);
                    }

                }

                else if (b.typeofelement == DragHandler.Element.Comb)
                {
                    DogManager.GetComponent<DogManager>().AddFun();

                    if (DogManager.Fun >= 0.9f && DogManager.Fun < 1f)
                    {
                        DogManager.ExperienceToAdd(5);
                    }

                }

            }

        }

        if (eventData.pointerDrag == null)
            return;

        DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }


    }

	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
        if (eventData.pointerDrag == null)
            return;

        DragHandler d = eventData.pointerDrag.GetComponent<DragHandler>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }

        //Debug.Log("OnPointerExit");
    }

	#endregion

	// Use this for initialization
	void Start () {

        foodplane.SetActive(false);
        waterplane.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (foodplane.activeInHierarchy & DogManager.Fullness != 1)
        {
            DogManager.GetComponent<DogManager>().MovetoFood();

        }
        else if (waterplane.activeInHierarchy & DogManager.Fullness != 1)
        {
            DogManager.GetComponent<DogManager>().MovetoWater();
        }


    }
}
