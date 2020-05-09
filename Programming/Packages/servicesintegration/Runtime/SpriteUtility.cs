using UnityEngine;

namespace wolf.hazel.utility
{
    public class SpriteUtility 
{
        public static Sprite textureToSprite(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
        }
    }
}
