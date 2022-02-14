using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ShowTrackablesOnEnable : MonoBehaviour
{
    [SerializeField] ARSessionOrigin sessionOrigin;
    ARPlaneManager planeManager;
    ARPointCloudManager cloudManager;
    bool isStarted;

    void Awake()
    {
        planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
        cloudManager = sessionOrigin.GetComponent<ARPointCloudManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = true;
    }


    void OnEnable()
    {
        ShowTrackables(true);
    }

    void OnDisable()
    {
        if (isStarted)
        {
            ShowTrackables(false);
        }

    }

    void ShowTrackables(bool show)
    {
        if (show)
        {
            Debug.Log("BUG Show True");
        }
        else
        {
            Debug.Log("BUG Show False");
        }

        if (cloudManager)
        {
            
            cloudManager.SetTrackablesActive(show);
            cloudManager.enabled = show;
            Debug.Log("Zack");
        }
        if (planeManager)
        {

            planeManager.SetTrackablesActive(show);
            planeManager.enabled = show;
            Debug.Log("Di Flack");
        }
    }
}
