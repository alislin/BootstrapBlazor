// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Components;

/// <summary>
/// 地理位置坐标服务
/// </summary>
public static class Geolocation
{
    /// <summary>
    /// 获取当前地理位置坐标信息
    /// </summary>
    /// <returns></returns>
    public static async Task<bool> GetLocaltion<TComponent>(JSInterop<TComponent> interop, TComponent component, string callbackMethodName) where TComponent : class
    {
        var ret = await interop.GetGeolocationItemAsync(component, callbackMethodName);
        return ret;
    }

    /// <summary>
    /// 持续定位
    /// </summary>
    /// <returns></returns>
    public static async Task<long> WatchPosition<TComponent>(JSInterop<TComponent> interop, TComponent component, string callbackMethodName) where TComponent : class
    {
        var watchID = await interop.GetWatchPositionItemAsync(component, callbackMethodName);
        return watchID;
    }

    /// <summary>
    /// 停止持续定位
    /// </summary>
    /// <returns></returns>
    public static async Task<bool> ClearWatchPosition<TComponent>(JSInterop<TComponent> interop, long watchID) where TComponent : class
    {
        var ret = await interop.SetClearWatchPositionAsync(watchID);
        return ret;
    }
}
