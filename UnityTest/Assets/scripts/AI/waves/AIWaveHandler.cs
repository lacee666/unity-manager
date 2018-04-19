using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaveHandler : MonoBehaviour {


    private List<GameObject> spawnplaces;
    private List<GameObject> enemies;
    private PlayerResources playerResources;
    private Object skeletonPrefab;
    private WaveUI waveUI;
    private int count = 5;
    //current wave
    public int i = 2;
    private float waveTime;
    private float WAVE_TIME = 20;
    public float WaveTime { get { return waveTime; } }

    private static bool waveHappening = false;
    public static bool WaveHappening { get { return waveHappening; } }
    void Start () {


        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        enemies = GameObject.Find("AIHolder").GetComponent<AIHolder>().enemies;
        skeletonPrefab = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>().Find("skeleton").prefab;
        waveUI = GameObject.Find("wave_text").GetComponent<WaveUI>();

        waveTime = WAVE_TIME;

        //these are the 3 places where AI could spawn(east, south and west)
        spawnplaces = new List<GameObject>();
        spawnplaces.Add(GameObject.Find("AIHolder/Wave_Positions/Spawnpoint_West"));
        spawnplaces.Add(GameObject.Find("AIHolder/Wave_Positions/Spawnpoint_East"));
        spawnplaces.Add(GameObject.Find("AIHolder/Wave_Positions/Spawnpoint_South"));
    }

	void Update () {
        if (!waveHappening) 
        {
            waveTime -= Time.deltaTime;
            if (waveTime <= 0.0f)
            {
                waveHappening = true;
                waveTime = 0;
                StartWave();
                playerResources.PlayMusic();
            }
        }else
        {
            if (enemies.Count <= 0)
            {
                waveHappening = false;
                waveTime = WAVE_TIME;
                playerResources.StopMusic();
            }
        }
       
	}

    void StartWave()
    {
        int r = Random.Range(0, 3);
        waveUI.NotifyWaveUI(r);
        SpawnEnemies(spawnplaces[r], count);
        // this function calculates the next wave and i is always i+=1 after the next wave, so it gets harder over time
        count = CalculateCount(i);
        i++;
    }
    
    int CalculateCount(int x)
    {
        return (3*(x * x) / 2);
    }

    void SpawnEnemies(GameObject place, int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(skeletonPrefab, place.transform.position, Quaternion.identity) as GameObject;
            enemies.Add(go);
        }
       
    }
}
