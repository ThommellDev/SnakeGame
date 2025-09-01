using Snakey.GameObjects;

namespace Snakey.Components.Custom;

public class Grid : GameObject{
    public Grid(Transform pTransform, params Component[] pComponents) : base(pTransform, pComponents) {
    }
}