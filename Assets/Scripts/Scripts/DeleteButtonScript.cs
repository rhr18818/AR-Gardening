using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButtonScript : MonoBehaviour
{
    public PlantPlacementManager plantPlacementManager;

    public void OnDeleteButtonPressed()
    {
        if (plantPlacementManager != null)
        {
        plantPlacementManager.DeleteLastFlower();
        plantPlacementManager.canSpawn = false;
        }
    
        else
        {
            Debug.LogError("PlantPlacementManager is not assigned.");
        }
    }
}
