using System.Diagnostics;
using Microsoft.Xna.Framework;
using Snakey.Components.Custom;
using Snakey.Components.Default;
using Snakey.GameObjects;

namespace Snakey.Scene;

public class SnakeScene : BaseScene {
    public override void CreateObjects() {
        
        // Player // Snake
        Vector2 snakePosition = TextureHandler.Instance.GetTextureBounds(TextureType.SnakeHeadUp);
        Transform snakeTransform = new Transform(pPosition: snakePosition);
        SpriteRenderer snakeRenderer = new SpriteRenderer(TextureType.SnakeHeadUp);
        BoxCollider2D snakeCollider = new();
        SnakeMovement snakeMover = new(pTimeToPush: 1f);
        SnakeRotator rotator = new();
        SnakeCollision snakeCollision = new();
        Snake snake = new Snake(snakeTransform, SnakeDirection.Up, snakeRenderer, snakeMover, rotator, snakeCollider, snakeCollision);
        TryAddObject(snake);
        
        // Apple
        Transform appleTransform = new Transform(pPosition: new Vector2(400, 200));
        SpriteRenderer appleRenderer = new SpriteRenderer(TextureType.Apple);
        BoxCollider2D appleCollider = new();
        AppleCollision appleCollision = new();
        Apple apple = new Apple(appleTransform, appleRenderer, appleCollider, appleCollision);
        TryAddObject(apple);
        
        // Collision Manager
        CollisionManager collManager = new CollisionManager();
        GameObject collisionManagerHolder = new(new Transform(), collManager);
        TryAddObject(collisionManagerHolder);
        
        // Grid Manager
        GridManager gridManager = new();
        gridManager.SetGridAmount(9);
        gridManager.SetGridSize(40);
        GameObject gridManagerHolder = new(new Transform(pPosition: new Vector2(snakePosition.X - 20, snakePosition.Y - 20)), gridManager);
        TryAddObject(gridManagerHolder);
    }
}