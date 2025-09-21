using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject coinPrefab;
    public Transform playerTransform;
    public float spawnYInterval = 2.5f;
    public int initialPlatforms = 10;
    public float horizontalRange = 8f;

    private float highestYPosition = 0f;

    void Start()
    {

        if (playerTransform == null)
        {
            Debug.LogError("ERRO: O campo 'Player Transform' do PlatformSpawner não foi preenchido no Inspector!");
            return;
        }

    
        float firstPlatformY = playerTransform.position.y - 1.5f;
        SpawnPlatform(firstPlatformY);

        for (int i = 0; i < initialPlatforms - 1; i++)
        {
            SpawnPlatform(highestYPosition + spawnYInterval);
        }
    }

    void Update()
    {
       
        if (playerTransform.position.y + (spawnYInterval * 5) > highestYPosition)
        {
            SpawnPlatform(highestYPosition + spawnYInterval);
        }
    }

    void SpawnPlatform(float yPosition)
    {
        float randomXPosition = Random.Range(-horizontalRange, horizontalRange);
        Vector3 platformPosition = new Vector3(randomXPosition, yPosition, 0f);

        Instantiate(platformPrefab, platformPosition, Quaternion.identity);

       
        highestYPosition = yPosition;

      
        if (coinPrefab != null && Random.value < 0.25f)
        {
            Vector3 coinPosition = platformPosition + Vector3.up * 0.7f;
            Instantiate(coinPrefab, coinPosition, Quaternion.identity);
        }
    }
}