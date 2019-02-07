using System;
using UnityEngine;

namespace EventCallback
{
    public abstract class Event<T> where T : Event<T>
    {

        //public string Description;

        private bool hasFired;
        public delegate void EventListener(T info);
        private static event EventListener Listeners;
        
        public static void RegisterListener(EventListener listener) {
            Listeners += listener;
        }

        public static void UnregisterListener(EventListener listener) {
            Listeners -= listener;
        }

        public void FireEvent() {
            if (hasFired) {
                throw new Exception("This event has already fired, to prevent infinite loops you can't refire an event");
            }
            hasFired = true;
            if (Listeners != null) {
                Listeners(this as T);
            }
        }
    }

    public class DebugEvent : Event<DebugEvent>
    {
        public int VerbosityLevel;
    }

    public class UnitDeathEvent : Event<UnitDeathEvent>
    {
        public GameObject UnitGO;
        /*
        Info about cause of death, our killer, etc...
        Could be a struct
        */
    }
}