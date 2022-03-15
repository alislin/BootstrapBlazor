// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Shared;

namespace UnitTest.Components;

public class CascaderTest : BootstrapBlazorTestBase
{
    [Fact]
    public void ValidateForm_OK()
    {
        var foo = new Foo();
        var cut = Context.RenderComponent<ValidateForm>(pb =>
        {
            pb.Add(a => a.Model, foo);
            pb.AddChildContent<Cascader<string>>(pb =>
            {
                pb.Add(a => a.DisplayText, "Test_DisplayText");
                pb.Add(a => a.ShowLabel, true);
            });
        });
        cut.Contains("Test_DisplayText");
    }
}
