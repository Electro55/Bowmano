using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealthPoints = 100;
    public int currentHealthPoints { get; private set; }

    public Stat damage;

    private void Awake()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealthPoints -= damage;
        Debug.Log(transform.name + " takes " + damage + "damage");

        if (currentHealthPoints <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + "died");
    }
}
