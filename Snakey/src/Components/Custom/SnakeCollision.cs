using System;
using Snakey.GameObjects;

namespace Snakey.Components.Custom;

public class SnakeCollision : Component, ICollider {
    public void Collide(GameObject pOtherObject) {
        Owner.AddObjectToInactivePool(pOtherObject);
        Console.WriteLine($"{GetType().Name} collided with {pOtherObject.GetType().Name}!");
    }
}