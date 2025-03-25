using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.V0 = "Categories";
        ViewBag.V1 = "Home";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7001/api/categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();

    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createCategoryDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7001/api/categories", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7001/api/categories?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "category", new { area = "admin" });
        }
        return NotFound();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7001/api/categories/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
            return View(values);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7001/api/categories/", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "category", new { area = "admin" });
        }

        return View();
    }
}