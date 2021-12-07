using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputControll : MonoBehaviour
{

    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;
    private List<RaycastResult> results;

    private TurnPage bookBehaviour; 
    void Start()
    {
        var mainCanvas = GameObject.Find("Canvas");
        m_Raycaster = mainCanvas.GetComponent<GraphicRaycaster>();
        m_EventSystem = mainCanvas.GetComponent<EventSystem>();

        m_PointerEventData = new PointerEventData(m_EventSystem);
        results = new List<RaycastResult>();
        bookBehaviour = mainCanvas.GetComponent<TurnPage>();
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_PointerEventData.position = Input.mousePosition;
            m_Raycaster.Raycast(m_PointerEventData, results);
            if (results.Count > 0)
            {
                switch (results[0].gameObject.name)
                {
                    case "LeftInductionZone":
                        bookBehaviour.PageTurning_Left();
                        break;
                    case "RightInductionZone":
                        bookBehaviour.PageTurning_Right();
                        break;
                    default:
                        break;
                }
                results.Clear();
            }
        }
    }
}
