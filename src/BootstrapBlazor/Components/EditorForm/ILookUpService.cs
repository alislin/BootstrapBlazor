// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System.Collections.Generic;

namespace BootstrapBlazor.Components
{
    /// <summary>
    /// 获取Select的Items的接口
    /// </summary>
    public interface ILookUpService
    {
        /// <summary>
        /// 根据分类获取列表
        /// </summary>
        IEnumerable<SelectedItem>? GetLookUpByCatalog(string Catalog);
    }

    /// <summary>
    /// 内部默认字典服务实现类
    /// </summary>
    internal class NullLookUpService : ILookUpService
    {
        public IEnumerable<SelectedItem>? GetLookUpByCatalog(string Catalog)
        {
            throw new System.NotImplementedException();
        }
    }
}
