using System;
using Tasprof.Apps.MySpotify.Core.Enums;

namespace Tasprof.Apps.MySpotify.Core.Interactions
{
    public class ContextMenuItemInteraction
    {
        public Action<ContextMenuItem> Callback { get; set; }
    }
}
