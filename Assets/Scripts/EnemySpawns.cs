using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public GameObject enemy;
    public LayerMask spawnLayerMask;
    public LayerMask groundLayer;

    public float rayHeight = 10f;
    public float radius = 50f;
    public int maxedObj = 15;
    private int currentObj = 0;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int safety = 0;

        while (currentObj < maxedObj && safety < 1000)
        {
            Enemies();
            safety++;
        }
    }

    void Enemies()
    {
        int safety = 0;

        while (currentObj < maxedObj && safety < 5000)
        {
            Vector3 position = new Vector3(
                Random.Range(-146, 200),
                rayHeight,
                Random.Range(-146, 200)
            );

            if (Physics.Raycast(position, Vector3.down, out RaycastHit hit, 1000f))
            {
                if (((1 << hit.collider.gameObject.layer) & groundLayer) != 0)
                {
                    Collider[] colliders = Physics.OverlapSphere(hit.point, 5f, spawnLayerMask);

                    if (colliders.Length == 0)
                    {
                        Instantiate(enemy, hit.point, Quaternion.identity);
                        currentObj++;
                    }
                }
            }

            safety++;
        }
    }
}
