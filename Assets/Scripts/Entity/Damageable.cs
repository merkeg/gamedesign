using UnityEngine;

namespace Entity
{
    public class Damageable : MonoBehaviour
    {
        public void TakeDamage(float damage)
        {
            VignetteInterface vignetteInterface = FindObjectOfType<VignetteInterface>();
            
            vignetteInterface.AddVignetteValue(damage);
        }
    }
}