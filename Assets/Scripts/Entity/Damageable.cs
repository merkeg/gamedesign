using UnityEngine;

namespace Entity
{
    public class Damageable : MonoBehaviour
    {
        public void TakeDamage()
        {
            VignetteInterface vignetteInterface = FindObjectOfType<VignetteInterface>();
            
            vignetteInterface.AddVignetteValue(0.1f);
        }
    }
}