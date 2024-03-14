using UnityEngine;




public class Camera : MonoBehaviour
{
   
    public Transform mainCamera;
    public Transform  cameraPosition;
    float cameraSmooth = 4;
    
    
    void Update()
    {
        if (PlaneController.hasCollided)
            return;
        updateMaincamera();
    }

    void updateMaincamera(){
        mainCamera.position = new Vector3 (cameraPosition.position.x,cameraPosition.position.y,cameraPosition.position.z);
        mainCamera.rotation= Quaternion.Lerp(mainCamera.transform.rotation, cameraPosition.rotation, Time.deltaTime * cameraSmooth * 0.5f);

    }
}
