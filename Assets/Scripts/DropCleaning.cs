using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCleaning : MonoBehaviour,IDropHandler,IPointerExitHandler,IPointerEnterHandler {

    private GameObject broom;
    private BroomManager BroomManager;

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
        Debug.Log("Droped");
        DragCleaning d = eventData.pointerDrag.GetComponent<DragCleaning>();

        d.parentToReturnTo = d.parentToReturnTo.transform;

        broom.SetActive(true);
        broom.transform.position = this.transform.position;
        BroomManager.Clean();

        Invoke("DestroyTrash", 2f);

    }
	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
        if (eventData.pointerDrag == null)
            return;

        DragCleaning d = eventData.pointerDrag.GetComponent<DragCleaning>();
        if (d != null && d.placeholderParent == this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }

    }

    #endregion

    #region IPointerEnterHandler implementation

    public void OnPointerEnter (PointerEventData eventData)
	{
       // Debug.Log("Enter");

        if (eventData.pointerDrag == null)
            return;

        DragCleaning d = eventData.pointerDrag.GetComponent<DragCleaning>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }

        
    }

	#endregion

	// Use this for initialization
	void Start () {
        //broom.SetActive(false);
        broom = GameObject.Find("JapanBroom");
        BroomManager = broom.GetComponent<BroomManager>();

    }
	
	// Update is called once per frame
	void Update () {
   
    }

    void DestroyTrash()
    {
        Destroy(transform.parent.gameObject);
    }
}
