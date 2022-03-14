// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// 演示网站示例数据注入服务实现类
/// </summary>
internal class DemoLookUpService : ILookUpService
{
    public IEnumerable<SelectedItem>? GetItemsByKey(string? key)
    {
        if (key == "user_sex")
        {
            return new List<SelectedItem>()
            {
                new SelectedItem(){ Value="0",Text="未知"},
                new SelectedItem(){ Value="1",Text="男"},
                new SelectedItem(){ Value="2",Text="女"},
            };
        }
        if (key == "show_hide")
        {
            return new List<SelectedItem>()
            {
                new SelectedItem(){ Value="0",Text="显示"},
                new SelectedItem(){ Value="1",Text="隐藏"},
            };
        }
        return null;
    }
}
