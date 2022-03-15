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

    [Fact]
    public void Color_Ok()
    {
        var cut = Context.RenderComponent<Cascader<string>>(pb =>
        {
            pb.Add(a => a.Color, Color.Success);
        });
        cut.Contains("border-success");
    }

    [Fact]
    public async Task Items_Ok()
    {
        var value = "";
        var selectedItems = new List<CascaderItem>();
        var items = new List<CascaderItem>()
        {
            new() { Text = "Test1", Value = "1" },
            new() { Text = "Test2", Value = "2" }
        };
        items[1].AddItem(new() { Text = "Test11", Value = "11" });
        items[1].AddItem(new() { Text = "Test12", Value = "12" });

        items[1].Items.ElementAt(1).AddItem(new() { Text = "Test111", Value = "111" });

        var cut = Context.RenderComponent<Cascader<string>>(pb =>
        {
            pb.Add(a => a.Items, items);
            pb.Add(a => a.Value, value);
            pb.Add(a => a.OnValueChanged, v =>
            {
                value = v;
                return Task.CompletedTask;
            });
            pb.Add(a => a.OnSelectedItemChanged, items =>
            {
                selectedItems.AddRange(items);
                return Task.CompletedTask;
            });
        });

        var dropdownItems = cut.FindAll(".dropdown-item");
        await cut.InvokeAsync(() => dropdownItems[1].Click());
        Assert.Equal("2", value);
        Assert.Single(selectedItems);

        dropdownItems = cut.FindAll(".dropdown-item");
        await cut.InvokeAsync(() => dropdownItems[0].Click());
        Assert.Equal("1", value);

        // nav-link
        var linkItems = cut.FindAll(".nav-link");
        await cut.InvokeAsync(() => linkItems[0].Click());
        Assert.Equal("11", value);

        linkItems = cut.FindAll(".nav-link");
        await cut.InvokeAsync(() => linkItems[1].Click());
        Assert.Equal("12", value);
    }
}
