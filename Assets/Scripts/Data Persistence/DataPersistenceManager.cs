using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;


    public static DataPersistenceManager instance { get; private set;}

    private void Awake(){
        if(instance != null){
            Debug.LogError("more than one DPmanager");
        }
        instance = this;

    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame(){
        this.gameData = new GameData();

    }

    public void LoadGame(){
        //TO DO- load some shit
        // if no data, load new game

        this.gameData = dataHandler.Load();

        if (this.gameData == null){
            Debug.Log("no saved data, loading defaults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects){

            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("loaded viewed= " + gameData.ViewedExhibits);


        //To Do- push loaded data to other scripts

    }

    public void SaveGame(){
        // To do- pass data to other scripts
        // To DO- save data to file

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects){

            dataPersistenceObj.SaveData(gameData);
        }
        Debug.Log("saved viewed= " + gameData.ViewedExhibits);

        dataHandler.Save(gameData);


    }

    private void OnApplicationQuit(){
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);

    }


}
