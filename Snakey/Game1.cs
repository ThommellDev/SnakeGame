using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snakey;

public class Game1 : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private SceneHandler sceneHandler;

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here
        sceneHandler = new SceneHandler(Content);
        sceneHandler.Initialize();
        base.Initialize();
    }

    protected override void LoadContent() {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        sceneHandler.Load();
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        sceneHandler.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        sceneHandler.Render(spriteBatch);
        base.Draw(gameTime);
    }
}