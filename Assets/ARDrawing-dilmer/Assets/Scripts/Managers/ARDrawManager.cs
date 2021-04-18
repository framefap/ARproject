using System.Collections.Generic;
using DilmerGames.Core.Singletons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using SC.XR.Unity.Module_InputSystem;



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

    bool IshandGrab=true ;
    public GameObject testobj;

    public GameObject cursorPress;

    public DrawTracking dt;

    public RectTransform drawingReticle;
    Vector3 reticlePosition;


    private void Start()
    {
        SetDefaultLineColor();

    }

    void Update ()
    {
        DrawOnMouse();
        
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

        //*** ตามหัวเรา ไม่ตาม cursor มือ ***
        Vector3 mousePosition = arCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, lineSettings.distanceFromCamera));
        
        //Vector3 handcursorPosition = arCamera.ScreenToWorldPoint(new Vector3(API_Module_InputSystem_GGT26Dof.GGTRight.inputDataGGT26Dof.SCPointEventData.HitPointerRelativeRayCasterCamera.x, API_Module_InputSystem_GGT26Dof.GGTRight.inputDataGGT26Dof.SCPointEventData.HitPointerRelativeRayCasterCamera.y, lineSettings.distanceFromCamera));
        
       // Vector3 handPosition = arCamera.ScreenToWorldPoint(new Vector3(API_Module_InputSystem_GGT26Dof.GGTRight.inputDataGGT26Dof.SCPointEventData.Position3D.x, API_Module_InputSystem_GGT26Dof.GGTRight.inputDataGGT26Dof.SCPointEventData.Position3D.y, lineSettings.distanceFromCamera));
             
       // Vector3 farpointerPosition = arCamera.ScreenToWorldPoint(new Vector3(farPointerCursor.position.x+800, farPointerCursor.position.y+700, lineSettings.distanceFromCamera));

        //*** ตาม DrawingReticle gameobject ***
        reticlePosition = new Vector3(drawingReticle.GetComponent<RectTransform>().localPosition.x, drawingReticle.GetComponent<RectTransform>().localPosition.y, drawingReticle.GetComponent<RectTransform>().localPosition.z);

        //GESTURE
        if (cursorPress.activeSelf)

        {
            IshandGrab = true;
            
        }

        else if (!cursorPress.activeSelf)
        {
            IshandGrab = false;

        }

        /*if (API_Module_InputSystem_GGT26Dof.GGTLeft.inputDataGGT26Dof.inputKeys.GetKeyDown(InputKeyCode.Enter) ||
            API_Module_InputSystem_GGT26Dof.GGTRight.inputDataGGT26Dof.inputKeys.GetKeyDown(InputKeyCode.Enter))

        {
            IshandGrab = true;

            testobj.SetActive(true);
        }


        else if (API_Module_InputSystem_GGT26Dof.IsGGTKeyUp(InputKeyCode.Enter, API_Module_InputSystem_GGT26Dof.GGestureType.Left) ||
            API_Module_InputSystem_GGT26Dof.IsGGTKeyUp(InputKeyCode.Enter, API_Module_InputSystem_GGT26Dof.GGestureType.Right))
        {
            IshandGrab = false;

        }*/

        // Draw Code
        /*if (IshandGrab)
        {

            OnDraw?.Invoke();

            if (Lines.Keys.Count == 0)
            {
                ARLine line = new ARLine(lineSettings);
                Lines.Add(0, line);
                line.AddNewLineRenderer(transform, null, reticlePosition);

                Debug.Log(reticlePosition);
            }
            else
            {
                Lines[0].AddPoint(reticlePosition);
            }
        }

        else
        {

            Lines.Remove(0);
        }*/
        
        /*if (Input.GetMouseButton(0))
        {
            OnDraw?.Invoke();
            Debug.Log("Mouse CLICK");

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
        }*/
    }
    public void DrawOnDrag()
    {
        OnDraw?.Invoke();

        //dt.Isdrawing = true;
        

        if (Lines.Keys.Count == 0)
        {
            ARLine line = new ARLine(lineSettings);
            Lines.Add(0, line);
            line.AddNewLineRenderer(transform, null, reticlePosition);

        }
        else
        {
            Lines[0].AddPoint(reticlePosition);
        }
    }

    public void StopDraw()
    {
        Lines.Remove(0);

        //dt.Isdrawing = false;
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