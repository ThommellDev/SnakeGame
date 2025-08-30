using System;
using System.Collections.Generic;

namespace Snakey.Components.Custom;

public class SnakeRotator : Component {
    private SpriteRenderer spriteRenderer;
    private SnakeDirection direction;

    private static readonly Dictionary<SnakeDirection, TextureType> DirectionToTextureMap = new() {
        { SnakeDirection.Up, TextureType.SnakeHeadUp },
        { SnakeDirection.Down, TextureType.SnakeHeadDown },
        { SnakeDirection.Left, TextureType.SnakeHeadLeft },
        { SnakeDirection.Right, TextureType.SnakeHeadRight }
    };
    public SnakeDirection Direction => direction;
    public override void Initialize() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        base.Initialize();
    }
    
    public void RotateSnake(SnakeDirection pNewDirection) {
        if (!DirectionToTextureMap.TryGetValue(pNewDirection, out var newTexture)) {
            throw new ArgumentOutOfRangeException($"This direction isn't possible: {pNewDirection}");
        }
        spriteRenderer.SetTexture(newTexture);
        SetDirection(pNewDirection);
    }
    public void SetDirection(SnakeDirection pDirection) {
        direction = pDirection;
    }
}