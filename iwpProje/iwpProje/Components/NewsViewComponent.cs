using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using iwpProje.Services;

public class NewsViewComponent : ViewComponent
{
    private readonly NewsService _newsService;

    public NewsViewComponent(NewsService newsService)
    {
        _newsService = newsService;
    }

    
    public async Task<IViewComponentResult> InvokeAsync(int count = 5)
    {
        var news = await _newsService.GetLatestNewsAsync(count);
        return View(news); 
    }
}
