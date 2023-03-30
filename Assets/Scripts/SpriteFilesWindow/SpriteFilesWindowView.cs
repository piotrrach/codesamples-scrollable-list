using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamesture.Assets.Scripts.ScrollListWindow;
using Zenject;

namespace Gamesture.Assets.Scripts.SpriteFilesWindow
{
    public class SpriteFilesWindowView : ScrollListWindowView<SpriteFileModel, SpriteFileView>
    {
        [Inject]
        public void Construct(SpriteFileView.Factory factory, ScrollListWindowSetting<SpriteFileView> scrollListWindowSettings)
        {
            base.Construct((model) => factory.Create(model), scrollListWindowSettings.PooledScrollListSettings);
        }

        public class Factory : PlaceholderFactory<SpriteFilesWindowView> { }
    }

}
