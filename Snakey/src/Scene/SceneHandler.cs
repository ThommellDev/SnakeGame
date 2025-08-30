using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snakey.Scene;

namespace Snakey;

/// <summary>
/// This class handles the current scene being played.
/// </summary>
public class SceneHandler {

    private SnakeScene scene = new();
    // temporary, make a utility class later
    private ContentManager content;
    private TextureHandler textureHandler;

    public SceneHandler(ContentManager pContent) {
        content = pContent;
        textureHandler = new TextureHandler(content);
    }
    /// <summary>
    /// Initializes the current scene.
    /// </summary>
    public void Initialize() {
        scene.CreateObjects();
        scene.Initialize();
    }
    
    /// <summary>
    /// Loads the current scene.
    /// </summary>
    public void Load() {
        scene.Load();
    }
    
    /// <summary>
    /// Updates the current scene.
    /// </summary>
    public void Update(GameTime pGameTime) {
        scene.Update(pGameTime);
    }

    /// <summary>
    /// Draws the current scene.
    /// </summary>
    /// <param name="pSpriteBatch"></param>
    public void Render(SpriteBatch pSpriteBatch) {
        pSpriteBatch.Begin();
        scene.Render(pSpriteBatch);
        pSpriteBatch.End();
    }
}