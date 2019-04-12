using UnityEngine;

public class Health : ComponentSystem.Component
{
    //The base health unmodified
    public float baseHealth;
    //The helath after modifiers have been applied
    public float health;

    public string componentName = "Health";

    public override void Init(GameObject _obj)
    {
        throw new System.NotImplementedException();
    }

    public override void Think()
    {
        throw new System.NotImplementedException();
    }

    //Heals the object with this script added to it
    public void Heal(float heal)
    {
        health += heal;
    }
    //Deals damage to this object
    public void TakeDamage(float damage)
    {
        health -= damage;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if(health <= 0)
        {
            //Call die event
        }
    }
}
