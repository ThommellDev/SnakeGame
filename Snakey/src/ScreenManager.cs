using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snakey;

public class ScreenManager {
    private static ScreenManager instance;
    private Vector2 screenSize;
    private GameWindow gameWindow;
    private GraphicsDeviceManager graphicsDevice;
    public static ScreenManager Instance => instance;

    public ScreenManager(GameWindow pWindow, GraphicsDeviceManager pGraphics) {
        gameWindow = pWindow;
        graphicsDevice = pGraphics;
        if (instance != null) {
            throw new Exception("There can only be one instance of ScreenManager.");
        }
        instance = this;
        
        gameWindow.AllowUserResizing = true;
        gameWindow.ClientSizeChanged += UpdateScreen;

        graphicsDevice.PreferredBackBufferWidth = 800;
        graphicsDevice.PreferredBackBufferHeight = 600;
        graphicsDevice.ApplyChanges();
        
        UpdateScreen();
    }
    private void UpdateScreen(object pSender = null, EventArgs pEventArgs = null) {
       screenSize = new Vector2(gameWindow.ClientBounds.Width, gameWindow.ClientBounds.Height);
    }
    public Vector2 GetScreenSize() {
        return screenSize;
    }
}