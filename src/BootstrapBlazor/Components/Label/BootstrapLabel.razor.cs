// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components;

namespace BootstrapBlazor.Components;

public partial class BootstrapLabel
{
    /// <summary>
    /// 获得/设置 组件值 显示文本 默认 null
    /// </summary>
    [Parameter]
    public string? Value { get; set; }

    /// <summary>
    /// 获得/设置 是否显示标签 Tooltip 多用于标签文字过长导致裁减时使用 默认 false 始终不显示
    /// </summary>
    [Parameter]
    public bool ShowLabelTooltip { get; set; }

    private ElementReference LabelElement { get; set; }

    /// <summary>
    /// OnAfterRender 方法
    /// </summary>
    /// <param name="firstRender"></param>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (ShowLabelTooltip && Value != null)
            {
                await JSRuntime.InvokeVoidAsync(LabelElement, "bb_showLabelTooltip", Value);
            }
        }
    }
}
