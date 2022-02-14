using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



public class PlaceObjectOnPlane : MonoBehaviour
{
    public GameObject placedPrefab;

    [SerializeField] ARRaycastManager raycaster;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void OnEnable()
    {
        UIController.ShowUI("PlaceObject");
    }

    public void SetplacedPrefab(GameObject prefab)
    {
        placedPrefab = prefab;
    }

    public void OnPlaceObject(InputValue value)
    {
        Vector2 touchPostion = value.Get<Vector2>();
        PlaceObject(touchPostion);
        
    }

    public void PlaceObject(Vector2 touchPosition)
    {
        if (raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            InteractionController.EnableMode("Main");
        }
    }

}
