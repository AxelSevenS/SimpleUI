using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SevenGame.UI {

    public interface IUIModal : IUIMenu {

        IUIMenu previousModal { get; }
    }
}
