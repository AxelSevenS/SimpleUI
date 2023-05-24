

namespace SevenGame.UI {

    public interface IUIObject {
        bool Enabled { get; }
        void Enable();
        void Disable();
        void Toggle();
    }
    
}