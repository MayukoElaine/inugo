using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCleaning : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler{

    public static GameObject itemBeingDragged;
    private Vector3 startPosition;

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    public Collider coll;

    #region IBeginDragHandler implementation
    public void OnBeginDrag (PointerEventData eventData)
	{
        itemBeingDragged = gameObject;
        startPosition = transform.position;

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
        transform.position = Input.mousePosition;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

    }

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
        itemBeingDragged = null;
        transform.position = startPosition;

        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //RayCastTrash();
    }

    void RayCastTrash()
    {
       // if (Input.GetMouseButtonDown(0))
       // {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0F))
            {
                //transform.position = ray.GetPoint(100.0F);
                Debug.Log(ray);
            }

            
      //  }


    }
}
