using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPoint : MonoBehaviour
{
    public int index = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (index == 0) {
                QuestManager.instance.OnSecondCheckpointReached();
            }
            if (index == 1)
            {
                QuestManager.instance.OnThirdCheckpointReached();
            }
            if (index == 2)
            {
                 QuestManager.instance.OnFourCheckpointReached();
            }
            if (index == 3)
            {
                UIManager.Instance.FinalPanel();
            }


            Destroy(gameObject);
            
        }
    }
}
