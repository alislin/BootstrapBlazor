// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace UnitTest.Components;

public class ListViewTest : BootstrapBlazorTestBase
{
    [Fact]
    public void ListView_Ok()
    {
        var items = Enumerable.Range(1, 6).Select(i => new Product()
        {
            ImageUrl = $"images/Pic{i}.jpg",
            Description = $"Pic{i}.jpg",
            Category = $"Group{(i % 4) + 1}"
        });
        var cut = Context.RenderComponent<ListView<Product>>(pb =>
        {
            pb.Add(a => a.Items, items);
            pb.Add(a => a.HeaderTemplate, builder => builder.AddContent(0, "Test-Header"));
            pb.Add(a => a.BodyTemplate, p => builder => builder.AddContent(0, $"{p.ImageUrl}-{p.Description}-{p.Category}"));
            pb.Add(a => a.FooterTemplate, builder => builder.AddContent(0, "Footer-Header"));
        });
        cut.Contains("Test-Header");
        cut.Contains("Footer-Header");
        cut.Contains("images/Pic1.jpg");
    }


    private class Product
    {
        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }
    }
}
