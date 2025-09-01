using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snakey.Components.Custom;

public class GridManager : Component, IUpdateable, IRenderable {
    
    // Grid Initialization:
    // - Define grid size.
    // - Store each cell's position in world or screen coords (X,Y)
    // - Provide a consistent way to move/translate between cells
    
    // Cell Management:
    // - Track whether each cell is empty, occupied by player or contains food.
    // - Allow quick updates when the snake moves (old -> empty, new -> occupied)
    // - Ensure no overlap of multiple entities in the same cell (unless intended)
    
    // Snake Interaction:
    // - Handle movement logic by checking the state of the NEXT cell:
    // - - Empty: Snake moves forward.
    // - - Food: Snake grows and score increases.
    // - - Snake body or wall: Game over.

    private GridManager instance;
    public GridManager Instance => instance;

    public override void Initialize() {
        if (instance != null)
            throw new Exception("GridManager has already been initialized? This should never happen.");
        instance = this;
        base.Initialize();
    }

    public void Update(GameTime pGameTime) {
        throw new System.NotImplementedException();
    }
    public void Render(SpriteBatch pSpriteBatch) {
        throw new System.NotImplementedException();
    }
}