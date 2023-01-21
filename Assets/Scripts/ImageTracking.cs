using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Linq;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour, IDataPersistence
{
    [SerializeField]
   private GameObject[] placeablePrefabs;

   private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
   private ARTrackedImageManager trackedImageManager;
   
   //[SerializeField]
   public bool AllInteracted = false;
   //[SerializeField]
   public int TotalExhibits;
   //[SerializeField]
   public int ViewedExhibits;
   
   public Slider slider;
       
   private void Awake()
   {
    trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    TotalExhibits = placeablePrefabs.Length;

    foreach(GameObject prefab in placeablePrefabs)
    {
        GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        newPrefab.SetActive(false);
        newPrefab.name = prefab.name;
        spawnedPrefabs.Add(prefab.name, newPrefab);
    }
   }

    public void LoadData (GameData data){
    this.ViewedExhibits = data.ViewedExhibits;
   }

   public void SaveData(GameData data){
    data.ViewedExhibits =  this.ViewedExhibits;
   }

 

   private void OnEnable()
   {
    trackedImageManager.trackedImagesChanged += ImageChanged;
   
   }

   private void OnDisable()
   {
    trackedImageManager.trackedImagesChanged -= ImageChanged;
   }

   private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
   {
    foreach(ARTrackedImage trackedImage in eventArgs.added)
    {
        UpdateImage(trackedImage);
    }
    foreach(ARTrackedImage trackedImage in eventArgs.updated)
    {
        UpdateImage(trackedImage);
    }
    foreach(ARTrackedImage trackedImage in eventArgs.removed)
    {
        spawnedPrefabs[trackedImage.name].SetActive(false);   
    }
   }

   private void UpdateImage(ARTrackedImage trackedImage)
   {
    string name = trackedImage.referenceImage.name;
    Vector3 position = trackedImage.transform.position;

    GameObject prefab = spawnedPrefabs[name];
    prefab.transform.position = position;
    prefab.SetActive(true);

    foreach(GameObject go in spawnedPrefabs.Values)
    {
        if(go.name != name)
        {
            go.SetActive(false);
        }
    }
   }

   void Update(){
    int TempViewedCount = 0;

    foreach(GameObject exhibit in spawnedPrefabs.Values.ToList())
    {
        Example ExhibitController = exhibit.transform.Find("GameObject").GetComponent<Example>();
        Debug.Log(ExhibitController.InteractedWith);
        if (ExhibitController.InteractedWith){
            TempViewedCount ++;
        }
        // GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        // newPrefab.SetActive(false);
        // newPrefab.name = prefab.name;
        // spawnedPrefabs.Add(prefab.name, newPrefab);
    }
    ViewedExhibits = TempViewedCount;
    if (TotalExhibits == ViewedExhibits){
        AllInteracted = true;
    }

    slider.value= ViewedExhibits;
   }


}
