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

    public class UIAchievementButton : UIHoverableButton
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
        public bool IsUpsideDown { get; set; }

        public UIAchievementButton(Texture2D texture, Rectangle bounds, Vector2 screenPos, Texture2D icon, string hoverText, Color buttonColor, bool isUpsideDown)
        {
            ButtonTexture = texture;
            Bounds = bounds;
            ScreenPos = screenPos;
            Icon = icon;
            HoverText = hoverText;
            BackgroundColor = buttonColor;
            extraButtonColor = buttonColor;
            IsUpsideDown = isUpsideDown;
        }

        public bool Contains(Point point)
        {
            var scaleX = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / MainGame.DesignWidth;
            var scaleY = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / MainGame.DesignHeight;

            float x = (point.X / scaleX) - (ScreenPos.X + Bounds.X);
            float y = (point.Y / scaleY) - (ScreenPos.Y);
            int w = (int)((Bounds.Width - 4) * scaleX);
            int h = (int)((Bounds.Height - 4) * scaleY);
            Vector2 A, B, C;
            if (IsUpsideDown)
            {
                A = new Vector2(w / 2.0f, 0);
                B = new Vector2(0, h);
                C = new Vector2(w, h);
            }
            else
            {
                A = new Vector2(0, 0);
                B = new Vector2(w, 0);
                C = new Vector2(w / 2.0f, h);
            }
            float alpha = ((B.Y - C.Y) * (x - C.X) + (C.X - B.X) * (y - C.Y)) / ((B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y));
            float beta = ((C.Y - A.Y) * (x - C.X) + (A.X - C.X) * (y - C.Y)) / ((B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y));
            float gamma = 1.0f - alpha - beta;
            if (alpha >= 0 && beta >= 0 && gamma >= 0)
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

            if(IsUpsideDown)
            {
                spriteBatch.Draw(ButtonTexture, new Rectangle((int)ScreenPos.X + Bounds.X, (int)ScreenPos.Y, Bounds.Width, Bounds.Height), null, BackgroundColor, 0, Vector2.Zero, SpriteEffects.FlipVertically, 0);
            }
            else spriteBatch.Draw(ButtonTexture, new Rectangle((int)ScreenPos.X + Bounds.X, (int)ScreenPos.Y, Bounds.Width, Bounds.Height), BackgroundColor);
            float triangleCenterX = ScreenPos.X + Bounds.X + Bounds.Width / 2.0f;
            float triangleCenterY = IsUpsideDown ? ScreenPos.Y + 2 * Bounds.Height / 3.0f : ScreenPos.Y + Bounds.Height / 3.0f;

            float iconX = triangleCenterX - Icon.Width / 2.0f;
            float iconY = triangleCenterY - Icon.Height / 2.0f;
            spriteBatch.Draw(Icon, new Vector2(iconX, iconY), Color.White);

        }
    }
}