# QingCheng.AspNetCore.Authentication.Cookies
修改的Microsoft.AspNetCore.Authentication.Cookies包，增加在cookie验证模式下。ajax请求返回状态码而不是直接跳转页面



在http请求中。官方库只实现了XMLHttpRequest判断。

本库新增 content-type和accept包含json。认证失败不跳转。认证失败返回401，授权失败返回403. 方便spa程序使用。



使用方式和Microsoft.AspNetCore.Authentication.Cookies方式基本一样。

只需要从AddCookie改为AddCookieX

``` c#
 services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookieX(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
               {

               });
```

其余的配置都参考官方库。

