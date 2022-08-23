using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FluentValidation.Results;
using System.Reflection;

namespace Frontend.Pages;

public class CategoriesModel : PageModel
{
    public List<Category> CategoriesRes { get; set; } = new();
    public List<string> Messages = new();

    public async Task OnGet(List<string> msgs)
    {
        Categories categories = await Requests.ListCategories();
        foreach (Category cat in categories.CategoriesList)
            CategoriesRes.Add(cat);
        Messages = msgs;
    }

    public async Task<IActionResult> OnPostCreate(string categoryName)
    {
        bool valid = !(String.IsNullOrEmpty(categoryName));
        if (valid)
            _ = await Requests.CreateCategory(categoryName.Trim());
        else
        {
            List<string> msgs = new();
            msgs.Add(
                $"Please enter category name!"
            );
            Messages = msgs;
        }
        return RedirectToPage("./Categories", new { msgs = Messages });
    }

    public async Task<IActionResult> OnPostUpdate(string id, string categoryName)
    {
        bool valid = !(String.IsNullOrEmpty(categoryName));
        if (valid)
            _ = await Requests.UpdateCategory(new Guid(id), categoryName);
        else
        {
            List<string> msgs = new();
            msgs.Add(
                $"Category name can not be empty!"
            );
            Messages = msgs;
        }
        return RedirectToPage("./Categories", new { msgs = Messages });
    }

    public async Task<IActionResult> OnPostDelete(Guid id)
    {
        await Requests.DeleteCategory(id);
        return RedirectToPage("./Categories", new { msgs = Messages });
    }
}
