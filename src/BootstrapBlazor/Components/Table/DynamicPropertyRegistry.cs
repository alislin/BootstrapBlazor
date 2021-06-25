﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components
{
    /// <summary>
    /// 动态属性注册中心
    /// </summary>
    public class DynamicPropertyRegistry
    {
        private static Dictionary<string, List<PropertyInfo>> typePropDic = new();
        private static Dictionary<string, AutoGenerateClassAttribute> classAttrDic = new();
        private static Dictionary<Type, string> typeKeyDic = new();

        #region 注册
        /// <summary>
        /// 给指定类型，添加动态属性
        /// </summary>
        /// <param name="typeKey"></param>
        /// <param name="info"></param>

        public static void AddProperty(string typeKey, PropertyInfo info)
        {
            if (!typePropDic.ContainsKey(typeKey))
            {
                typePropDic[typeKey] = new List<PropertyInfo>();
            }
            typePropDic[typeKey].Add(info);
        }

        /// <summary>
        /// 给指定类型，删除动态属性
        /// </summary>
        /// <param name="type"></param>
        /// <param name="info"></param>
        public static void RemoveProperty(string typeKey, PropertyInfo info)
        {
            if (!typePropDic.ContainsKey(typeKey))
            {
                return;
            }
            typePropDic[typeKey].Remove(info);
        }
        /// <summary>
        /// 注册 AutoGenerateClassAttribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="info"></param>
        public static void AddAutoGenerateClassAttribute(string typeKey, AutoGenerateClassAttribute info)
        {
            classAttrDic[typeKey] = info;
        }
        #endregion

        #region 使用
        /// <summary>
        /// 获取指定了类型的所有属性信息
        /// </summary>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(string typeKey)
        {
            return typePropDic[typeKey].ToArray();
        }
        /// <summary>
        /// 获取类型上面的 AutoGenerateClassAttribute
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static AutoGenerateClassAttribute GetTypeAttribute(string typeKey)
        {
            return classAttrDic[typeKey];
        }

        /// <summary>
        /// 注册类型的 字符串唯一标识
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeKey"></param>
        public static void RegistTypeKey(Type type, string typeKey)
        {
            typeKeyDic[type] = typeKey;
        }

        public static string GetTypeKey(Type type)
        {
            return typeKeyDic[type];
        }
        #endregion

    }

    /// <summary>
    /// 编辑的时候，会调用Clone方法，设置临时对象
    /// </summary>
    public interface IDynamicType : ICloneable
    {
        /// <summary>
        /// 根据属性名称，获取属性值
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        object? GetValue(string propName);
        /// <summary>
        /// 根据属性名称，设置属性值
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="value"></param>
        void SetValue(string propName, object value);
        /// <summary>
        /// 从另一个动态类型拷贝属性值到当前对象上
        /// </summary>
        /// <param name="other"></param>
        void CopyFrom(IDynamicType other);

        string GetTypeKey();
    }

    /// <summary>
    /// 动态属性信息
    /// </summary>
    public class DynamicPropertyInfo : PropertyInfo
    {
        /// <summary>
        /// 构造动态属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="propType"></param>
        /// <param name="attributes"></param>
        public DynamicPropertyInfo(string name, Type propType, Attribute[] attributes)
        {
            this.name = name;
            this.propertyType = propType;
            this.attributes = attributes;
        }
        public override PropertyAttributes Attributes => PropertyAttributes.None;

        public override bool CanRead => true;

        public override bool CanWrite => true;

        private Type propertyType;
        public override Type PropertyType => propertyType;

        public override Type? DeclaringType => throw new NotImplementedException();


        private string name;
        public override string Name => name;

        public override Type? ReflectedType => throw new NotImplementedException();

        public override MethodInfo[] GetAccessors(bool nonPublic)
        {
            return null;
        }

        private object[] attributes;
        public override object[] GetCustomAttributes(bool inherit)
        {
            return attributes;
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return attributes;
        }

        public override MethodInfo? GetGetMethod(bool nonPublic)
        {
            return null;
        }

        public static ParameterInfo[] parameterInfos = Array.Empty<ParameterInfo>();


        public override ParameterInfo[] GetIndexParameters()
        {
            return parameterInfos;
        }

        public override MethodInfo? GetSetMethod(bool nonPublic)
        {
            return null;
        }

        public override object? GetValue(object? obj, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture)
        {
            return null;
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            return false;
        }

        public override void SetValue(object? obj, object? value, BindingFlags invokeAttr, Binder? binder, object?[]? index, CultureInfo? culture)
        {

        }
    }
}
