#pragma checksum "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c22f840a14662cc020af70423a56dc040733197e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BibliotecaXPTO_WebApp.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace BibliotecaXPTO_WebApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\_ViewImports.cshtml"
using BibliotecaXPTO_WebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c22f840a14662cc020af70423a56dc040733197e", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dd9f95195050a99202df089e0b6e034425624ae", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("login-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("login-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("register-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("register-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
  
    ViewData["Title"] = "Bem-vindo!";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
  
    if (Model.Prm == 0) /*Login Form*/
    {
        Layout = "_Login";


#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c22f840a14662cc020af70423a56dc040733197e6132", async() => {
                WriteLiteral("\r\n\r\n            <div class=\"form-group mb-3\">\r\n                <label for=\"email-login\">Email</label>\r\n                <input id=\"email-login\" name=\"email-login\" type=\"email\"");
                BeginWriteAttribute("required", " required=\"", 418, "\"", 429, 0);
                EndWriteAttribute();
                BeginWriteAttribute("autofocus", " autofocus=\"", 430, "\"", 442, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control rounded-pill border-0 shadow-sm px-4\">\r\n            </div>\r\n");
#nullable restore
#line 19 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
             if (!string.IsNullOrEmpty(Model.ExceptionMessage))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"alert alert-danger alert-dismissible\">\r\n                    <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n                    <span>");
#nullable restore
#line 22 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
                     Write(Model.ExceptionMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                </div>\r\n");
#nullable restore
#line 24 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"form-group mb-3\">\r\n                <label for=\"psw-login\">Palavra-passe</label>\r\n                <input id=\"psw-login\" name=\"psw-login\" type=\"password\"");
                BeginWriteAttribute("required", " required=\"", 1025, "\"", 1036, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control rounded-pill border-0 shadow-sm px-4 text-primary"">
            </div>
            <input name=""prm_post"" type=""hidden"" value=""0"" />
            <button type=""submit"" class=""btn btn-primary btn-block text-uppercase mb-2 rounded-pill shadow-sm"">Iniciar sess??o</button>
            <div class=""text-center d-flex justify-content-between mt-4"">
                <p>
                    Ainda n??o est?? registado? <b><a href=""Index?prm=1"" class=""text-muted"">Criar conta.</a></b>
                </p>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
    }

    if (Model.Prm == 1) /*Register Form*/
    {
        Layout = "_Login";


#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c22f840a14662cc020af70423a56dc040733197e10736", async() => {
                WriteLiteral("\r\n\r\n            <div class=\"form-group mb-3\">\r\n                <label for=\"fname\">Nome</label>\r\n                <input id=\"fname\" name=\"fname\" type=\"text\"");
                BeginWriteAttribute("required", " required=\"", 1936, "\"", 1947, 0);
                EndWriteAttribute();
                BeginWriteAttribute("autofocus", " autofocus=\"", 1948, "\"", 1960, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control rounded-pill border-0 shadow-sm px-4\">\r\n            </div>\r\n            <div class=\"form-group mb-3\">\r\n                <label for=\"lname\">Apelido</label>\r\n                <input id=\"lname\" name=\"lname\" type=\"text\"");
                BeginWriteAttribute("required", " required=\"", 2195, "\"", 2206, 0);
                EndWriteAttribute();
                BeginWriteAttribute("autofocus", " autofocus=\"", 2207, "\"", 2219, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control rounded-pill border-0 shadow-sm px-4"">
            </div>
            <div class=""form-group mb-3"">
                <label for=""email-register"">Email</label>
                <input id=""email-register"" name=""email-register"" type=""email""");
                BeginWriteAttribute("required", " required=\"", 2480, "\"", 2491, 0);
                EndWriteAttribute();
                BeginWriteAttribute("autofocus", " autofocus=\"", 2492, "\"", 2504, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control rounded-pill border-0 shadow-sm px-4"">
            </div>
            <div class=""form-group mb-3"">
                <label for=""library"">N??cleo</label>
                <select id=""library"" name=""library"" class=""form-control rounded-pil border-0 shadow-sm px-4"">
");
#nullable restore
#line 60 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
                      
                        List<BibliotecaXPTO_Lib.Nucleo> nucleos = BibliotecaXPTO_Lib.Operations.ListaNucleos();

                        foreach (BibliotecaXPTO_Lib.Nucleo nucleo in nucleos)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c22f840a14662cc020af70423a56dc040733197e13339", async() => {
#nullable restore
#line 65 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
                                                  Write(nucleo.City);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
                               WriteLiteral(nucleo.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 66 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                </select>\r\n            </div>\r\n            <div class=\"form-group mb-3\">\r\n                <label for=\"psw-register\">Palavra-passe</label>\r\n                <input id=\"psw-register\" name=\"psw-register\" type=\"password\"");
                BeginWriteAttribute("required", " required=\"", 3397, "\"", 3408, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control rounded-pill border-0 shadow-sm px-4 text-primary"">
            </div>
            <div class=""form-group mb-3"">
                <label for=""psw-repeat"">Confirme a palavra-passe</label>
                <input id=""psw-repeat"" name=""psw-repeat"" type=""password""");
                BeginWriteAttribute("required", " required=\"", 3692, "\"", 3703, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control rounded-pill border-0 shadow-sm px-4 text-primary\">\r\n            </div>\r\n");
#nullable restore
#line 78 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
             if (!string.IsNullOrEmpty(Model.ExceptionMessage))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"alert alert-danger alert-dismissible\">\r\n                    <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n                    <span>");
#nullable restore
#line 81 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
                     Write(Model.ExceptionMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                </div>\r\n");
#nullable restore
#line 83 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
             if (!string.IsNullOrEmpty(Model.SuccessMessage))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"alert alert-success\">\r\n\r\n                    <span>");
#nullable restore
#line 87 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
                     Write(Model.SuccessMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral("<a href=\"Index\" class=\"alert-link\">Inicie a sess??o na sua conta.</a></span>\r\n                </div>\r\n");
#nullable restore
#line 89 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <input name=""prm_post"" type=""hidden"" value=""1"" />
            <button type=""submit"" class=""btn btn-primary btn-block text-uppercase mb-2 rounded-pill shadow-sm"">Criar conta</button>
            <div class=""text-center d-flex justify-content-between mt-4"">
                <p>
                    J?? tem uma conta? <b><a href=""Index"" class=""text-muted"">Inicie sess??o.</a></b>
                </p>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 98 "C:\dev\git\booksearch-c#\04_Projeto\01_Projeto_Modulo_03\BibliotecaXPTO_WebApp\Pages\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
