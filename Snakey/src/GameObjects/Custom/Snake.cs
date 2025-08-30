using Snakey.Components;
using Snakey.Components.Custom;

namespace Snakey.GameObjects;

public class Snake : GameObject {
    public Snake(Transform pTransform, SnakeDirection pDirection = SnakeDirection.Up, params Component[] pComponents) : base(pTransform, pComponents) {
        GetComponent<SnakeRotator>().SetDirection(pDirection);
    }
   
}