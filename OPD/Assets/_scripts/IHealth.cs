public interface IHealth
{
    int currentHealth { get; set; }
    int maxHealth { get; set; }

    void PlusHealth(int health);
    void MinusHealth(int health);
    void Kill();
}