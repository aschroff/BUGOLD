using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[System.Serializable]
public class MultiplePrefabDictonary : SerializableDictionaryBase<string, GameObject> { }



public class MultipleMainMode : MonoBehaviour
{
    [SerializeField] MultiplePrefabDictonary multiplePrefabs;
    [SerializeField] ARTrackedImageManager imageManager;

    //private GameObject prefabDisplayed;

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnTrackedImageChanged;
        UIController.ShowUI("Main");
        ///Debug.Log("BUG 11: " + imageManager.trackables.count);
        foreach (ARTrackedImage image in imageManager.trackables)
        {
            InstantiatePrefab(image);
        }
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImageChanged;

    }

    void InstantiatePrefab(ARTrackedImage image)
    {
        string name = image.referenceImage.name.Split('-')[0];
        ///Debug.Log("BUG 7: " + image.referenceImage.name);
        ///Debug.Log("BUG 8: " + name);
        if (image.transform.childCount == 0)
        {
            Debug.Log("BUG 9: " + multiplePrefabs[name]);
            GameObject prefab = Instantiate(multiplePrefabs[name]);
            //prefabDisplayed = prefab;
            prefab.transform.SetParent(image.transform, false);
        }
        else
        {
            Debug.Log("BUG 10: " + "${ name} already instantiated");
        }

    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage newImage in eventArgs.added)
        {
            InstantiatePrefab(newImage);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(imageManager.trackables.count == 0)
        {
            InteractionController.EnableMode("Main");
        }
    }

    
}
