// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.Extensions.DependencyInjection;

namespace UnitTest.Components;

public class DownloadTest : BootstrapBlazorTestBase
{
    [Fact]
    public async Task CreateUrlAsync_NoService_Ok()
    {
        var fileName = "";
        var downloadService = Context.Services.GetRequiredService<DownloadService>();
        var cut = Context.RenderComponent<Button>(pb =>
        {
            pb.Add(a => a.OnClick, async () =>
            {
                await downloadService.CreateUrlAsync("test.txt", new byte[] { 0x01, 0x02 });
                fileName = "test.text";
            });
        });
        var btn = cut.Find("button");
        await cut.InvokeAsync(() => btn.Click());
        Assert.Equal("test.text", fileName);
    }

    [Fact]
    public async Task CreateUrlAsync_Ok()
    {
        var fileName = "";
        var downloadService = Context.Services.GetRequiredService<DownloadService>();
        var cut = Context.RenderComponent<BootstrapBlazorRoot>(pb =>
        {
            pb.AddChildContent<Button>(pb =>
            {
                pb.Add(a => a.OnClick, async () =>
                {
                    await downloadService.CreateUrlAsync("test.txt", new byte[] { 0x01, 0x02 });
                    fileName = "test.text";
                });
            });
        });
        var btn = cut.Find("button");
        await cut.InvokeAsync(() => btn.Click());
        Assert.Equal("test.text", fileName);
    }

    [Fact]
    public async Task CreateUrlAsync_Steam_Ok()
    {
        var fileName = "";
        var downloadService = Context.Services.GetRequiredService<DownloadService>();
        var cut = Context.RenderComponent<BootstrapBlazorRoot>(pb =>
        {
            pb.AddChildContent<Button>(pb =>
            {
                pb.Add(a => a.OnClick, async () =>
                {
                    using var stream = new MemoryStream();
                    await downloadService.CreateUrlAsync("test.txt", stream);
                    fileName = "test.text";
                    stream.Close();
                });
            });
        });
        var btn = cut.Find("button");
        await cut.InvokeAsync(() => btn.Click());
        Assert.Equal("test.text", fileName);
    }

    [Fact]
    public async Task DownloadFile_Ok()
    {
        var download = false;
        var downloadService = Context.Services.GetRequiredService<DownloadService>();
        var cut = Context.RenderComponent<BootstrapBlazorRoot>(pb =>
        {
            pb.AddChildContent<Button>(pb =>
            {
                pb.Add(a => a.OnClick, async () =>
                {
                    await downloadService.DownloadAsync("test.txt", new byte[] { 0x01, 0x02 });
                    download = true;
                });
            });
        });
        var btn = cut.Find("button");
        await cut.InvokeAsync(() => btn.Click());
        Assert.True(download);
    }
}
