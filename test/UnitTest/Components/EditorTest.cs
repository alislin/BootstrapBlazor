// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Shared;

namespace UnitTest.Components;

public class EditorTest : BootstrapBlazorTestBase
{
    [Fact]
    public async Task Editor_Ok()
    {
        var value = new Foo();
        var cut = Context.RenderComponent<Editor>(pb =>
        {
            pb.Add(a => a.Value, value.Name);
            pb.Add(a => a.ValueChanged, v => value.Name = v);
            pb.Add(a => a.IsEditor, false);
            pb.Add(a => a.Height, 200);
        });

        await cut.InvokeAsync(() => cut.Instance.Update("Test"));
        Assert.Equal("Test", value.Name);

        cut.SetParametersAndRender(pb =>
        {
            pb.Add(a => a.OnValueChanged, v =>
            {
                value.Name = v;
                return Task.CompletedTask;
            });
        });

        await cut.InvokeAsync(() => cut.Instance.Update("Test1"));
        Assert.Equal("Test1", value.Name);
    }
}
