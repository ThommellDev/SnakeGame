using Snakey.Components;
using Snakey.Components.Custom;

namespace Snakey.GameObjects;

public class Apple : GameObject {
    public Apple(Transform pTransform, params Component[] pComponents) : base(pTransform, pComponents) {
    }
}