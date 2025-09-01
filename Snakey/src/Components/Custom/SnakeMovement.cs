using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Snakey.Components.Default;
using Snakey.GameObjects;

namespace Snakey.Components.Custom;

public class SnakeMovement : Component, IUpdateable{
    private Transform transform;
    private SnakeRotator rotator;
    private BoxCollider2D collider;
    private float timeToPush;
    private float originalTime;
    private int distancePerPush;

    public SnakeMovement(float pTimeToPush = 2f, int pDistancePerPush = 40) {
        timeToPush = pTimeToPush;
        distancePerPush = pDistancePerPush;
        originalTime = timeToPush;
    }

    public override void Initialize() {
        transform = GetComponent<Transform>();
        rotator = GetComponent<SnakeRotator>();
        collider = GetComponent<BoxCollider2D>();
        base.Initialize();
    }
    public void Update(GameTime pGameTime) {
        Timer(pGameTime);
        GetDirection();
    }
    private void GetDirection() {
        KeyboardState state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.W) && rotator.Direction != SnakeDirection.Down) {
            rotator.RotateSnake(SnakeDirection.Up);
        }
        else if (state.IsKeyDown(Keys.S) && rotator.Direction != SnakeDirection.Up) {
            rotator.RotateSnake(SnakeDirection.Down);
        }
        else if (state.IsKeyDown(Keys.A) && rotator.Direction != SnakeDirection.Right) {
            rotator.RotateSnake(SnakeDirection.Left);
        }
        else if (state.IsKeyDown(Keys.D) && rotator.Direction != SnakeDirection.Left) {
            rotator.RotateSnake(SnakeDirection.Right);
        }
    }
    private void Timer(GameTime pGameTime) {
        if (timeToPush >= 0f) {
            timeToPush -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
        else {
            PushSnake();
            ResetTimer();
        }
    }
    private void PushSnake() {
        Vector2 addedPosition = Vector2.Zero;
        switch (rotator.Direction) {
            case SnakeDirection.Up:
                addedPosition.Y -= distancePerPush;
                break;
            case SnakeDirection.Down:
                addedPosition.Y += distancePerPush;
                break;
            case SnakeDirection.Left:
                addedPosition.X -= distancePerPush;
                break;
            case SnakeDirection.Right:
                addedPosition.X += distancePerPush;
                break; 
            default:
                throw new NullReferenceException("Here we go again, how is this possible?");
        }
        if (addedPosition == Vector2.Zero) return;
        transform.Translate(addedPosition);
        collider.OverlapBounds();
    }
    private void ResetTimer() => timeToPush = originalTime;
}