using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snakey.Components.Custom;

namespace Snakey;
public class TextureHandler {
    private static TextureHandler instance;
    private GraphicsDevice graphics;
    private Dictionary<TextureType, Texture2D> textures;
    private Dictionary<string, Texture2D> customTextures = new();
    public static TextureHandler Instance => instance;
    public Dictionary<TextureType, Texture2D> Textures => textures;
    public Dictionary<string, Texture2D> CustomTextures => customTextures;
    public TextureHandler(ContentManager content, GraphicsDevice pGraphics) {
        if (instance != null) {
            throw new Exception("Texture handler already initialized? This should never happen.");
        }
        instance = this;
        graphics = pGraphics;
        SetTextures(content);
    }
    private void SetTextures(ContentManager pContent) {
        textures = new Dictionary<TextureType, Texture2D> {
            { TextureType.Apple, pContent.Load<Texture2D>("apple") },
            { TextureType.SnakeHeadDown, pContent.Load<Texture2D>("head_down") },
            { TextureType.SnakeHeadUp, pContent.Load<Texture2D>("head_up") },
            { TextureType.SnakeHeadLeft, pContent.Load<Texture2D>("head_left") },
            { TextureType.SnakeHeadRight, pContent.Load<Texture2D>("head_right") },
        };
    }
    /// <summary>
    /// Tries adding the Texture2D parameter, if unsuccessful it'll return cleanly.
    /// </summary>
    /// <param name="textureName">The newly added texture's key.</param>
    /// <param name="texture">The newly added texture's value.</param>
    public void AddTexture(TextureType textureType, Texture2D texture) {
        // Looks up the TextureType (enum) parameter, if it already exists, it'll return with an error message.
        if (textures.ContainsKey(textureType)) {
            Console.Error.WriteLine("Texture already exists: " + textureType);
            return;
        } 
        // Caches the Texture2D by string within the Dictionary.
        textures.Add(textureType,  texture);
    } 
    /// <summary>
    /// Tries adding the Texture2D parameter, if unsuccessful it'll return cleanly.
    /// </summary>
    /// <param name="textureName">The newly added texture's key.</param>
    /// <param name="texture">The newly added texture's value.</param>
    private void AddTexture(string pTextureName, Texture2D texture) {
        // Looks up the string parameter, if successful, it'll return with an error message.
        if (customTextures.ContainsKey(pTextureName)) {
            Console.Error.WriteLine("Texture already exists: " + pTextureName);
            return;
        } 
        // Caches the Texture2D by string within the Dictionary.
        customTextures.Add(pTextureName, texture);
    } 
    /// <summary>
    /// Return getting the parameters given texture type.
    /// </summary>
    /// <param name="pTextureType"></param>
    /// <returns>The wanted texture from the TextureType's key-value.</returns>
    public Texture2D GetTexture(TextureType pTextureType) {
        if (textures.TryGetValue(pTextureType, out var texture))
            return texture;
        Console.Error.WriteLine("Texture not found, name: " + pTextureType);
        return null;
    }

    /// <summary>
    /// Return getting the parameters given string.
    /// </summary>
    /// <param name="pTextureName"></param>
    /// <returns>The wanted texture from the string key-value.</returns>
    public Texture2D GetTexture(string pTextureName) {
        if (customTextures.TryGetValue(pTextureName, out var texture))
            return texture;
        Console.Error.WriteLine("Texture not found, name: " + pTextureName);
        return null;
    }
    
    /// <summary>
    /// Creates and caches a newly created pixel (square).
    /// </summary>
    /// <param name="pWidth">Width of the texture.</param>
    /// <param name="pHeight">Height of the texture.</param>
    /// <param name="pColor">Color of the texture.</param>
    /// <param name="pPixelWidth">Size of the pixel's width (1px is default)</param>
    /// <param name="pPixelHeight">Size of the pixel's height (1px is default)</param>
    /// <returns>A newly created texture.</returns>
    public void CreateTexture(string pTextureName, int pWidth, int pHeight, Color pColor, int pPixelWidth = 1, int pPixelHeight = 1){
        Texture2D pixel = new Texture2D(graphics, pPixelWidth, pPixelHeight);
        pixel.SetData(new[] { pColor });
        Texture2D newTexture = new Texture2D(graphics, pWidth, pHeight);
        Color[] data = new Color[pWidth * pHeight];

        for (int i = 0; i < data.Length; i++) {
           data[i] = pColor; 
        }
        
        newTexture.SetData(data);
        AddTexture(pTextureName.ToLower(), newTexture);
    }

    public Vector2 GetTextureBounds(TextureType pTextureType) {
        if (!textures.TryGetValue(pTextureType, out var texture)) {
            throw new NotImplementedException("Texture not found: " + pTextureType);
        }
        return new Vector2(texture.Width, texture.Height);
    }
}