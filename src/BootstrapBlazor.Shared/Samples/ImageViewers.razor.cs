// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// ImageViewer 图片浏览器
/// </summary>
public partial class ImageViewers
{
    /// <summary>
    /// 图片列表
    /// </summary>
    protected List<string> Images { get; set; } = new List<string>();

    /// <summary>
    /// 
    /// </summary>
    protected override void OnInitialized()
    {
        for (int i = 1; i < 9; i++)
        {
            Images.Add("_content/images/Pic{i}.jpg");
        }
    }
}
