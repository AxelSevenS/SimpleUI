using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

using SevenGame.Utility;

namespace SevenGame.UI {

    public abstract class UIObject<T> : Singleton<T>, IUIObject where T : UIObject<T> {

        private bool _enabled = false;


        public bool Enabled { 
            get {
                return _enabled;
            } 
            protected set {
                _enabled = value;
            } 
        }

        public virtual void Enable() {
            if (Enabled) return;
            Enabled = true;
            UIManager.UpdateMenuState();
        }

        public virtual void Disable() {
            if (!Enabled) return;
            Enabled = false;
            UIManager.UpdateMenuState();
        }

        
        public virtual void Toggle() {
            if (Enabled)
                Disable();
            else
                Enable();
        }



        protected virtual void OnEnable() {
            SetCurrent();
        }

        protected virtual void OnDisable() {
            
        }
    }

}