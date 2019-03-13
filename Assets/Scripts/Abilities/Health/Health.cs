public class Health
{
    public HealthData data;

    //Heals the object with this script added to it
    public void Heal(float heal)
    {
        data.health += heal;
    }
    //Deals damage to this object
    public void TakeDamage(float damage)
    {
        data.health -= damage;
    }
}
