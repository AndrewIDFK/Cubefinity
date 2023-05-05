using System;
using System.Collections.Generic;
using System.Globalization;
using Cubefinity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;

public class AchievementPopup
{
    public Rectangle Bounds { get; set; }
    private string _text;
    private string _reqs;
    private SpriteFont _font;
    private Vector2 _position;
    private Color _color;
    private Texture2D _backgroundTexture;
    private Vector2 _slideStartPosition;
    private Vector2 _slideEndPosition;
    private float _slideDuration;
    private float _fadeDuration;
    private float _elapsedTime;
    private float _waitDuration;
    private bool _isVisible;
    public static Queue<AchievementPopup> AchievementQueue { get; set; } = new Queue<AchievementPopup>();
    public AchievementPopup(GraphicsDevice graphicsDevice, string text, string reqs, SpriteFont font, Rectangle bounds, Vector2 position, Color color, float slideDuration = 0.2f, float waitDuration = 2.5f, float fadeDuration = 1f)
    {
        _text = text;
        _reqs = reqs;
        _font = font;
        _position = position;
        _color = color;
        _slideDuration = slideDuration;
        _waitDuration = waitDuration;
        _fadeDuration = fadeDuration;
        _elapsedTime = 0;
        Bounds = bounds;
        int backgroundWidth = 600;
        int backgroundHeight = 120;
        int borderRadius = 20;
        Color backgroundColor = new Color(0, 0, 0, 128); // Semi-transparent black
        int borderWidth = 6;
        Color borderColor = Color.White;

        _backgroundTexture = CreateRoundedRectangleTexture(graphicsDevice, backgroundWidth, backgroundHeight, borderRadius, backgroundColor, borderWidth, borderColor);
        _slideStartPosition = new Vector2(position.X, position.Y + _backgroundTexture.Height);
        _slideEndPosition = position;
    }
    public void Update(GameTime gameTime)
    {
        if (AchievementQueue.Count == 0 || AchievementQueue.Peek() != this) return;

        _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_elapsedTime <= _slideDuration)
        {
            _position = Vector2.Lerp(_slideStartPosition, _slideEndPosition, _elapsedTime / _slideDuration);
        }
        else if (_elapsedTime <= _slideDuration + _waitDuration)
        {
        }
        else if (_elapsedTime <= _slideDuration + _waitDuration + _fadeDuration)
        {
            float fadeAmount = 1 - ((_elapsedTime - _slideDuration - _waitDuration) / _fadeDuration);
            _color = new Color(_color, fadeAmount);
        }
        else
        {
            _isVisible = false;
            AchievementQueue.Dequeue();
        }
    }

    public void Show(string text, string reqs, GraphicsDevice graphicsDevice)
    {
        _text = text;
        _reqs = reqs;
        _elapsedTime = 0;
        _position = new Vector2(1920 / 2 - 300, 1080 - 110);
        _color = Color.White;
        _slideStartPosition = new Vector2(_position.X, _position.Y + _backgroundTexture.Height);
        if (!_isVisible)
        {
            _isVisible = true;
            AchievementQueue.Enqueue(this);
        }
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {
        if (AchievementQueue.Count == 0 || AchievementQueue.Peek() != this) return;

        Vector2 backgroundCenter = new Vector2(_position.X + _backgroundTexture.Width / 2, _position.Y + _backgroundTexture.Height / 2);
        Vector2 textCenter = font.MeasureString(_text) / 2;
        Vector2 reqsCenter = font.MeasureString(_reqs) / 2;

        spriteBatch.Draw(_backgroundTexture, _position, _color);

        DrawColoredText(spriteBatch, font, $"[c:fcfc88]{_text}", backgroundCenter - textCenter - new Vector2(0, 20), _color);
        DrawColoredText(spriteBatch, font, $"[c:88fcc2]{_reqs}", backgroundCenter - reqsCenter + new Vector2(0, 20), _color);
    }



    public void DrawColoredText(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Color baseColor)
    {
        string[] lines = text.Split('\n');
        float lineHeight = font.MeasureString("A").Y;

        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { "[c:" }, StringSplitOptions.None);
            Vector2 currentPos = position;

            for (int i = 0; i < parts.Length; i++)
            {
                int colorEndIndex = parts[i].IndexOf("]");

                if (colorEndIndex > -1)
                {
                    string hexColor = parts[i].Substring(0, colorEndIndex);
                    string content = parts[i].Substring(colorEndIndex + 1);

                    Color color = Color.FromNonPremultiplied(
                        int.Parse(hexColor.Substring(0, 2), NumberStyles.HexNumber),
                        int.Parse(hexColor.Substring(2, 2), NumberStyles.HexNumber),
                        int.Parse(hexColor.Substring(4, 2), NumberStyles.HexNumber),
                        baseColor.A);

                    spriteBatch.DrawString(font, content, currentPos, color);
                    currentPos.X += font.MeasureString(content).X;
                }
                else
                {
                    spriteBatch.DrawString(font, parts[i], currentPos, Color.White * (baseColor.A / 255f));
                    currentPos.X += font.MeasureString(parts[i]).X;
                }
            }
            // Move to the next line
            position.Y += lineHeight;
        }
    }

    private Texture2D CreateRoundedRectangleTexture(GraphicsDevice graphicsDevice, int width, int height, int radius, Color color, int borderWidth = 0, Color borderColor = default(Color))
    {
        int cornerSize = radius * 2;
        RenderTarget2D renderTarget = new RenderTarget2D(graphicsDevice, width, height);
        Texture2D circleTexture = new Texture2D(graphicsDevice, cornerSize, cornerSize);

        Color[] circleData = new Color[cornerSize * cornerSize];
        for (int x = 0; x < cornerSize; x++)
        {
            for (int y = 0; y < cornerSize; y++)
            {
                int i = x + y * cornerSize;
                Vector2 position = new Vector2(x, y);
                Vector2 center = new Vector2(radius, radius);
                float distance = Vector2.Distance(position, center);
                if (distance <= radius)
                {
                    if (distance > radius - borderWidth || borderWidth == 0)
                    {
                        circleData[i] = borderColor != default(Color) ? borderColor : color;
                    }
                    else
                    {
                        circleData[i] = color;
                    }
                }
                else
                {
                    circleData[i] = Color.Transparent;
                }
            }
        }

        circleTexture.SetData(circleData);

        graphicsDevice.SetRenderTarget(renderTarget);
        graphicsDevice.Clear(Color.Transparent);

        SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
        spriteBatch.Begin();

        spriteBatch.Draw(circleTexture, new Rectangle(0, 0, radius, radius), new Rectangle(0, 0, radius, radius), color);
        spriteBatch.Draw(circleTexture, new Rectangle(width - radius, 0, radius, radius), new Rectangle(radius, 0, radius, radius), color);
        spriteBatch.Draw(circleTexture, new Rectangle(0, height - radius, radius, radius), new Rectangle(0, radius, radius, radius), color);
        spriteBatch.Draw(circleTexture, new Rectangle(width - radius, height - radius, radius, radius), new Rectangle(radius, radius, radius, radius), color);

        spriteBatch.Draw(circleTexture, new Rectangle(radius, 0, width - cornerSize, radius), new Rectangle(radius, 0, 1, radius), color);
        spriteBatch.Draw(circleTexture, new Rectangle(radius, height - radius, width - cornerSize, radius), new Rectangle(radius, radius, 1, radius), color);
        spriteBatch.Draw(circleTexture, new Rectangle(0, radius, radius, height - cornerSize), new Rectangle(0, radius, radius, 1), color);
        spriteBatch.Draw(circleTexture, new Rectangle(width - radius, radius, radius, height - cornerSize), new Rectangle(radius, radius, radius, 1), color);

        spriteBatch.Draw(circleTexture, new Rectangle(radius, radius, width - cornerSize, height - cornerSize), new Rectangle(radius, radius, 1, 1), color);

        spriteBatch.End();
        graphicsDevice.SetRenderTarget(null);

        return renderTarget;
    }

}

