using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public List<NpcController> npcControllers; // Список ссылок на NpcController для каждого NPC
    public List<GameObject> checkpointsList;
    public List<GameObject> npcObjects;
    public bool[] questCompleted;
    public Text moneyTxt;
    public GameObject housePoint, bankPoint, finalPoint;

    [SerializeField] private int money, moneyFactor = 0;
    private void Start()
    {
        finalPoint.SetActive(false);
        StartSettings();
        instance = this;
        questCompleted = new bool[7];
    }

    void StartSettings()
    {
        housePoint.SetActive(false);
        bankPoint.SetActive(false);
        ControlBackward(1, false);
        ActivateCheckpoints(checkpointsList, false);
        ActivateNpcObject(npcObjects, 0, false);
        ActivateNpcObject(npcObjects, 1, false);
        ActivateNpcObject(npcObjects, 2, false);
        ActivateNpcObject(npcObjects, 3, false);
        ActivateNpcObject(npcObjects, 4, false);
    }

    public void StartQuest(int npcIndex)
    {
        switch (npcIndex)
        {
            case 0:
                ControlBackward(npcIndex, false);
                ActivateNpcObject(npcObjects, 0, true);
                return;
            case 1:
                SecondQuest();
                ActivateCheckpoints(checkpointsList, true);
                return;
            case 2:
                ControlBackward(npcIndex, false);
                ActivateNpcObject(npcObjects, 2, true);
                return;
            case 3:
                ThirdQuest();
                housePoint.SetActive(true);
                return;
            case 4:
                ControlBackward(npcIndex, false);
                ActivateNpcObject(npcObjects, 4, true);
                return;
            case 5:
                FourQuest();
                bankPoint.SetActive(true);
                return;
            default:
                print("error");
                return;
        
        }

            
    }

    void Update()
    {
        moneyTxt.text = money.ToString();
    }
 
    public void ControlBackward(int npcIndex, bool inScene)
    {
        if (npcIndex >= 0 && npcIndex < npcControllers.Count)
        {
            npcControllers[npcIndex].BackWardController(inScene);
        }
        else
        {
            Debug.LogWarning("NPC с индексом " + npcIndex + " не найден!");
        }
    }

    void ThirdQuest()
    {
        money += 750000;
        ControlBackward(3, false);
    }

    void FourQuest() {
        money += moneyFactor;
        ControlBackward(4, false);
    }

    void SecondQuest()
    {
        money += moneyFactor;
        ControlBackward(1, false); // Скрываем backward у второго NPC
    }

    public void ActivateCheckpoints(List<GameObject> checkpoints, bool activate)
    {
        foreach (GameObject checkpoint in checkpoints)
        {
            checkpoint.SetActive(activate);
        }
    }

    public void ActivateNpcObject(List<GameObject> npcObjects, int objectIndex, bool activate)
    {
        if (objectIndex >= 0 && objectIndex < npcObjects.Count)
        {
            npcObjects[objectIndex].SetActive(activate);
        }
        else
        {
            Debug.LogWarning("Индекс объекта NPC выходит за пределы списка!");
        }
    }

    public int reachedSecondCheckpointCount = 0;

    public void OnSecondCheckpointReached()
    {
        reachedSecondCheckpointCount++;
        UIManager.Instance.PlaySounds(2);
            money -= 300;
        if (reachedSecondCheckpointCount == checkpointsList.Count)
        {
            CompleteSecondQuest();
        }
    }

    public int reachedThirdCheckpointCount = 0;

    public void OnThirdCheckpointReached()
    {
        reachedThirdCheckpointCount++;
        UIManager.Instance.PlaySounds(2);
        money -= 750000;
        if (reachedThirdCheckpointCount == 1)
        {
            CompleteThirthQuest();
        }
    }

    public void OnFourCheckpointReached()
    {
        UIManager.Instance.PlaySounds(2);
        money += 140;
        CompleteFiveQuest();
    }



    public void CompleteSecondQuest()
    {
        ControlBackward(1, true); // Возвращаем backward у второго NPC
        questCompleted[1] = true;
        questCompleted[0] = true;
        ActivateNpcObject(npcObjects, 1, true);
    }

    public void CompleteThirthQuest()
    {
        ControlBackward(3, true); // Возвращаем backward у 4 NPC
        questCompleted[2] = true;
        questCompleted[3] = true;
        ActivateNpcObject(npcObjects, 3, true);
    }

    public void CompleteFiveQuest()
    {
        ControlBackward(5, true); // Возвращаем backward у 4 NPC
        questCompleted[4] = true;
        questCompleted[5] = true;
        finalPoint.SetActive(true);
    }

}
