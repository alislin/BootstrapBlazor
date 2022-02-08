// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Components;

/// <summary>
/// 定位数据类
/// </summary>
public class GeolocationItem
{
    /// <summary>
    /// 状态
    /// </summary>
    /// <returns></returns>
    public string? Status { get; set; }

    /// <summary>
    /// 纬度
    /// </summary>
    /// <returns></returns>
    public decimal Latitude { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    /// <returns></returns>
    public decimal Longitude { get; set; }

    /// <summary>
    /// 准确度(米)<para></para>
    /// 将以m指定维度和经度值与实际位置的差距，置信度为95%.
    /// </summary>
    public decimal Accuracy { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public long Timestamp { get; set; }

    /// <summary>
    /// 时间
    /// </summary>
    public DateTime LastUpdateTime { get => UnixTimeStampToDateTime(Timestamp); }

    /// <summary>
    /// 移动距离
    /// </summary>
    public decimal CurrentDistance { get; set; } = 0.0M;

    /// <summary>
    /// 总移动距离
    /// </summary>
    public decimal TotalDistance { get; set; } = 0.0M;

    /// <summary>
    /// 最后一次获取到的纬度
    /// </summary>
    public decimal LastLat { get; set; }

    /// <summary>
    /// 最后一次获取到的经度
    /// </summary>
    public decimal LastLong { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="unixTimeStamp"></param>
    /// <returns></returns>
    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
        return dtDateTime;
    }
}
