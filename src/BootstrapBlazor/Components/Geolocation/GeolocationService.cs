// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Components;

/// <summary>
/// 地理位置坐标服务
/// </summary>
public class GeolocationService
{
    /// <summary>
    /// 获取当前地理位置坐标信息
    /// </summary>
    /// <returns></returns>
    public async Task<bool> GetLocaltion<TComponent>(JSInterop<TComponent> interop, TComponent component, string callbackMethodName) where TComponent : class
    {
        var ret = await interop.GetGeolocationItemAsync(component, callbackMethodName);
        return ret;
    }

    /// <summary>
    /// 持续定位
    /// </summary>
    /// <returns></returns>
    public async Task<int> WatchPosition<TComponent>(JSInterop<TComponent> interop, TComponent component, string callbackMethodName) where TComponent : class
    {
        var ret = await interop.GetGeowatchPositionItemAsync(component, callbackMethodName);
        return ret;
    }

    /// <summary>
    /// 停止持续定位
    /// </summary>
    /// <returns></returns>
    public async Task ClearWatch<TComponent>(JSInterop<TComponent> interop, TComponent component, long WatchID) where TComponent : class
    {
        await interop.GeoClearWatchAsync(component, WatchID);
    }
}
