using Snakey.Components;
using Snakey.Components.Custom;

namespace Snakey.GameObjects;

public class Snake : GameObject {
    public Snake(Transform pTransform, params Component[] pComponents) : base(pTransform, pComponents) {
    }
}