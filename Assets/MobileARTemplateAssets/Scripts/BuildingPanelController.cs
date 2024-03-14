using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanelController : MonoBehaviour
{
    public Slider sizeSlider;
    public Slider rotationSlider;

    private BuildingController currentBuilding;

    private void OnEnable()
    {
        // Подписываемся на события изменения слайдеров
        sizeSlider.onValueChanged.AddListener(OnSizeSliderChanged);
        rotationSlider.onValueChanged.AddListener(OnRotationSliderChanged);
    }

    private void OnDisable()
    {
        currentBuilding.ResetSize(1);
        // Отписываемся от событий перед отключением панели
        sizeSlider.onValueChanged.RemoveListener(OnSizeSliderChanged);
        rotationSlider.onValueChanged.RemoveListener(OnRotationSliderChanged);

        // Очищаем текущее здание при скрытии панели
        currentBuilding = null;
    }

    public void SetBuilding(BuildingController buildingController)
    {
        currentBuilding = buildingController;
    }

    private void OnSizeSliderChanged(float value)
    {
        // Вызывается при изменении значения слайдера размера
        if (currentBuilding != null)
        {
            currentBuilding.SetSize(value);
        }
    }

    private void OnRotationSliderChanged(float value)
    {
        // Вызывается при изменении значения слайдера ротации
        if (currentBuilding != null)
        {
            currentBuilding.SetRotation(value);
        }
    }
}

