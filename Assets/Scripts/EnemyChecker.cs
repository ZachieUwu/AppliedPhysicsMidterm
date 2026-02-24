using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public static int enemyCount = 0;

    void Start()
    {
        enemyCount++;
    }

    void OnDestroy()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            UIScreen.Instance.gameover();
        }
    }
}