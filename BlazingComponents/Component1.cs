// Decompiled with JetBrains decompiler
// Type: BlazingComponents.Component1
// Assembly: BlazingComponents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4684B8FA-B58F-4126-BBBD-AB15B32CB405
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\BlazingComponents.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazingComponents
{
  public class Component1 : ComponentBase
  {
    protected override void BuildRenderTree(RenderTreeBuilder __builder) => __builder.AddMarkupContent(0, "<div class=\"my-component\">\r\n    This Blazor component is defined in the <strong>BlazingComponents</strong> package.\r\n</div>");
  }
}
