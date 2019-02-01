using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {

    Camera cam;
    public float perspectiveZoomSpeed;
    public float prespectiveScrollSpeed;
    Vector3 camTransform;
    public Vector3 arrowChange;


    private void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();
        arrowChange = new Vector3(0, 10, 0);
    }

    void Update ()
    {
        /*//This is what im going to use to scroll on touch and zoom when pinching the screen.
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            cam.transform.Translate(-touchDeltaPosition.x * prespectiveScrollSpeed, -touchDeltaPosition.y * prespectiveScrollSpeed, 0);
            camTransform = cam.transform.position;
            camTransform.x = Mathf.Clamp(camTransform.x, -125, 125);
            camTransform.y = Mathf.Clamp(camTransform.y, -300, 300);
            cam.transform.position = camTransform;
        }*/

        //If we detect two touches, run this instead.
	    if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Otherwise change the field of view based on the change in distance between the touches.
            cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

            // Clamp the field of view to make sure it's between 150 and 170.
            if (!VarCheck.Instance.applicationFilled)
            {
                cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 150.0f, 170.0f);
            }

        }

        /*//If for some reason, the user is using a keyboard, we can use up and down arrow controls.
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (cam.transform.position.y < 291 && cam.transform.position.y > -290)
            {
                cam.transform.position -= arrowChange;
            }
        } else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (cam.transform.position.y < 290 && cam.transform.position.y > -291)
            {
                cam.transform.position += arrowChange;
            }
        } else {}*/
	}
}
