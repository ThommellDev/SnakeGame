using Snakey.GameObjects;

namespace Snakey.Components;

public interface ICollider {
    public void Collide(GameObject pOtherObject);
}