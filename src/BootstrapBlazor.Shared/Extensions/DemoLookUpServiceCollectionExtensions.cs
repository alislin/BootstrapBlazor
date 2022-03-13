// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using BootstrapBlazor.Shared.Components;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// BootstrapBlazor 服务扩展类
    /// </summary>
    public static class DemoLookUpServiceCollectionExtensions
    {
        /// <summary>
        /// 增加 演示数据库操作服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDemoLookUpService(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILookUpService), typeof(DemoLookUpService));
            return services;
        }
    }

    /// <summary>
    /// 演示网站示例数据注入服务实现类
    /// </summary>
    internal class DemoLookUpService : ILookUpService
    {

        //private IStringLocalizer<TModel> Localizer { get; set; }
        public IEnumerable<SelectedItem>? GetLookUpByCatalog(string Catalog)
        {
            if(Catalog=="user_sex")
            {
                return new List<SelectedItem>()
                {
                    new SelectedItem(){ Value="0",Text="未知"},
                    new SelectedItem(){ Value="1",Text="男"},
                    new SelectedItem(){ Value="2",Text="女"},
                };
            }
            if (Catalog == "show_hide")
            {
                return new List<SelectedItem>()
                {
                    new SelectedItem(){ Value="0",Text="显示"},
                    new SelectedItem(){ Value="1",Text="隐藏"},
                };
            }
            return null;
        }
    }
}
