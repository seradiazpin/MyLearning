# .NET MVC

## Security

For encoding html you should use [this](https://msdn.microsoft.com/en-us/library/a2a4yykt(v=vs.100).aspx)

``` c#
public string Encode(string parameter1, int parameter2) {
     return HttpUtility.HtmlEncode("Hello " + parameter1 + ", NumTimes is: " + parameter2);
}
```

## Model Binding
[Source](http://odetocode.com/Blogs/scott/archive/2009/04/27/6-tips-for-asp-net-mvc-model-binding.aspx)
###  Prefer Binding Over Request.Form
To get the parameters of a request

``` c#
public ActionResult Create(FormCollection values)
{
    Recipe recipe = new Recipe();
    recipe.Name = values["Name"];      

    // ...

    return View();
}
```

to do the same thing matching the parameter name with the Object data
``` c#
[AcceptVerbs(HttpVerbs.Post)]
public ActionResult Create(Recipe newRecipe)
{            
    // ...

    return View();
}
```
