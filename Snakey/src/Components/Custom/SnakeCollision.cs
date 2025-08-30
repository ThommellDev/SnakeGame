using System;
using Snakey.GameObjects;

namespace Snakey.Components.Custom;

public class SnakeCollision : Component, ICollider {
    public void Collide(GameObject pOtherObject) {
        pOtherObject.Transform.Toggle(false);
        Console.WriteLine($"{GetType().Name} collided with {pOtherObject.GetType().Name}!");
    }
}