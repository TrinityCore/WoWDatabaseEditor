﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WDE.Common.Managers;
using WDE.Common.Parameters;
using WDE.Common.Providers;
using WDE.Module.Attributes;

namespace WoWDatabaseEditorCore.Services.ItemFromListSelectorService
{
    [AutoRegister]
    public class ItemFromListProvider : IItemFromListProvider
    {
        private readonly IWindowManager windowManager;

        public ItemFromListProvider(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }
        
        public async Task<int?> GetItemFromList(Dictionary<int, SelectOption> items, bool flags, int? current = null)
        {
            using ItemFromListProviderViewModel vm = new(items, flags, current);
            if (await windowManager.ShowDialog(vm))
                return vm.GetEntry();
            return null;
        }
    }
}