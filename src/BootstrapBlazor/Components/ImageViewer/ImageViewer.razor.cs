// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components;

/// <summary>
/// 
/// </summary>
partial class ImageViewer : IDisposable
{
    /// <summary>
    /// 使用内置图片DIV
    /// </summary>
    [Parameter] public bool UseBuiltinImageDiv { get; set; } = true;

    /// <summary>
    /// 图片列表
    /// </summary>
    [Parameter] public List<string> Images { get; set; } = new List<string>();

    /// <summary>
    /// 单图片
    /// </summary>
    [Parameter] public string? Src { get; set; }

    /// <summary>
    /// 图片名称列表
    /// </summary>
    [Parameter] public List<string>? Alts { get; set; }

    /// <summary>
    /// 组件初始化参数
    /// </summary>
    [Parameter] public ImageViewerOptions Options { get; set; } = new ImageViewerOptions();

    /// <summary>
    /// 简化版工具条
    /// </summary>
    [Parameter] public bool? toolbarlite { get; set; }

    /// <summary>
    /// 高
    /// </summary>
    [Parameter] public string? Height { get; set; } = "400px";

    /// <summary>
    /// 宽
    /// </summary>
    [Parameter] public string? Width { get; set; } = "400px";

    /// <summary>
    /// 组件ID
    /// </summary>
    [Parameter] public string? ID { get; set; }

    [NotNull]
    private JSInterop<ImageViewer>? Interop { get; set; }
    private ElementReference ImageViewerElement { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected override void OnInitialized()
    {
        Options ??= new ImageViewerOptions();
        if (toolbarlite != null) Options.toolbarlite = toolbarlite.Value;
        if (!string.IsNullOrEmpty(ID)) Options.id = ID; else Options.id = Guid.NewGuid().ToString();
        Images ??= new List<string>();
        if (Src != null)
            Images.Add(Src);
        else if (!Images.Any())
        {
            for (int i = 1; i <= 9; i++)
            {
                Images.Add("./_content/BootstrapBlazor/logo.png");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstRender"></param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            Interop ??= new JSInterop<ImageViewer>(JSRuntime);
            Options.viewer= await Interop.InvokeAsync<object>(this, ImageViewerElement, "bb_ImageViewer", Options);
        }
    }

    /// <summary>
    /// 选项改变
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public async Task OnOptionsChanged(ImageViewerOptions options) => await Interop!.InvokeVoidAsync(this, ImageViewerElement, "bb_ImageViewer", options);

    /// <summary>
    /// js对象回调
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [JSInvokable]
    public void OnValueChanged(object obj)
    {
        //ImageViewerElement = obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual async void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (Interop != null)
            {
                if (Options.viewer != null) await Interop!.InvokeVoidAsync(this, ImageViewerElement, "bb_ImageViewerDestroy", Options);
                Interop?.Dispose();
                Interop = null;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

}
