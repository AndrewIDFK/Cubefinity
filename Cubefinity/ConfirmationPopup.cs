using Cubefinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Cubefinity
{
    public class ConfirmationPopup
    {
        public Rectangle Bounds { get; set; }
        public event EventHandler YesButtonClicked;
        public event EventHandler NoButtonClicked;

        private string _message;
        private Vector2 _position;
        private Color _color;
        private Texture2D _backgroundTexture;
        private SpriteFont _font { get; set;}

        public ConfirmationPopup(GraphicsDevice graphicsDevice, string message, Rectangle bounds, Vector2 position, Color color, SpriteFont font)
        {
            _message = message;
            _position = position;
            _color = color;
            Bounds = bounds;

            _backgroundTexture = CreateRoundedRectangleTexture(graphicsDevice, 300, 120, 20, new Color(56, 56, 56, 255), 6, new Color(18, 18, 18, 255));
            _font = font;
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

        Color yesColor = Color.White;
        Color noColor = Color.White;
        public void Draw(SpriteBatch spriteBatch, Point mousePosition)
        {
            var scaleX = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / MainGame.DesignWidth;
            var scaleY = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / MainGame.DesignHeight;

            spriteBatch.Draw(_backgroundTexture, _position, Color.White);
            spriteBatch.DrawString(_font, _message, _position + new Vector2(Bounds.Width / 2 - _font.MeasureString(_message).X / 2, 20), _color);
            Rectangle yesButtonBounds = new Rectangle((int)((_position.X + Bounds.Width / 4 - 20) * scaleX), (int)((_position.Y + Bounds.Height / 2 - 10) * scaleY), (int)(40 * scaleX), (int)(30 * scaleY));
            Rectangle noButtonBounds = new Rectangle((int)((_position.X + Bounds.Width * 3 / 4 - 20) * scaleX), (int)((_position.Y + Bounds.Height / 2 - 10) * scaleY), (int)(40 * scaleX), (int)(30 * scaleY));
            if (yesButtonBounds.Contains(mousePosition))
            {
                yesColor = Color.Green;
            }
            else yesColor = Color.White;
            if (noButtonBounds.Contains(mousePosition))
            {
                noColor = Color.Red;
            }
            else noColor = Color.White;

            // Draw the Yes and No buttons
            spriteBatch.DrawString(_font, "Yup", _position + new Vector2(Bounds.Width / 4 - _font.MeasureString("Yup").X / 2, Bounds.Height / 2), yesColor, 0, Vector2.Zero, new Vector2(scaleX, scaleY), SpriteEffects.None, 0);
            spriteBatch.DrawString(_font, "Nah", _position + new Vector2(Bounds.Width * 3 / 4 - _font.MeasureString("Nah").X / 2, Bounds.Height / 2), noColor, 0, Vector2.Zero, new Vector2(scaleX, scaleY), SpriteEffects.None, 0);
        }

        public void HandleMouseClick(Point mousePosition)
        {
            var scaleX = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / MainGame.DesignWidth;
            var scaleY = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / MainGame.DesignHeight;

            Rectangle yesButtonBounds = new Rectangle((int)((_position.X + Bounds.Width / 4 - 20) * scaleX), (int)((_position.Y + Bounds.Height / 2 - 10) * scaleY), (int)(40 * scaleX), (int)(30 * scaleY));
            Rectangle noButtonBounds = new Rectangle((int)((_position.X + Bounds.Width * 3 / 4 - 20) * scaleX), (int)((_position.Y + Bounds.Height / 2 - 10) * scaleY), (int)(40 * scaleX), (int)(30 * scaleY));

            if (yesButtonBounds.Contains(mousePosition))
            {
                YesButtonClicked?.Invoke(this, EventArgs.Empty);
            }
            else if (noButtonBounds.Contains(mousePosition))
            {
                NoButtonClicked?.Invoke(this, EventArgs.Empty);
            }
        }

    }

}
