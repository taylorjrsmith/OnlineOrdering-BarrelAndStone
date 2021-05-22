using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public static class JSRuntimeExtensions
    {
        public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);
        }

        public static ValueTask<string> Prompt(this IJSRuntime jSRuntime, string message)
        {
            return jSRuntime.InvokeAsync<string>("prompt", message);
        }

        public static ValueTask<string> GetLocalStorageValue(this IJSRuntime jSRuntime, string key)
        {
            return jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public static void SetLocalStorageValue(this IJSRuntime jSRuntime, string key, string value)
        {
             jSRuntime.InvokeAsync<string>("localStorage.setItem", key,value);
        }

        public static void Authorise(this IJSRuntime jSRuntime, ref string password, ref bool isAuthorised)
        {
            if (jSRuntime.GetLocalStorageValue("kitchenPassword").Result == "BetterThanDominos")
            {
                password = "BetterThanDominos";
                isAuthorised = true;
            }
            if (!isAuthorised)
                password = jSRuntime.Prompt("Please type the kitchen password").Result;
            if (password == "BetterThanDominos")
            {
                isAuthorised = true;
            }
        }
    }

}
