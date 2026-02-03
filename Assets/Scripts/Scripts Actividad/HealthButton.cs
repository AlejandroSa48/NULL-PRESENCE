using UnityEngine;

public class HealthButton : MonoBehaviour
{
    public enum Type { Heal, Damage }
    public Type buttonType;

    public float value = 20f;
    public HealthSystem healthSystem;

    public void OnClick()
    {
        if (buttonType == Type.Heal)
            healthSystem.Heal(value);
        else
            healthSystem.TakeDamage(value);
    }
}
