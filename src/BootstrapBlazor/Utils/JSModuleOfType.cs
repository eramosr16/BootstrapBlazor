﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Components;

/// <summary>
/// 模块加载器
/// </summary>
/// <typeparam name="TCom"></typeparam>
public class JSModule<TCom> : JSModule where TCom : class
{
    /// <summary>
    /// DotNetReference 实例
    /// </summary>
    protected DotNetObjectReference<TCom> DotNetReference { get; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="jSObjectReference"></param>
    /// <param name="value"></param>
    public JSModule(IJSObjectReference? jSObjectReference, TCom value) : base(jSObjectReference)
    {
        DotNetReference = DotNetObjectReference.Create(value);
    }

    /// <summary>
    /// InvokeVoidAsync 方法
    /// </summary>
    /// <param name="identifier"></param>
    /// <param name="element"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public override async ValueTask InvokeVoidAsync(string identifier, ElementReference element, CancellationToken cancellationToken = default, params object?[]? args)
    {
#if NET5_0
        var paras = new List<object>();
#else
        var paras = new List<object?>();
#endif
        paras.Add(element);
        paras.Add(DotNetReference);
        if (args != null)
        {
            paras.AddRange(args!);
        }
        await InvokeVoidAsync();

        [ExcludeFromCodeCoverage]
        async ValueTask InvokeVoidAsync()
        {
            try
            {
                await Module.InvokeVoidAsync(identifier, cancellationToken, paras.ToArray());
            }
#if NET6_0_OR_GREATER
            catch (JSDisconnectedException) { }
#endif
            catch (JSException) { }
            catch (AggregateException) { }
            catch (InvalidOperationException) { }
            catch (TaskCanceledException) { }
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override async ValueTask<TValue> InvokeAsync<TValue>(string identifier, ElementReference element, CancellationToken cancellationToken = default, params object?[]? args)
    {
#if NET5_0
        var paras = new List<object>();
#else
        var paras = new List<object?>();
#endif
        paras.Add(element);
        paras.Add(DotNetReference);
        if (args != null)
        {
            paras.AddRange(args!);
        }

        return await InvokeAsync();

        [ExcludeFromCodeCoverage]
        async ValueTask<TValue> InvokeAsync()
        {
            TValue ret = default!;
            try
            {
                ret = await Module.InvokeAsync<TValue>(identifier, cancellationToken, paras.ToArray());
            }
#if NET6_0_OR_GREATER
            catch (JSDisconnectedException) { }
#endif
            catch (JSException) { }
            catch (AggregateException) { }
            catch (InvalidOperationException) { }
            catch (TaskCanceledException) { }

            return ret;
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override async ValueTask InvokeVoidAsync(string identifier, string? id, CancellationToken cancellationToken = default, params object?[]? args)
    {
#if NET5_0
        var paras = new List<object>();
#else
        var paras = new List<object?>();
#endif
        if (!string.IsNullOrEmpty(id))
        {
            paras.Add($"#{id}");
        }
        paras.Add(DotNetReference);
        if (args != null)
        {
            paras.AddRange(args!);
        }

        await InvokeVoidAsync();

        [ExcludeFromCodeCoverage]
        async ValueTask InvokeVoidAsync()
        {
            try
            {
                await Module.InvokeVoidAsync(identifier, cancellationToken, paras.ToArray());
            }
#if NET6_0_OR_GREATER
            catch (JSDisconnectedException) { }
#endif
            catch (JSException) { }
            catch (AggregateException) { }
            catch (InvalidOperationException) { }
            catch (TaskCanceledException) { }
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override async ValueTask<TValue> InvokeAsync<TValue>(string identifier, string? id, CancellationToken cancellationToken = default, params object?[]? args)
    {
#if NET5_0
        var paras = new List<object>();
#else
        var paras = new List<object?>();
#endif
        if (!string.IsNullOrEmpty(id))
        {
            paras.Add($"#{id}");
        }
        paras.Add(DotNetReference);
        if (args != null)
        {
            paras.AddRange(args!);
        }

        return await InvokeAsync();

        [ExcludeFromCodeCoverage]
        async ValueTask<TValue> InvokeAsync()
        {
            TValue ret = default!;
            try
            {
                ret = await Module.InvokeAsync<TValue>(identifier, cancellationToken, paras.ToArray());
            }
#if NET6_0_OR_GREATER
            catch (JSDisconnectedException) { }
#endif
            catch (JSException) { }
            catch (AggregateException) { }
            catch (InvalidOperationException) { }
            catch (TaskCanceledException) { }

            return ret;
        }
    }

    /// <summary>
    /// Dispose 方法
    /// </summary>
    /// <param name="disposing"></param>
    protected override ValueTask DisposeAsyncCore(bool disposing)
    {
        if (disposing)
        {
            DotNetReference.Dispose();
        }
        return base.DisposeAsyncCore(disposing);
    }
}