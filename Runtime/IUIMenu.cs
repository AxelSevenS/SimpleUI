

namespace SevenGame.UI {

    public interface IUIMenu : IUIObject {
        void OnCancel();
        void Refresh();
        void ResetGamePadSelection();

        void EnableInteraction();
        void DisableInteraction();
    }

}