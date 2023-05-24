using System;
using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using UnityEngine;

namespace SevenGame.UI {

    public static class UIManager {

        public static IUIMenu modalLeaf;
        public static IUIMenu modalRoot;


        public static event Action<UIMenuState> OnMenuStateChange;



        public static void DisableModalTree() {
            // Disable all menus in the modal tree
            IUIMenu branch = modalLeaf;
            while ( branch is IUIModal branchModal && branch != null ) {
                branch.Disable();
                branch = branchModal.previousModal;
            }
            modalLeaf = null;
        }


        public static void Cancel() {
            modalLeaf?.OnCancel();
        }

        public static void UpdateMenuState(){

            bool menuUI = modalRoot != null;

            if (menuUI) {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

            bool gameInterrupted = menuUI && modalRoot is IPausedMenu;

            if ( gameInterrupted ){
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }


            OnMenuStateChange?.Invoke( new UIMenuState() {
                menuEnabled = menuUI,
                menuPaused = gameInterrupted
            } );
        }


        public struct UIMenuState {
            public bool menuEnabled;
            public bool menuPaused;
        }
    }
}
