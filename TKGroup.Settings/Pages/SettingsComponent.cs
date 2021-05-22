// Decompiled with JetBrains decompiler
// Type: TKGroup.Settings.Pages.SettingsComponent
// Assembly: TKGroup.Settings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 79403CED-C884-4CB1-AB39-2C4088B9D379
// Assembly location: C:\Users\Taylor\Downloads\wwwroot (1)\TKGroup.Settings.dll

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TKGroup.Settings.Pages
{
  public class SettingsComponent : ComponentBase
  {
    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      if (this.Settings == null)
        return;
      __builder.AddContent(0, "    ");
      __builder.OpenElement(1, "table");
      __builder.AddAttribute(2, "class", "table");
      __builder.AddMarkupContent(3, "\r\n        ");
      __builder.AddMarkupContent(4, "<tr>\r\n            <th>Key</th>\r\n            <th>Value</th>\r\n            <th>Description</th>\r\n            <th>Options</th>\r\n        </tr>\r\n");
      foreach (Setting setting1 in this.Settings)
      {
        Setting setting = setting1;
        __builder.AddContent(5, "            ");
        __builder.OpenElement(6, "tr");
        __builder.AddMarkupContent(7, "\r\n                ");
        __builder.OpenElement(8, "td");
        __builder.AddMarkupContent(9, "\r\n                   ");
        __builder.OpenElement(10, "input");
        __builder.AddAttribute(11, "class", "form-control");
        __builder.AddAttribute(12, "value", BindConverter.FormatValue(setting.Key));
        __builder.AddAttribute<ChangeEventArgs>(13, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => setting.Key = __value), setting.Key));
        __builder.SetUpdatesAttributeName("value");
        __builder.CloseElement();
        __builder.AddMarkupContent(14, "\r\n                ");
        __builder.CloseElement();
        __builder.AddMarkupContent(15, "\r\n                ");
        __builder.OpenElement(16, "td");
        __builder.AddMarkupContent(17, "\r\n                   ");
        __builder.OpenElement(18, "input");
        __builder.AddAttribute(19, "class", "form-control");
        __builder.AddAttribute(20, "value", BindConverter.FormatValue(setting.Value));
        __builder.AddAttribute<ChangeEventArgs>(21, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => setting.Value = __value), setting.Value));
        __builder.SetUpdatesAttributeName("value");
        __builder.CloseElement();
        __builder.AddMarkupContent(22, "\r\n                ");
        __builder.CloseElement();
        __builder.AddMarkupContent(23, "\r\n                ");
        __builder.OpenElement(24, "td");
        __builder.AddMarkupContent(25, "\r\n                    ");
        __builder.OpenElement(26, "input");
        __builder.AddAttribute(27, "class", "form-control");
        __builder.AddAttribute(28, "value", BindConverter.FormatValue(setting.Description));
        __builder.AddAttribute<ChangeEventArgs>(29, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => setting.Description = __value), setting.Description));
        __builder.SetUpdatesAttributeName("value");
        __builder.CloseElement();
        __builder.AddMarkupContent(30, "\r\n                ");
        __builder.CloseElement();
        __builder.AddMarkupContent(31, "\r\n                ");
        __builder.OpenElement(32, "td");
        __builder.AddMarkupContent(33, "\r\n                    ");
        __builder.OpenElement(34, "button");
        __builder.AddAttribute(35, "class", "btn btn-success");
        __builder.AddAttribute<MouseEventArgs>(36, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.UpdateSetting(setting))));
        __builder.AddContent(37, "Update");
        __builder.CloseElement();
        __builder.AddMarkupContent(38, "\r\n                ");
        __builder.CloseElement();
        __builder.AddMarkupContent(39, "\r\n            ");
        __builder.CloseElement();
        __builder.AddMarkupContent(40, "\r\n");
      }
      __builder.AddContent(41, "        ");
      __builder.OpenElement(42, "tr");
      __builder.AddMarkupContent(43, "\r\n            ");
      __builder.OpenElement(44, "td");
      __builder.OpenElement(45, "input");
      __builder.AddAttribute(46, "class", "form-control");
      __builder.AddAttribute(47, "value", BindConverter.FormatValue(this.NewSetting.Key));
      __builder.AddAttribute<ChangeEventArgs>(48, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.NewSetting.Key = __value), this.NewSetting.Key));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(49, "\r\n            ");
      __builder.OpenElement(50, "td");
      __builder.OpenElement(51, "input");
      __builder.AddAttribute(52, "class", "form-control");
      __builder.AddAttribute(53, "value", BindConverter.FormatValue(this.NewSetting.Value));
      __builder.AddAttribute<ChangeEventArgs>(54, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.NewSetting.Value = __value), this.NewSetting.Value));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(55, "\r\n            ");
      __builder.OpenElement(56, "td");
      __builder.OpenElement(57, "input");
      __builder.AddAttribute(58, "class", "form-control");
      __builder.AddAttribute(59, "value", BindConverter.FormatValue(this.NewSetting.Description));
      __builder.AddAttribute<ChangeEventArgs>(60, "onchange", EventCallback.Factory.CreateBinder((object) this, (Action<string>) (__value => this.NewSetting.Description = __value), this.NewSetting.Description));
      __builder.SetUpdatesAttributeName("value");
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(61, "\r\n            ");
      __builder.OpenElement(62, "td");
      __builder.OpenElement(63, "button");
      __builder.AddAttribute(64, "class", "btn btn-success");
      __builder.AddAttribute<MouseEventArgs>(65, "onclick", EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.AddNewSetting())));
      __builder.AddContent(66, "Add setting");
      __builder.CloseElement();
      __builder.CloseElement();
      __builder.AddMarkupContent(67, "\r\n        ");
      __builder.CloseElement();
      __builder.AddMarkupContent(68, "\r\n    ");
      __builder.CloseElement();
      __builder.AddMarkupContent(69, "\r\n");
    }

    private Setting NewSetting { get; set; } = new Setting();

    [Parameter]
    public List<Setting> Settings { get; set; }

    [Parameter]
    public EventCallback OptionalClear { get; set; }

    public async Task AddNewSetting()
    {
      await this.settingsService.AddSetting(this.NewSetting);
      this.Settings.Add(this.NewSetting);
      this.NewSetting = new Setting();
    }

    public async Task UpdateSetting(Setting setting) => await this.settingsService.UpdateSetting(setting);

    [Inject]
    private ISettingService settingsService { get; set; }
  }
}
