using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SevenGame.UI {

    public abstract class CustomButton : Selectable, IPointerClickHandler, ISubmitHandler {

        public new virtual bool interactable {
            get => base.interactable;
            set => base.interactable = value;
        } 

        public abstract void OnButtonInteract(ButtonInputType inputType = ButtonInputType.Primary);

        public void OnPointerClick(PointerEventData eventData) {
            if (!interactable) return;
            OnButtonInteract((ButtonInputType)eventData.button);
        }

        public void OnSubmit(BaseEventData eventData) {
            if (!interactable) return;
            OnButtonInteract();
        }


        public enum ButtonInputType {
            Primary = PointerEventData.InputButton.Left,
            Secondary = PointerEventData.InputButton.Right,
            Tertiary = PointerEventData.InputButton.Middle
        }
    }

}