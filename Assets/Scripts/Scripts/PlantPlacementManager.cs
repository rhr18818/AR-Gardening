using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

using UnityEngine.SceneManagement;


public class PlantPlacementManager : MonoBehaviour
{
   //public GameObject[] flowers;
   public GameObject SpawnableFlower;
   public XROrigin sessionOrigin;
   public ARRaycastManager raycastManager;
   public ARPlaneManager planeManager;
   private List<ARRaycastHit> raycastHits= new List<ARRaycastHit>();

   private List<GameObject> spanedFlowers = new List<GameObject>();

   public bool canSpawn = true;
   private void Update(){
    if(canSpawn && Input.touchCount>0){
        if(Input.GetTouch(0).phase == TouchPhase.Began){
        bool collision =raycastManager.Raycast(Input.mousePosition, raycastHits,TrackableType.PlaneWithinPolygon);
        if(collision && isButtonPressed()== false){
            //GameObject _object =Instantiate(flowers[Random.Range(0,flowers.Length - 1)]);
            GameObject _object =Instantiate(SpawnableFlower);
            _object.transform.position =raycastHits[0].pose.position;
            _object.transform.rotation =raycastHits[0].pose.rotation;

            spanedFlowers.Add(_object);
        }
            // foreach(var plane in planeManager.trackables){
            //     plane.gameObject.SetActive(false);
            // }
            // planeManager.enabled = false;
        }
    }
    
   }
   public bool isButtonPressed(){
    if(EventSystem.current.currentSelectedGameObject?.GetComponent<Button>()==null){
        return false;
    }
    
    else{
        return true;
    }
   }
   public void SwitchFlower(GameObject flower){
    SpawnableFlower = flower;
   }

//    public void DeleteLastFlower()
//     {
//     if (transform.childCount > 0)
//     {
//         GameObject lastFlower = transform.GetChild(transform.childCount - 1).gameObject;
//         Destroy(lastFlower);
//     }
//     }
    public void DeleteLastFlower()
    {
    if (spanedFlowers.Count > 0)
        {
            GameObject lastFlower = spanedFlowers[spanedFlowers.Count-1];
            spanedFlowers.Remove(lastFlower);
            Destroy(lastFlower);

            Debug.Log("Last Flower Delted.");
            
        }
        else
        {
            Debug.Log("No Flower to Delete.");
        }
    }

    public void BackButtonMainScene(){
        SceneManager.LoadSceneAsync(0);
    }


}
