using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePool : MonoBehaviour
{
    private GameObject[] spikes;
    public int spikePoolSize = 5;
    public GameObject spike;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    public float spawnRate = 2f;
    public float spikeLowMin = -1f;
    public float spikeLowMax = 1f;
    public float spikeHighMin = 2f;
    public float spikeHighMax = 4f;
    private float spawnX = 10f;
    private float spawnY;
    private int currentSpike = 0;
    private bool highSpike = true;

    void Start()
    {
        spikes = new GameObject[spikePoolSize];
        for (int i = 0; i < spikePoolSize; i++)
        {
            spikes[i] = Instantiate(spike, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameControl.Instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            if (highSpike)
            {
                spawnY = Random.Range(spikeHighMin, spikeHighMax);
            }
            else
            {
                spawnY = Random.Range(spikeLowMin, spikeLowMax);
            }
            spikes[currentSpike].transform.position = new Vector2(spawnX, spawnY);
            currentSpike++;
            if (currentSpike >= spikePoolSize)
            {
                currentSpike = 0;
            }
            highSpike = !highSpike;
        }
    }
}
