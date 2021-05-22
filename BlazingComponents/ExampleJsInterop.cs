// Decompiled with JetBrains decompiler
// Type: BlazingComponents.ExampleJsInterop
// Assembly: BlazingComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4684B8FA-B58F-4126-BBBD-AB15B32CB405
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\BlazingComponents.dll

using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazingComponents
{
  public class ExampleJsInterop
  {
    public static ValueTask<string> Prompt(IJSRuntime jsRuntime, string message) => jsRuntime.InvokeAsync<string>("exampleJsFunctions.showPrompt", (object) message);
  }
}
