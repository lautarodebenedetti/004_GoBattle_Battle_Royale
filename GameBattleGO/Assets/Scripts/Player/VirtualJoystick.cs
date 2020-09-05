using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickBackgroundImage;
    private Image joystickImage;
    private Vector3 inputVector;

    private void Start()
    {
        joystickBackgroundImage = GetComponent<Image>();                //take the component where the code is
        joystickImage = transform.GetChild(0).GetComponent<Image>();    //take the child of the component
    }
    
    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackgroundImage.rectTransform, eventData.position, eventData.pressEventCamera, out position))
        {
            animador.moverse(); //Le aviso al animador que al mover el joystick el personaje se mueve!
            //TODO: Nota hay que decirse que se mueva cuando SOLO toque el joystick izquierdo
            position.x = (position.x / joystickBackgroundImage.rectTransform.sizeDelta.x); //radius (from 0 to 1)
            position.y = (position.y / joystickBackgroundImage.rectTransform.sizeDelta.y);
            //tranform the radius, because the radius have negatives less than -2
            inputVector = new Vector3(position.x * 2 + 1, 0, position.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            //Move joystick image
            joystickImage.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (joystickBackgroundImage.rectTransform.sizeDelta.x / 3),
                    inputVector.z * (joystickBackgroundImage.rectTransform.sizeDelta.y / 3));
        }
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
      else
            return Input.GetAxis("Vertical");
    }
}
