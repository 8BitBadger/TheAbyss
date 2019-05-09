﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventCallback;
using UnityEditor;

namespace Comps
{
    public class PlayerAttack : MonoBehaviour
    {
        //Used for the interval of the attacks, keeps track of last attack time
        private float timer;
        //The weapon hit box for the unit
        private GameObject weaponHitBox;

        private void Start()
        {
            if (transform.GetChild(0).GetComponent<HitDetection>())
            {
                //Get the game object that the hitbox is atached to
                weaponHitBox = transform.GetChild(0).gameObject;
                weaponHitBox.SetActive(false);
            }
            else
            {
                Debug.LogError("PlayerAttack - No weapon hitbox child object detected. Make sure child object is present");
            }
        }

        private void Update()
        {
            //Get the mouse input
            if (Input.GetMouseButton(0))
            {
                //Check the timer if it is time to attack
                if ((Time.time - timer) > gameObject.GetComponent<Stats>().attackSpeed.Value)
                {
                    //We enable the hitbox to check for collisions for the weapon
                    weaponHitBox.SetActive(true);
                    weaponHitBox.transform.Translate(0, 0, 0);
                    //NOTE: play attack animation from here

                    //Call to the attack event callback system
                    AttackEvent attackEventInfo = new AttackEvent();
                    attackEventInfo.baseGO = gameObject;
                    attackEventInfo.FireEvent();
                    //Reset the timer for the next attack time check
                    timer = Time.time;
                }
            }
            //Check the timer if it is time to attack
            if ((Time.time - timer) > gameObject.GetComponent<Stats>().attackSpeed.Value)
            {
                //We disable the hitbox when the timer for the attack has run down
                weaponHitBox.SetActive(false);
            }
        }
    }
}