using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float ghrostInterval = 3.5f;

    [SerializeField]
    private float spawnRadius = 30f; // O raio de spawn

    private GameObject player;

    void OnDrawGizmosSelected()
    {
        // Desenha um círculo vermelho no editor que representa o raio de spawn
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnEnemy(ghrostInterval, enemyPrefab));
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        if (player == null) // Verifique se o jogador ainda existe
        {
            player = GameObject.FindGameObjectWithTag("Player"); // Tente encontrar o jogador novamente
            if (player == null) // Se ainda não for encontrado, pare a coroutine
            {
                yield break;
            }
        }

        Vector3 spawnPosition = RandomPositionWithinRadius(spawnRadius);
        if (Vector3.Distance(spawnPosition, player.transform.position) <= spawnRadius)
        {
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    private Vector3 RandomPositionWithinRadius(float radius)
    {
        float angle = UnityEngine.Random.Range(0f, 2 * Mathf.PI);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);
        return new Vector3(x, y, 0f) + transform.position; // Adicionamos a posição do spawner
    }
}