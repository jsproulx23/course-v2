using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;//TODO consider re-wire

namespace RPG.Weapons
{
    public class Projectile : MonoBehaviour
    {

        const float DESTROY_DELAY = 0.01f;
        [SerializeField] GameObject shooter;
        float damageCaused;
        [SerializeField] float projectileSpeed;

        public void SetShooter(GameObject shooter)
        {
            this.shooter = shooter;
        }

        public void SetDamage(float damage)
        {
            damageCaused = damage;
        }

        public float GetDefaultLaunchSpeed()
        {
            return projectileSpeed;
        }

        void OnCollisionEnter(Collision collision)
        {
            var layerCollidedWith = collision.gameObject.layer;
            if (shooter && layerCollidedWith != shooter.layer)
            {
                DamageIfDamageable(collision);
            }

        }

        private void DamageIfDamageable(Collision collision) 
        {
            Component damageableComponent = collision.gameObject.GetComponent(typeof(IDamageable));

            if (damageableComponent)
            {
                (damageableComponent as IDamageable).TakeDamage(damageCaused);
            }
            Destroy(gameObject, DESTROY_DELAY);
        } 
    }
}

