using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snakey.Scene;

namespace Snakey;

/// <summary>
/// This class handles the current scene being played.
/// </summary>
public class SceneHandler {
    private static SceneHandler instance;
    
    private SnakeScene snakeScene = new();
    public SnakeScene ActiveScene => snakeScene;
    public static SceneHandler Instance => instance;
    public SceneHandler(ContentManager pContent, GraphicsDevice pGraphics) {
        TextureHandler textureHandler = new TextureHandler(pContent, pGraphics);
        if (instance != null) {
            throw new Exception($"{GetType()} already initialized? This should never happen.");
        }
        instance = this;
    }
    /// <summary>
    /// Initializes the current scene.
    /// </summary>
    public void Initialize() {
        snakeScene.CreateObjects();
        snakeScene.Initialize();
    }
    
    /// <summary>
    /// Loads the current scene.
    /// </summary>
    public void Load() {
        snakeScene.Load();
    }
    
    /// <summary>
    /// Updates the current scene.
    /// </summary>
    public void Update(GameTime pGameTime) {
        snakeScene.Update(pGameTime);
    }

    /// <summary>
    /// Draws the current scene.
    /// </summary>
    /// <param name="pSpriteBatch"></param>
    public void Render(SpriteBatch pSpriteBatch) {
        pSpriteBatch.Begin();
        snakeScene.Render(pSpriteBatch);
        pSpriteBatch.End();
    }
}