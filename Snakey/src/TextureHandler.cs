using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Snakey;

public class TextureHandler {
    private static TextureHandler instance;
    private Dictionary<TextureType, Texture2D> textures;
    public static TextureHandler Instance => instance;
    public Dictionary<TextureType, Texture2D> Textures => textures;
    public TextureHandler(ContentManager content) {
        if (instance != null) {
            throw new Exception("Texture handler already initialized? This should never happen.");
        }
        instance = this;
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
        // Looks up the string parameter, if successful, it'll return with an error message.
        if (textures.ContainsKey(textureType)) {
            Console.Error.WriteLine("Texture already exists: " + textureType);
            return;
        } 
        // Caches the Texture2D by string within the Dictionary.
        textures.Add(textureType, texture);
    } 
    /// <summary>
    /// Return getting the parameters given texture type..
    /// </summary>
    /// <param name="pTextureType"></param>
    /// <returns>The wanted texture from the TextureType's key-value.</returns>
    public Texture2D GetTexture(TextureType pTextureType) {
        if (textures.TryGetValue(pTextureType, out var texture))
            return texture;
        Console.Error.WriteLine("Texture not found, name: " + pTextureType);
        return null;
    }
}