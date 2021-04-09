using System.Collections.Generic;
using DilmerGames.Core.Singletons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using SC.XR.Unity.Module_InputSystem;
using SC.XR.Unity.Module_InputSystem.InputDeviceHand;
using SC.XR.Unity.Module_InputSystem.InputDeviceHead;


[RequireComponent(typeof(ARAnchorManager))]
public class ARDrawManager : Singleton<ARDrawManager>
{
    [SerializeField]
    private LineSettings lineSettings = null;

    [SerializeField]
    private UnityEvent OnDraw = null;

    [SerializeField]
    private ARAnchorManager anchorManager = null;

    [SerializeField] 
    private Camera arCamera = null;

    private List<ARAnchor> anchors = new List<ARAnchor>();

    private Dictionary<int, ARLine> Lines = new Dictionary<int, ARLine>();
    private bool CanDraw { get; set; }

    public Transform farPointerCursor;

    private void Start()
    {
        SetDefaultLineColor();
    }

    void Update ()
    {

        //****TRY HERE*****

       // #if !UNITY_EDITOR    
       // DrawOnTouch();
        //#else
        DrawOnMouse();
       // #endif
	}

    public void AllowDraw(bool isAllow)
    {
        CanDraw = isAllow;
    }


    void DrawOnTouch()
    {
        if(!CanDraw) return;

        int tapCount = Input.touchCount > 1 && lineSettings.allowMultiTouch ? Input.touchCount : 1;

        for(int i = 0; i < tapCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            Vector3 touchPosition = arCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, lineSettings.distanceFromCamera));
            
            ARDebugManager.Instance.LogInfo($"{touch.fingerId}");

            if(touch.phase == TouchPhase.Began)
            {
                OnDraw?.Invoke();
                
                ARAnchor anchor = anchorManager.AddAnchor(new Pose(touchPosition, Quaternion.identity));
                if (anchor == null) 
                    Debug.LogError("Error creating reference point");
                else 
                {
                    anchors.Add(anchor);
                    ARDebugManager.Instance.LogInfo($"Anchor created & total of {anchors.Count} anchor(s)");
                }

                ARLine line = new ARLine(lineSettings);
                Lines.Add(touch.fingerId, line);
                line.AddNewLineRenderer(transform, anchor, touchPosition);
            }
            else if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                Lines[touch.fingerId].AddPoint(touchPosition);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                Lines.Remove(touch.fingerId);
            }
        }
    }

    void DrawOnMouse()
    {
        if(!CanDraw) return;

        //check ว่าmouseโดนUIไหม?
        if (IsPointerOverUI(Input.mousePosition))
        {
            return;
        }

        
        Vector3 mousePosition = arCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lineSettings.distanceFromCamera));

        //Vector3 handcursorPosition = arCamera.ScreenToWorldPoint(new Vector3(API_Module_InputSystem_GGT26Dof.GGTLeft.inputDataGGT26Dof.SCPointEventData.HitPointerRelativeRayCasterCamera.x, API_Module_InputSystem_GGT26Dof.GGTLeft.inputDataGGT26Dof.SCPointEventData.HitPointerRelativeRayCasterCamera.y, lineSettings.distanceFromCamera));

        //Vector3 handPosition = new Vector3(API_Module_InputSystem_GGT26Dof.GGTRight.inputDataGGT26Dof.SCPointEventData.Position3D.x, API_Module_InputSystem_GGT26Dof.GGTLeft.inputDataGGT26Dof.SCPointEventData.Position3D.y, lineSettings.distanceFromCamera);

        Vector3 cursorPosition = new Vector3(farPointerCursor.position.x, farPointerCursor.position.y, lineSettings.distanceFromCamera);

        /*if (API_Module_InputSystem_GGT26Dof.IsGGTKeyDown(InputKeyCode.Enter, API_Module_InputSystem_GGT26Dof.GGestureType.Left)){
           
            Debug.Log("Left hand grab pen");

            OnDraw?.Invoke();

            if (Lines.Keys.Count == 0)
            {
                ARLine line = new ARLine(lineSettings);
                Lines.Add(0, line);
                line.AddNewLineRenderer(transform, null, mousePosition);
            }
            else
            {
                Lines[0].AddPoint(mousePosition);
                Debug.Log("Long line");
            }
            API_Module_InputSystem_GGT26Dof.GGTDragTarget

        }

        else if (API_Module_InputSystem_GGT26Dof.IsGGTKeyUp(InputKeyCode.Enter, API_Module_InputSystem_GGT26Dof.GGestureType.Left))
        {
            Debug.Log("Left hand RELEASE");

            Lines.Remove(0);
        }*/

        if (Input.GetMouseButton(0))
        {
            OnDraw?.Invoke();

            if(Lines.Keys.Count == 0)
            {
                ARLine line = new ARLine(lineSettings);
                Lines.Add(0, line);
                line.AddNewLineRenderer(transform, null, mousePosition);
            }
            else 
            {
                Lines[0].AddPoint(mousePosition);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Lines.Remove(0);   
        }
    }

    GameObject[] GetAllLinesInScene()
    {
        return GameObject.FindGameObjectsWithTag("Line");
    }

    public void ClearLines()
    {
        GameObject[] lines = GetAllLinesInScene();
        foreach (GameObject currentLine in lines)
        {
            LineRenderer line = currentLine.GetComponent<LineRenderer>();
            Destroy(currentLine);
        }
    }
    private bool IsPointerOverUI(Vector3 MousePos) //check ว่าmouseโดนUIไหม?
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        //eventData.position = new Vector2(touch.position.x, touch.position.y);

        eventData.position = new Vector2(MousePos.x,MousePos.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    public void SetDefaultLineColor()
    {
        //Set default line color
        lineSettings.startColor = new Color32(207, 61, 95, 255);
        lineSettings.endColor = new Color32(207, 61, 95, 255);
    }
}