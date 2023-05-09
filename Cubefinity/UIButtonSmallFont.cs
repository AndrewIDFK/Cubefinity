using Cubefinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Cubefinity
{
     public class UIButtonSmallFont : UIHoverableButton
    {
        private ConfirmationPopup _confirmationPopup;
        public Texture2D ButtonTexture;
        public Rectangle Bounds { get; set; }
        public Vector2 ScreenPos { get; set; }
        public string Text { get; set; }
        public Color TextColor { get; set; }
        public Color BackgroundColor { get; set; }
        public SpriteFont Font { get; set; }

        public MouseState _currentMouse;
        public MouseState _previousMouse;
        public event EventHandler Click;
        public Color extraButtonColor { get; set; }

        public UIButtonSmallFont(Texture2D texture, Rectangle bounds, Vector2 screenPos, string text, SpriteFont font, Color buttonColor, Color textColor)
        {
            ButtonTexture = texture;
            Bounds = bounds;
            ScreenPos = screenPos;
            Text = text;
            TextColor = textColor;
            BackgroundColor = buttonColor;
            extraButtonColor = buttonColor;
            Font = font;
        }



        public bool Contains(Point point)
        {
            return Bounds.Contains(point);
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            var scaleX = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / MainGame.DesignWidth;
            var scaleY = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / MainGame.DesignHeight;
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;
            if (_confirmationPopup == null)
            {
                int scaledX = (int)((ScreenPos.X + Bounds.X) * scaleX);
                int scaledY = (int)(ScreenPos.Y * scaleY);
                int scaledWidth = (int)(Bounds.Width * scaleX);
                int scaledHeight = (int)(Bounds.Height * scaleY);

                if (mouseRectangle.Intersects(new Rectangle(scaledX, scaledY, scaledWidth, scaledHeight)))
                {
                    _isHovering = true;

                    if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                    {
                        Click?.Invoke(this, new EventArgs());
                    }
                }
            }
            else BackgroundColor = extraButtonColor;
        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_isHovering) BackgroundColor = new Color(extraButtonColor.R + 15, extraButtonColor.G + 15, extraButtonColor.B + 15);
            else BackgroundColor = extraButtonColor;

            spriteBatch.Draw(ButtonTexture, new Rectangle((int)ScreenPos.X + Bounds.X, (int)ScreenPos.Y, Bounds.Width, Bounds.Height), BackgroundColor);
            spriteBatch.DrawString(MainGame.font, Text, new Vector2((ScreenPos.X + (Bounds.X + 14 + Bounds.Width / 2 - MainGame.font.MeasureString(Text).X / 2) * 1.1f), ScreenPos.Y + (Bounds.Height / 2 - MainGame.font.MeasureString(Text).Y / 2) * 1.1f), TextColor, 0f, Vector2.Zero, 0.9f, SpriteEffects.None, 0f);
        }
    }
}