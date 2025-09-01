using Snakey.Components;
using Snakey.Components.Custom;
using Snakey.Enums;

namespace Snakey.GameObjects.Custom;

public class Grid : GameObject{
    GridType gridType;
    public Grid(Transform pTransform, GridType pType, params Component[] pComponents) : base(pTransform, pComponents) {
        gridType = pType;
    }
}