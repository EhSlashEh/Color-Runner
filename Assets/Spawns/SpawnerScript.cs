using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //Things to spawn
    public GameObject Box;
    public GameObject RedBox;
    public GameObject Rail;
    public GameObject Fan;
    public GameObject NeonTrail;

    //Spawn rates
    public float boxSpawnRate; //Set this in unity
    public float railSpawnRate;
    public float fanSpawnRate;
    public float neonTrailSpawnRate;

    //Object Speed
    public float objectSpeed;
    public static float _objectSpeedSet;

    //Set timers to 0
    private float _boxTimer = 0;
    private float _railTimer = 0;
    private float _fanTimer = 0;
    private float _neonTrailTimer = 0;

    //Random number
    private int randomNumber;

    //Waiting to flip
    private bool _railFlipped;
    private bool _fanFlipped;

    //Increase Speed
    //bool _startedIncreaseSpeedCode;

    private void Awake()
    {
        _objectSpeedSet = objectSpeed;
    }
    void Start()
    {
        //Make sure prefabs are right orientation
        Rail.transform.localScale = new Vector3(1, 1, 1);
        _railFlipped = false;
        SpawnRail();

        Fan.transform.localScale = new Vector3(1, 1, 1);
        _fanFlipped = false;
        SpawnFan();
    }

    [System.Obsolete]
    void Update()
    {
        
        //Rail
        if (_railTimer < railSpawnRate)
        {
            _railTimer += Time.deltaTime;
        }
        else
        {
            SpawnRail();
        }

        //Fan
        if (_fanTimer < fanSpawnRate)
        {
            _fanTimer += Time.deltaTime;
        }
        else
        {
            SpawnFan();
        }

        //Boxes
        if (_boxTimer < boxSpawnRate)
        {
            _boxTimer += Time.deltaTime;
        }
        else
        {
            randomNumber = Random.Range(1, 11); //Make a random number
            SpawnBox(randomNumber);
        }

        // Neon Trail
        if (_neonTrailTimer < neonTrailSpawnRate)
        {
            _neonTrailTimer += Time.deltaTime;
        }
        else
        {
            SpawnNeonTrail();
        }
    }

    void SpawnBox(int i)
    {
        if (i < 8)
        {
            Instantiate(Box, new Vector3(transform.position.x + Random.Range(-2.4f, 2.4f), transform.position.y + 0.5f, transform.position.z), transform.rotation);
        }
        else
        {
            Instantiate(RedBox, new Vector3(transform.position.x + Random.Range(-2.45f, 2.45f), transform.position.y + 0.5f, transform.position.z), transform.rotation);
        }

        _boxTimer = 0;
    }
    
    void SpawnRail()
    {
        if (!_railFlipped)
        {
            Instantiate(Rail, new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z + 6), transform.rotation);
            Rail.transform.localScale = new Vector3(-1, 1, 1);
            _railFlipped = true;
        }
        else
        {
            Instantiate(Rail, new Vector3(transform.position.x, transform.position.y - 0.8f, transform.position.z + 6), transform.rotation);
            Rail.transform.localScale = new Vector3(1, 1, 1);
            _railFlipped = false;
        }
        _railTimer = 0;
    }

    void SpawnFan()
    {
        if (!_fanFlipped)
        {
            Instantiate(Fan, new Vector3(transform.position.x, transform.position.y, transform.position.z + 15), transform.rotation);
            Fan.transform.localScale = new Vector3(-1, 1, 1);
            _fanFlipped = true;
        }
        else
        {
            Instantiate(Fan, new Vector3(transform.position.x, transform.position.y, transform.position.z + 15), transform.rotation);
            Fan.transform.localScale = new Vector3(1, 1, 1);
            _fanFlipped = false;
        }
        _fanTimer = 0;
    }

    void SpawnNeonTrail()
    {
        float randomX = Random.Range(-60, 60);
        float randomY = Random.Range(-100, 30);

        Instantiate(NeonTrail, new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + 200), transform.rotation);

        _neonTrailTimer = 0;

    }

}
