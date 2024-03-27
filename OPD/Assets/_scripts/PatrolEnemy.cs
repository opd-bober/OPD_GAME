using UnityEngine;

public class PatrolEnemy : Enemy
{
    public Vector3 pointA;
    public Vector3 pointB;
    private Vector3 targetPoint;

    public float speed = 5f; // Скорость перемещения врага

    // Используем метод Awake для инициализации
 protected override void Awake()
{
    base.Awake(); // Вызов метода Awake базового класса
    targetPoint = pointA; // Дополнительная инициализация для PatrolEnemy
}

    private void Update()
    {
        MoveTowardsTarget(); // Перемещение врага
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
        }
    }

    protected override void OnKilled()
    {
        Debug.Log("Enemy killed");
    }

public bool HasReachedTarget()
{
    bool reached = Vector3.Distance(transform.position, pointB) < 0.1f;
    Debug.Log($"HasReachedTarget check: {reached}");
    return reached;
}

    public void SetTargetPoint(Vector3 point)
{
    targetPoint = point;
}
}
