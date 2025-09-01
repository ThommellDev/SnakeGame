using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Snakey.Components.Custom;

public enum GridAxis {
    X,
    Y
}


public class GridManager : Component, IUpdateable{
    
    // Grid Initialization:
    // - Define grid size. (DONE)
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
    private int gridSize;
    private int gridAmount;
    private KeyboardState state;
    private bool hasGeneratedGrid;
    private List<Grid> grid = new();
    public int GridSize => gridSize;
    public GridManager Instance => instance;
    
    public override void Initialize() {
        if (instance != null)
            throw new InvalidOperationException("GridManager already initialized.");
        instance = this;
        base.Initialize();
    }

    public override void Load() {
        base.Load();
        if (gridSize == 0 || gridAmount == 0)
            throw new Exception($"The {GetType().Name} hasn't been initialized properly.");
    }
    
    public void Update(GameTime pGameTime) {
        state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Space)) {
            GenerateGrid();
            hasGeneratedGrid = true;
        }
    }
    private void GenerateGrid() {
        int gridPositionX = ResetGridPosition(GridAxis.X);
        int gridPositionY = ResetGridPosition(GridAxis.Y);
        for (int cellX = 0; cellX < gridAmount; cellX++) {
            for (int cellY = 0; cellY < gridAmount; cellY++) {
                Transform gridTransform = new Transform(pPosition: new Vector2(gridPositionX, gridPositionY)); 
                SpriteRenderer gridRenderer = new SpriteRenderer(TextureType.Apple);
                Grid gridCell = new Grid(gridTransform, gridRenderer);
                grid.Add(gridCell);
                gridPositionX += gridSize;
            }
            gridPositionX = ResetGridPosition(GridAxis.X);
            gridPositionY += gridSize;
        }

        foreach (Grid cell in grid) {
            SceneHandler.Instance.ActiveScene.TryAddObject(cell);
        }
    }

    private void CreateGridTexture() {
        int width = (int)gridSize;
        int height = (int)gridSize;
        
        
    }

    private int ResetGridPosition(GridAxis pGridAxis) {
        if (pGridAxis == GridAxis.X) {
            return 0 + (int)Owner.Transform.Position.X;
        }
        return 0 + (int)Owner.Transform.Position.Y;
    }
    public void SetGridSize(int pGridSize) {
        gridSize = pGridSize;
    }
    public void SetGridAmount(int pGridAmount) {
        gridAmount = pGridAmount;
    }
}