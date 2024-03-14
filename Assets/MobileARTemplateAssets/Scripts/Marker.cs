using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Marker : MonoBehaviour
{
    public GameObject buildingPrefab;
    MeshRenderer meshRenderer;
    SphereCollider sphereCollider;
    TextMeshPro buildingName;
    public BoxCollider buildingCollider;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        sphereCollider = GetComponent<SphereCollider>();
        buildingPrefab.SetActive(false);
        buildingName = GetComponentInChildren<TextMeshPro>();
        buildingCollider.enabled = false;
    }
    private void OnMouseDown()
    {
        // Создаем здание при нажатии на метку
        SpawnBuilding();

        // Скрываем сферу
       
    }

    public void EnableMarker()
    {
        meshRenderer.enabled = true;
        sphereCollider.enabled = true;
        buildingName.enabled = true;
    }


    private void SpawnBuilding()
    {
        // Создаем здание и прикрепляем его к метке
        buildingPrefab.SetActive(true);
        buildingCollider.enabled = true;
        meshRenderer.enabled = false;
        sphereCollider.enabled = false;
        buildingName.enabled = false;
    }
    
}
