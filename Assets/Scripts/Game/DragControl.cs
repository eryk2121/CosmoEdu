using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// do produkcji poniższego skryptru użyto dokumentacji Unity https://docs.unity3d.com/ScriptReference/Input.GetTouch.html

public class DragControl : MonoBehaviour
{
    private bool active = false;
    private Vector2 screen;
    private Vector3 world;
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;


    private DragShip ds;

    private void Awake()
    {
        DragControl[] controls = FindObjectsOfType<DragControl>();
        if (controls.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }


    private void Update()
    {
        if (!Ship.freeze)
        {
            if (active && (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
            {
                Drop();
                return;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 pos = Input.mousePosition;
                screen = new Vector2(pos.x, pos.y);
            }
            else if (Input.touchCount > 0)
            {
                screen = Input.GetTouch(0).position;
            }
            else
            {
                return;
            }

           
            world = Camera.main.ScreenToWorldPoint(screen);

            if (active)
            {
                Drag();
            }
            else
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);
                m_PointerEventData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                m_Raycaster.Raycast(m_PointerEventData, results);

                DragShip ds = results[0].gameObject.transform.gameObject.GetComponent<DragShip>();

                if (ds != null)
                {
                    active = true;
                    this.ds = ds;
                    InitDrag();
                }

            }
        }
        void InitDrag()
        {
            active = true;
        }
        void Drag()
        {

            ds.transform.position = Input.GetTouch(0).position;
	    
        }
        void Drop()
        {
            active = false;
        }

    }
}