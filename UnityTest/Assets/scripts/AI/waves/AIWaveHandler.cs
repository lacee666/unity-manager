using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWaveHandler : MonoBehaviour {

    // Use this for initialization
    private List<GameObject> spawnplaces;
    private List<GameObject> enemies;
    private PlayerResources playerResources;
    private Object skeletonPrefab;
    private WaveUI waveUI;
    private int count = 5;
    public int i = 2;
    private float waveTime;
    public float WaveTime { get { return waveTime; } }

    private bool waveHappening = false;
    public bool WaveHappening { get { return waveHappening; } }
    void Start () {


        playerResources = GameObject.Find("CameraTarget").GetComponent<PlayerResources>();
        enemies = GameObject.Find("AIHolder").GetComponent<AIHolder>().enemies;
        skeletonPrefab = GameObject.Find("BuildingInformation").GetComponent<BuildingInformation>().Find("skeleton").prefab;
        waveUI = GameObject.Find("wave_text").GetComponent<WaveUI>();
        waveTime = 20;

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
                waveTime = 20;
                playerResources.StopMusic();
            }
        }
       
	}

    void StartWave()
    {
        int r = Random.Range(0, 3);
        waveUI.NotifyWaveUI(r);
        SpawnEnemies(spawnplaces[r], count);
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
            Debug.Log("skeleton in");
            GameObject go = Instantiate(skeletonPrefab, place.transform.position, Quaternion.identity) as GameObject;
            enemies.Add(go);
        }
       
    }
}
