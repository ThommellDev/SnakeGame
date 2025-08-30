using System;
using Microsoft.Xna.Framework;
using Snakey.Components.Custom;
using Snakey.GameObjects;

namespace Snakey.Scene;

public class SnakeScene : BaseScene {
    private Apple apple;
    public override void CreateObjects() {
        Transform appleTransform = new Transform(pPosition: new Vector2(200, 200));
        SpriteRenderer appleRenderer = new SpriteRenderer(TextureType.Apple);
        PlayerMovement playerMover = new(pSpeed: 100f);
        apple = new Apple(appleTransform, appleRenderer, playerMover);
        TryAddObject(apple);
    }

    public override void Update(GameTime pGameTime) {
        Console.WriteLine(apple.Transform.Origin);
        base.Update(pGameTime);
    }
}