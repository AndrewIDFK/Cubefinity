using Cubefinity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class UILabel
{
    public Vector2 Position { get; set; }
    public string Text { get; set; }
    public Color TextColor { get; set; }
    public SpriteFont Font { get; set; }
    public float Scale { get; set; }

    public UILabel(Vector2 position, string text, SpriteFont font, float scale)
    {
        Position = position;
        Text = text;
        TextColor = Color.White;
        Font = font;
        Scale = scale;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(Font, Text, Position, TextColor, 0, default, Scale, SpriteEffects.None, 0);
    }
}
