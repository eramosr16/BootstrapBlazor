﻿using BootstrapBlazor.Shared.Common;
using BootstrapBlazor.Shared.Pages.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootstrapBlazor.Shared.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class QRCodes
    {
        private Logger? Trace { get; set; }

        private Task OnGenerated()
        {
            Trace?.Log("二维码生成成功");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获得属性方法
        /// </summary>
        /// <returns></returns>
        private IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
        {
            // TODO: 移动到数据库中
            new AttributeItem() {
                Name = "OnGenerated",
                Description = "二维码生成后回调委托",
                Type = "Func<Task>",
                ValueList = " — ",
                DefaultValue = " — "
            }
        };
    }
}
