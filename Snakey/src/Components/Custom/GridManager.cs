using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Snakey.Enums;
using Snakey.GameObjects.Custom;

namespace Snakey.Components.Custom;

public enum GridAxis {
    X,
    Y
}


public class GridManager : Component, IUpdateable {

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
        CreateGridTexture();
        base.Initialize();
    }

    private void CreateGridTexture() {
        TextureHandler.Instance.CreateTexture("black_square", gridSize, gridSize, Color.WhiteSmoke);
        TextureHandler.Instance.CreateTexture("white_square", gridSize, gridSize, Color.BlanchedAlmond);
        TextureHandler.Instance.CreateTexture("wall", gridSize, gridSize, Color.Black);
    }

    public override void Load() {
        base.Load();
        if (gridSize == 0 || gridAmount == 0)
            throw new Exception($"The {GetType().Name} hasn't been initialized properly.");
    }

    public void Update(GameTime pGameTime) {
        state = Keyboard.GetState();
        if (state.IsKeyDown(Keys.Space) && !hasGeneratedGrid) {
            GenerateGrid();
            hasGeneratedGrid = true;
        }
    }

    private void GenerateGrid() {
        // Algo to generate the grid with walls.
        int gridPositionX = ResetGridPosition(GridAxis.X);
        int gridPositionY = ResetGridPosition(GridAxis.Y);
        int totalX = gridAmount + 2;
        int totalY = gridAmount + 2;
        GridType gridType;
        for (int cellX = 0; cellX < totalX; cellX++) {
            for (int cellY = 0; cellY < totalY; cellY++) {
                Transform gridTransform = new Transform(pPosition: new Vector2(gridPositionX, gridPositionY));
                bool isWall = IsWall(cellX, cellY, totalX, totalY);
                bool isEven = (cellX + cellY) % 2 == 0;
                SpriteRenderer gridRenderer;
                if (isWall) {
                    gridRenderer = new SpriteRenderer("wall");
                    gridType = GridType.Wall;
                }
                else if (isEven) {
                    gridRenderer = new SpriteRenderer("black_square");
                    gridType = GridType.Cell;
                }
                else {
                    gridRenderer = new SpriteRenderer("white_square");
                    gridType = GridType.Cell;
                }
                Grid gridCell = new Grid(gridTransform, gridType, gridRenderer);
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
    private bool IsWall(int pX, int pY, int pXMax, int pYMax) {
        return pX == 0 || pY == 0 || pX == pXMax - 1 || pY == pYMax - 1;
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