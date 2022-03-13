﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace UnitTest.Components;

public class CameraTest : BootstrapBlazorTestBase
{
    [Fact]
    public async Task InitDevices_Ok()
    {
        var count = 0;
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.OnInit, devices =>
            {
                count = devices.Count();
                return Task.CompletedTask;
            });
            pb.Add(a => a.NotFoundDevicesString, "NotFound");
        });
        await cut.InvokeAsync(() => cut.Instance.InitDevices(Enumerable.Empty<DeviceItem>()));
        cut.Contains("NotFound");

        await cut.InvokeAsync(() => cut.Instance.InitDevices(new DeviceItem[]
        {
            new DeviceItem()
            {
                DeviceId = "1",
                Label = "Device 1"
            },
            new DeviceItem()
            {
                DeviceId = "1"
            }
        }));
        Assert.Equal(2, count);
    }

    [Fact]
    public void Width_Height_Ok()
    {
        var cut = Context.RenderComponent<Camera>(pb =>
        {
            pb.Add(a => a.VideoWidth, 30);
            pb.Add(a => a.VideoHeight, 20);
        });
        Assert.Equal(40, cut.Instance.VideoWidth);
        Assert.Equal(30, cut.Instance.VideoHeight);
    }
}
