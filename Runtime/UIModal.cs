using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SevenGame.UI {

    public abstract class UIModal<T> : UIMenu<T>, IUIModal where T : UIMenu<T> {

        protected IUIMenu _previousModal;
        protected IUIMenu _nextModal;

        public IUIMenu previousModal => _previousModal;
        public IUIMenu nextModal => _nextModal;

        public override void Enable() {

            if ( UIManager.modalLeaf == null) {
                UIManager.modalRoot?.DisableInteraction();
            }

            if ( UIManager.modalLeaf != (IUIModal)this) {
                _previousModal = UIManager.modalLeaf;
                UIManager.modalLeaf?.DisableInteraction();
                UIManager.modalLeaf = this;
            }

            base.Enable();
        }


        public override void Disable() {

            if ( UIManager.modalLeaf == (IUIModal)this) {
                UIManager.modalLeaf = _previousModal;
            }
            _previousModal?.Refresh();
            _previousModal?.EnableInteraction();
            _previousModal?.ResetGamePadSelection();
            _previousModal = null;
            

            base.Disable();
        }

    }
}
