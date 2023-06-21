using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

using SevenGame.Utility;
using System.Threading.Tasks;

namespace SevenGame.UI {
    
    public abstract class UIMenu<T> : UIObject<T>, IUIMenu where T : UIMenu<T> {

        public virtual void OnCancel() {
            Disable();
        }

        public abstract void Refresh();

        public abstract void ResetGamePadSelection();


        public override void Enable() {

            if ( UIManager.modalRoot == null ) {
                UIManager.modalRoot = this;
            }
            if ( UIManager.modalLeaf == null ) {
                UIManager.modalLeaf = this;
            }

            transform.SetSiblingIndex( transform.parent.childCount - 1 );

            base.Enable();
        }


        public override void Disable() {

            if ( UIManager.modalRoot == (IUIMenu)this ) {
                UIManager.DisableModalTree();
                UIManager.modalRoot = null;
            }

            if ( UIManager.modalLeaf == (IUIMenu)this ) {
                UIManager.modalLeaf = null;
            }
            
            base.Disable();
        }

        public abstract void EnableInteraction();

        public abstract void DisableInteraction();
    }

}
