using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Virtual joystick for mobile joystick control
/// </summary>
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image touchableSurface;
    private Image backPanel;
    private Image knob;

    public Vector3 InputDirection { get; set; }

    public Vector3 firstInput;

    private bool usingJoystick;

    /// <summary>
    /// Get the joystick UI.
    /// </summary>
    private void Start()
    {
        Debug.Log(gameObject.name);
        touchableSurface = GetComponent<Image>();
        backPanel = transform.GetChild(0).GetComponent<Image>();
        knob = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        usingJoystick = true;
        SetUsingJoystick(false);
    }

    void SetUsingJoystick(bool b)
    {
        if (usingJoystick == b) return;
        usingJoystick = b;
        backPanel.gameObject.SetActive(b);
        //knob.enabled = b;
    }

    private void Update()
    {
        Vector3 temp = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            temp.x = -1;
            SetUsingJoystick(false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            temp.x = 1;
            SetUsingJoystick(false);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            temp.y = -1;
            SetUsingJoystick(false);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            temp.y = 1;
            SetUsingJoystick(false);
        }

        if (!usingJoystick)
        {
            InputDirection = temp;
        }

    }

    /// <summary>
    /// Drag the knob of the joystick.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnDrag(PointerEventData pointerEventData)
    {
        Vector2 position = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (backPanel.rectTransform,
                pointerEventData.position,
                pointerEventData.pressEventCamera,
                out position))
        {
            // Get the touch position
            
            position.x = (position.x / backPanel.rectTransform.sizeDelta.x);
            position.y = (position.y / backPanel.rectTransform.sizeDelta.y);
            if (position.magnitude > 1)
            {
                position = position.normalized;
            }

            // Calculate the move position
            // float x = (backPanel.rectTransform.pivot.x == 1) ?
            //     position.x * 2 + 1 : position.x * 2 - 1;
            // float y = (backPanel.rectTransform.pivot.y == 1) ?
            //     position.y * 2 + 1 : position.y * 2 - 1;

            float x = position.x;
            float y = position.y;

            // Get the input position
            InputDirection = new Vector3(x, y, 0);
            InputDirection = (InputDirection.magnitude > 1) ?
                InputDirection.normalized : InputDirection;
            
            
            // Move the knob
            knob.rectTransform.anchoredPosition =
                new Vector3(InputDirection.x * 50,
                    InputDirection.y * 50);
        }
    }

    /// <summary>
    /// Click on the knob.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnPointerDown(PointerEventData pointerEventData)
    {
        SetUsingJoystick(true);
        Vector2 position = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (touchableSurface.rectTransform,
                pointerEventData.position,
                pointerEventData.pressEventCamera,
                out position))
        {
            firstInput = position;
            backPanel.rectTransform.anchoredPosition = firstInput;
        }
        
        OnDrag(pointerEventData);
    }

    /// <summary>
    /// Click off the knob.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnPointerUp(PointerEventData pointerEventData)
    {
        InputDirection = Vector3.zero;
        knob.rectTransform.anchoredPosition = Vector3.zero;
        SetUsingJoystick(false);
    }
}   