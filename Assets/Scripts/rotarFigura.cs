using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotarFigura : MonoBehaviour
{
    float mouseInitialYPosition = -1f;
    float mousePositionXPrevFrame, mousePositionYPrevFrame;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float scaleSpeed = 1f;
    void Update(){
        if(Input.touchCount == 2){
            Touch dedo1 = Input.GetTouch(0);
            Touch dedo2 = Input.GetTouch(1);

            Vector2 dedo1PrevPosition = dedo1.position - dedo1.deltaPosition;
            Vector2 dedo2PrevPosition = dedo2.position - dedo2.deltaPosition;

            float tochPrevPosDifference = (dedo1PrevPosition - dedo2PrevPosition).magnitude;
            float tochCurPosDifference = (dedo1.position - dedo2.position).magnitude;

            float zoom = (dedo1.deltaPosition - dedo2.deltaPosition).magnitude * scaleSpeed;
            if(tochPrevPosDifference < tochCurPosDifference){
                gameObject.transform.localScale += new Vector3(zoom, zoom, zoom);
            }else if(tochPrevPosDifference > tochCurPosDifference){
                if(gameObject.transform.localScale.x > 0.2f){
                    gameObject.transform.localScale -= new Vector3(zoom, zoom, zoom);
                }else{
                    gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
            }
        }else if(Input.GetMouseButton(0)){
            if(mouseInitialYPosition == -1f){
                mouseInitialYPosition = Input.mousePosition.y;
                mousePositionXPrevFrame = Input.mousePosition.x;
                mousePositionYPrevFrame = Input.mousePosition.y;
            }

            float deltaMousePositionX = mousePositionXPrevFrame - Input.mousePosition.x;
            float deltaMousePositionY = Input.mousePosition.y - mousePositionYPrevFrame;
            gameObject.transform.Rotate(deltaMousePositionY*rotationSpeed, deltaMousePositionX*rotationSpeed, 0, Space.World);

            mousePositionXPrevFrame = Input.mousePosition.x;
            mousePositionYPrevFrame = Input.mousePosition.y;
        }else if (Input.GetMouseButton(1)){
            if(mouseInitialYPosition == -1f){
                mouseInitialYPosition = Input.mousePosition.y;
                mousePositionXPrevFrame = Input.mousePosition.x;
                mousePositionYPrevFrame = Input.mousePosition.y;
            }
            float deltaMousePositionY = Input.mousePosition.y - mousePositionYPrevFrame;
            if(deltaMousePositionY < 0){
                if(gameObject.transform.localScale.x > 0.2f){
                    gameObject.transform.localScale += new Vector3(deltaMousePositionY*scaleSpeed, deltaMousePositionY*scaleSpeed, deltaMousePositionY*scaleSpeed);
                }else{
                    gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
            }else{
                gameObject.transform.localScale += new Vector3(deltaMousePositionY*scaleSpeed, deltaMousePositionY*scaleSpeed, deltaMousePositionY*scaleSpeed);
            }
            mousePositionYPrevFrame = Input.mousePosition.y;
        }else{
            mouseInitialYPosition = -1f;
        }
    }
}
