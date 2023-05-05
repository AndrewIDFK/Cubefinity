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
    public class UIUpgradeButton : UIHoverableButton
    {
        private ConfirmationPopup _confirmationPopup;
        public Texture2D ButtonTexture;
        public Rectangle Bounds { get; set; }
        public Vector2 ScreenPos { get; set; }
        public Texture2D Icon { get; set; }
        public Color BackgroundColor { get; set; }
        public MouseState _currentMouse;
        public MouseState _previousMouse;
        public event EventHandler Click;
        public Color extraButtonColor { get; set; }

        public UIUpgradeButton(Texture2D texture, Rectangle bounds, Vector2 screenPos, Texture2D icon, string hoverText, Color buttonColor)
        {
            ButtonTexture = texture;
            Bounds = bounds;
            ScreenPos = screenPos;
            Icon = icon;
            HoverText = hoverText;
            BackgroundColor = buttonColor;
            extraButtonColor = buttonColor;
        }
        public bool Contains(Point point)
        {
            var scaleX = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / MainGame.DesignWidth;
            var scaleY = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / MainGame.DesignHeight;

            float x = (point.X / scaleX) - (ScreenPos.X + Bounds.X);
            float y = (point.Y / scaleY) - (ScreenPos.Y);
            int w = (int)((Bounds.Width - 4) * scaleX);
            int h = (int)((Bounds.Height - 4) * scaleY);

            if (Math.Abs(x - w / 2) / (w / 2.0) + Math.Abs(y - h / 2) / (h / 2.0) <= 1)
            {
                return true;
            }

            return false;
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            Point mousePoint = new Point(_currentMouse.X, _currentMouse.Y);

            _isHovering = false;

            if (_confirmationPopup == null)
            {
                if (Contains(mousePoint))
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
            if (_isHovering) BackgroundColor = new Color(extraButtonColor.R + 35, extraButtonColor.G + 35, extraButtonColor.B + 35);
            else BackgroundColor = extraButtonColor;
            if (ButtonTexture == null) ButtonTexture = MainGame.UpgradeTexture;
            if (Icon == null) Icon = MainGame.EmptyTexture;

            spriteBatch.Draw(ButtonTexture, new Rectangle((int)ScreenPos.X + Bounds.X, (int)ScreenPos.Y, Bounds.Width, Bounds.Height), BackgroundColor);
            spriteBatch.Draw(Icon, new Vector2(ScreenPos.X + Bounds.X + Bounds.Width / 2 - Icon.Width / 2, ScreenPos.Y + Bounds.Height / 2 - Icon.Height / 2), Color.White);
        }
    }
}