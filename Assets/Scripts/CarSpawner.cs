using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField]
    public GameObject carPrefab;
    [SerializeField]
    public float carSpawnInterval = 2.0f; // Intervalo de spawn para o carro.

    [Header("Bus Settings")]
    [SerializeField]
    public GameObject busPrefab;
    [SerializeField]
    public float busSpawnInterval = 4.0f; // Intervalo de spawn para o ônibus.

    private float carNextSpawnTime = 0f;
    private float busNextSpawnTime = 0f;

    private void Update()
    {
        if (Time.time >= carNextSpawnTime)
        {
            SpawnVehicle(carPrefab);
            carNextSpawnTime = Time.time + carSpawnInterval;
        }

        if (Time.time >= busNextSpawnTime)
        {
            SpawnVehicle(busPrefab);
            busNextSpawnTime = Time.time + busSpawnInterval;
        }
    }

    void SpawnVehicle(GameObject vehiclePrefab)
    {
        Instantiate(vehiclePrefab, transform.position, Quaternion.identity);
    }
}