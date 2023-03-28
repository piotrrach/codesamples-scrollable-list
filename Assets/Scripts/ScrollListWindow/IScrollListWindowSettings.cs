using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Gamesture.Assets.Scripts.ScrollListWindow
{
    public interface IScrollListWindowSettings
    {
        public Component  ScrollListElementView { get; } 
        public PooledScrolList.Settings ScrollListSettings { get; }
    }
}
