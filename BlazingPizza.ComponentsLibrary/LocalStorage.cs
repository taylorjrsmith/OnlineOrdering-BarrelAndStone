// Decompiled with JetBrains decompiler
// Type: BlazingPizza.ComponentsLibrary.LocalStorage
// Assembly: BlazingPizza.ComponentsLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9F0B2C41-5A2F-4E20-B33D-F6EB8A38E2FF
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\BlazingPizza.ComponentsLibrary.dll

using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazingPizza.ComponentsLibrary
{
  public static class LocalStorage
  {
    public static ValueTask<T> GetAsync<T>(IJSRuntime jsRuntime, string key) => jsRuntime.InvokeAsync<T>("blazorLocalStorage.get", (object) key);

    public static ValueTask SetAsync(IJSRuntime jsRuntime, string key, object value) => jsRuntime.InvokeVoidAsync("blazorLocalStorage.set", (object) key, value);

    public static ValueTask DeleteAsync(IJSRuntime jsRuntime, string key) => jsRuntime.InvokeVoidAsync("blazorLocalStorage.delete", (object) key);
  }
}
