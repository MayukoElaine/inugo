using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler  {

	public static GameObject itemBeingDragged;
	private Vector3 startPosition;

    public enum Element { Food , Water , Shower, Comb,Others};
    public Element typeofelement = Element.Food;

    public DogManager DogManager;

    //newly added

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    #region IBeginDragHandler implementation
    public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;

        //Newly added

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
        transform.position = Input.mousePosition;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);


        if (typeofelement == Element.Comb)
        {
            DogManager.GetComponent<DogManager>().ShowFunFillBar();

        }
        else if (typeofelement == Element.Shower)
        {
            DogManager.GetComponent<DogManager>().ShowHygieneFillBar();

        }
    }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		transform.position = startPosition;

        if (typeofelement == Element.Comb)
        {
            DogManager.GetComponent<DogManager>().UnShowFunFillBar();
        }
        else if (typeofelement == Element.Shower)
        {
            DogManager.GetComponent<DogManager>().UnShowHygieneFillBar();
        }


        //newly added

        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //Destroy(placeholder);
    }

	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
