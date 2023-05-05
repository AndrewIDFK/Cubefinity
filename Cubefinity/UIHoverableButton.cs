using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubefinity
{
    public abstract class UIHoverableButton : Component
    {
        public bool _isHovering;
        public string HoverText { get; set; }
    }

}
