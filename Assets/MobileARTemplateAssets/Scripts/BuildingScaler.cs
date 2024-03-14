using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScaler : MonoBehaviour
{
    [System.Serializable]
    public struct BuildingData
    {
        public GameObject building;
        public float selectedScale;
        public float unselectedScale;
    }

    [SerializeField] private BuildingData[] buildingsData;
    private GameObject selectedBuilding;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SelectBuilding(hit.transform.gameObject);
            }
        }
    }

    private void SelectBuilding(GameObject building)
    {
        // Если выбранное здание уже было выбрано, сбросить выбор
        if (selectedBuilding == building)
        {
            ResetBuildingScales();
            selectedBuilding = null;
        }
        else
        {
            // Сбросить предыдущий выбор, если есть
            ResetBuildingScales();

            // Найти выбранное здание в данных и применить масштабирование
            foreach (BuildingData buildingData in buildingsData)
            {
                if (buildingData.building == building)
                {
                    building.transform.localScale = Vector3.one * buildingData.selectedScale;
                    selectedBuilding = building;
                }
                else
                {
                    building.transform.localScale = Vector3.one * buildingData.unselectedScale;
                }
            }
        }
    }

    private void ResetBuildingScales()
    {
        foreach (BuildingData buildingData in buildingsData)
        {
            buildingData.building.transform.localScale = Vector3.one * buildingData.unselectedScale;
        }
    }
}

