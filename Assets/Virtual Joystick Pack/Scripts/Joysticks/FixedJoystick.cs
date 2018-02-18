using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixedJoystick : Joystick
{
    [Header("Fixed Joystick")]
    
	public UnityStandardAssets.Vehicles.Car.CarController m_Car; // the car controller we want to use

    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();

	private float h,v;


    void Start()
    {
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;

//		float h = CrossPlatformInputManager.GetAxis("Horizontal");
//		float v = CrossPlatformInputManager.GetAxis("Vertical");
		v = direction.y;
		h = direction.x;
		m_Car.Move(h, v, v, 0f);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
		v = 0;
		h = 0;
    }


	private void Update()
	{
//		Debug.Log ("update h:" + h+ ", v: "+v);
		m_Car.Move(h,v,v, 0.0f);
	}
}