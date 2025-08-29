using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace Snakey;

public class TextureHandler {
    private static TextureHandler instance;
    private Dictionary<string, Texture2D> textures = new();
    
    public static TextureHandler Instance => instance;
    public Dictionary<string, Texture2D> Textures => textures;
    
    public TextureHandler() {
        if (instance != null) {
            throw new Exception("Texture handler already initialized? This should never happen.");
        }
        instance = this;
    }
    /// <summary>
    /// Tries adding the Texture2D parameter, if unsuccessful it'll return cleanly.
    /// </summary>
    /// <param name="textureName">The newly added texture's key.</param>
    /// <param name="texture">The newly added texture's value.</param>
    public void AddTexture(string textureName, Texture2D texture) {
        // Looks up the string parameter, if successful, it'll return with an error message.
        if (textures.ContainsKey(textureName)) {
            Console.Error.WriteLine("Texture already exists: " + textureName);
            return;
        } 
        // Caches the Texture2D by string within the Dictionary.
        textures.Add(textureName, texture);
    } 
    /// <summary>
    /// Return getting the parameters given name
    /// </summary>
    /// <param name="textureName"></param>
    /// <returns></returns>
    private Texture2D GetTexture(string textureName) {
        // Return matching saved texture by name.
        for (int i = 0; i < textures.Count; i++) {
            if (textures.TryGetValue(textureName, out var texture))
                return texture;
        }
        
        // Return null if no matches.
        Console.Error.WriteLine("Texture not found, name: " + textureName);
        return null;
    }
}