using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PrefabCreator : MonoBehaviour
{
    [System.Serializable]
    public struct TowerData
    {
        public GameObject prefab;
        public Vector3 position;
    }

    [SerializeField] private TowerData[] towersData;
    private ARTrackedImageManager arTrackedImageManager;

    private void OnEnable()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            foreach (TowerData towerData in towersData)
            {
                GameObject tower = Instantiate(towerData.prefab, image.transform);
                tower.transform.position += towerData.position;
            }
        }
    }
}



