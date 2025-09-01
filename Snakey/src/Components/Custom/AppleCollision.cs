using System;
using Snakey.GameObjects;

namespace Snakey.Components.Custom;

public class AppleCollision : Component, ICollider {
    public void Collide(GameObject pOtherObject) {
        Console.WriteLine($"{GetType().Name} collided with {pOtherObject.GetType().Name}!");
    }
}