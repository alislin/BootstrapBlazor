// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components;

    /// <summary>
    /// Geolocation 组件基类
    /// </summary>
public partial class Geolocation
{
    /// <summary>
    /// 获得/设置 IJSRuntime 实例
    /// </summary>
    [Inject]
    [NotNull]
    protected IJSRuntime? JSRuntime { get; set; }

    private JSInterop<Geolocation>? Interop { get; set; }

    /// <summary>
    /// 获得/设置 定位
    /// </summary>
    [Parameter]
    [NotNull]
    public string? GeolocationInfo { get; set; }

    /// <summary>
    /// 获得/设置 获取位置按钮文字 默认为 获取位置
    /// </summary>
    [Parameter]
    [NotNull]
    public string? GetLocationButtonText { get; set; }

    /// <summary>
    /// 获得/设置 获取持续定位监听器ID
    /// </summary>
    [Parameter]
    public long? WatchID { get; set; }

    /// <summary>
    /// 获得/设置 获取移动距离追踪按钮文字 默认为 移动距离追踪
    /// </summary>
    [Parameter]
    [NotNull]
    public string? WatchPositionButtonText { get; set; }

    /// <summary>
    /// 获得/设置 获取停止追踪按钮文字 默认为 停止追踪
    /// </summary>
    [Parameter]
    [NotNull]
    public string? ClearWatchPositionButtonText { get; set; }

    /// <summary>
    /// 获得/设置 是否显示默认按钮界面
    /// </summary>
    [Parameter]
    public bool ShowButtons { get; set; } = true;

    /// <summary>
    /// 
    /// </summary>
    [Inject]
    [NotNull]
    private IStringLocalizer<Geolocation>? Localizer { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected ElementReference GeolocationElement { get; set; }

    /// <summary>
    /// 获得/设置 定位结果回调方法
    /// </summary>
    [Parameter]
    public Func<Geolocationitem, Task>? OnResult { get; set; }

    /// <summary>
    /// 获得/设置 状态更新回调方法
    /// </summary>
    [Parameter]
    public Func<string, Task>? OnUpdateStatus { get; set; }

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        GetLocationButtonText ??= Localizer[nameof(GetLocationButtonText)];
        WatchPositionButtonText ??= Localizer[nameof(WatchPositionButtonText)];
        ClearWatchPositionButtonText ??= Localizer[nameof(ClearWatchPositionButtonText)];
    }

    /// <summary>
    /// OnAfterRender 方法
    /// </summary>
    /// <param name="firstRender"></param>
    /// <returns></returns>
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender && JSRuntime != null)
        {
            Interop = new JSInterop<Geolocation>(JSRuntime);
        }
    }

    /// <summary>
    /// 获取定位
    /// </summary>
    public virtual async Task GetLocation()
    {
        await Interop.InvokeVoidAsync(this, GeolocationElement, "bb_getLocation");
    }

    /// <summary>
    /// 持续定位
    /// </summary>
    public virtual async Task WatchPosition()
    {
        await Interop.InvokeVoidAsync(this, GeolocationElement, "bb_getLocation", false);
    }

    /// <summary>
    /// 持续定位
    /// </summary>
    public virtual async Task ClearWatch()
    {
        await JSRuntime.InvokeVoidAsync(GeolocationElement, "bb_clearWatchLocation", WatchID);
        WatchID = null;
    }

    /// <summary>
    /// 定位完成回调方法
    /// </summary>
    /// <param name="geolocations"></param>
    /// <returns></returns>
    [JSInvokable]
    public async Task GetResult(Geolocationitem geolocations)
    {
        if (OnResult != null) await OnResult.Invoke(geolocations);
    }

    /// <summary>
    /// 状态更新回调方法
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    [JSInvokable]
    public async Task UpdateStatus(string status)
    {
        if (OnUpdateStatus != null) await OnUpdateStatus.Invoke(status);
    }

    /// <summary>
    /// 监听器ID回调方法
    /// </summary>
    /// <param name="watchID"></param>
    /// <returns></returns>
    [JSInvokable]
    public Task UpdateWatchID(long watchID)
    {
        this.WatchID = watchID;
        return Task.CompletedTask;
    }

}
