using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага для спавна
    public float spawnRate = 2f; // Рейт спавна врагов в секундах
    public int maxEnemies = 5; // Максимальное количество врагов
    private float nextSpawnTime = 0f; // Время следующего спавна
    private int currentEnemyCount = 0; // Текущее количество врагов

    void Update()
    {
        // Проверяем, пора ли спавнить нового врага
        if (Time.time >= nextSpawnTime && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            // Устанавливаем время следующего спавна
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Создаем копию врага в текущем положении спавнера
            GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            currentEnemyCount++; // Увеличиваем счетчик врагов

            // Получаем компонент PatrolEnemy для настройки или удаления
            PatrolEnemy patrolEnemyComponent = spawnedEnemy.GetComponent<PatrolEnemy>();
            if (patrolEnemyComponent != null)
            {

                // Подписываемся на событие OnDestroy врага
                Enemy enemyComponent = spawnedEnemy.GetComponent<Enemy>();
                if (enemyComponent != null)
                {
                    enemyComponent.OnDestroyEvent += OnEnemyDestroyed;
                }

                //удаление врага, когда он достигнет конечной точки
                StartCoroutine(DestroyEnemyAfterReturn(patrolEnemyComponent));
            }
        }
    }

    private void OnEnemyDestroyed()
    {
        currentEnemyCount--; // Уменьшаем счетчик врагов
    }

    // Корутина для удаления врага после возвращения
    System.Collections.IEnumerator DestroyEnemyAfterReturn(PatrolEnemy enemy)
    {
        // Ожидаем, пока враг не достигнет конечной точки
        yield return new WaitUntil(() => enemy.HasReachedTarget());
        // Здесь враг достиг конечной точки и его можно уничтожить
        Destroy(enemy.gameObject);
    }
}
