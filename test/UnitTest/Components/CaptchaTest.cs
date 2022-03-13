// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace UnitTest.Components;
public class CaptchaTest : BootstrapBlazorTestBase
{
    [Fact]
    public async Task Verify_Ok()
    {
        var verify = false;
        var cut = Context.RenderComponent<Captcha>(pb =>
        {
            pb.Add(a => a.Offset, 1000);
            pb.Add(a => a.OnValid, b =>
            {
                verify = b;
            });
        });
        await cut.InvokeAsync(() => cut.Instance.Verify(10, new int[] { 1, 2, 3, 4, 1 }));
        Assert.True(verify);
    }

    [Fact]
    public async Task Reset_Ok()
    {
        var cut = Context.RenderComponent<Captcha>(pb =>
        {
            pb.Add(a => a.GetImageName, () => "test.jpg");
        });
        await cut.InvokeAsync(() => cut.Find(".captcha-refresh").Click());
    }
}
