using System;
using UnityEngine;

namespace EventCallback
{
    public abstract class Event<T> where T : Event<T>
    {
        private bool hasFired;
        public delegate void EventListener(T info);
        private static event EventListener Listeners;

        public static void RegisterListener(EventListener listener)
        {
            Listeners += listener;
        }

        public static void UnregisterListener(EventListener listener)
        {
            Listeners -= listener;
        }

        public void FireEvent()
        {
            if (hasFired)
            {
                throw new Exception("This event has already fired, to prevent infinite loops you can't refire an event");
            }
            hasFired = true;
            if (Listeners != null)
            {
                Listeners(this as T);
            }
        }
    }

    public class DebugEvent : Event<DebugEvent>
    {
        public int VerbosityLevel;
    }

    public class DeathEvent : Event<DeathEvent>
    {
        //The gameobject being damaged
        public GameObject baseGO;
        //The game object doing the damage
        public GameObject targetGO;
        /*
        Info about cause of death, our killer, etc...
        Could be a struct
        */
    }

    public class DamageEvent : Event<DamageEvent>
    {
        //The gameobject being damaged
        public GameObject baseGO;
        //The game object doing the damage
        public GameObject targetGO;
    }

    public class AttackEvent : Event<AttackEvent>
    {
        //The gameobject being damaged
        public GameObject baseGO;
    }

    public class MoveEvent : Event<MoveEvent>
    {
        //The gameobject being damaged
        public GameObject baseGO;
        //The game object doing the damage
        public Transform target;
    }
    public class InputEvent : Event<InputEvent>
    {
        //Bool to hold button press checks
        public bool escPressed, spacePressed, leftMBPressed, rightMBPressed, midMBPressed;
        //The position of the mouse after screenToorldPosition already calculated
        public Vector3 mousePos;
        //The touch positions if a touh screen is used, error checking done by input manager
        public Vector3[] touchPositions;
        //The vertical and horizontal axis change from keyboard or controller
         public float verticalAxis, horizontalAxis;
    }
}