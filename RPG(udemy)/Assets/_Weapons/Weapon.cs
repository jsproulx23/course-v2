using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Weapons
{
    [CreateAssetMenu(menuName = ("RPG/Weapons"))]
    public class Weapon : ScriptableObject
    {

        public Transform gripTransform;

        [SerializeField] GameObject weaponPrefab;
        [SerializeField] AnimationClip attackAnimation;
        [SerializeField] float minTimeBetweenHit = 0.5f;
        [SerializeField] float maxAttackingRange = 2f;

        public GameObject GetWeaponPrefab()
        {
            return weaponPrefab;
        }

        public AnimationClip GetAttackAnimClip()
        {
            attackAnimation.events = new AnimationEvent[0]; //so that asset packs cant cause crashes

            return attackAnimation;
        }

        public float GetMinTimeBetweenHit()
        {
            //TODO consider whetehr we take animation time into account
            return minTimeBetweenHit;
        }

        public float GetMaxAttackRange()
        {
            //TODO consider we take this in account later 
            return maxAttackingRange;
        }
    }

}
