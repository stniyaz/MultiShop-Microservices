using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.ProductDtos;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.V0 = "Products";
        ViewBag.V1 = "Home";

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7001/api/products/");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        return View();
    }

    public async Task<IActionResult> Create()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7001/api/categories/");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            ViewBag.Categories = values.ToList();
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:7001/api/categories/");
        if (responseMessage1.IsSuccessStatusCode)
        {
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);

            ViewBag.Categories = values.ToList();
        }

        var client2 = _httpClientFactory.CreateClient();
        var jsonData2 = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData2, Encoding.UTF8, "application/json");
        var responseMessage2 = await client2.PostAsync("https://localhost:7001/api/products/", content);
        if (responseMessage2.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "admin" });
        }

        return View();
    }

    public async Task<IActionResult> Update(string id)
    {
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:7001/api/categories/");
        if (responseMessage1.IsSuccessStatusCode)
        {
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);

            ViewBag.Categories = values1.ToList();
        }

        var client2 = _httpClientFactory.CreateClient();
        var responseMessage = await client1.GetAsync("https://localhost:7001/api/products/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            return View(values);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:7001/api/categories/");
        if (responseMessage1.IsSuccessStatusCode)
        {
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);

            ViewBag.Categories = values1.ToList();
        }

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7001/api/products/", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "admin" });
        }
        return View();
    }

    public async Task<IActionResult> Delete(string id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync("https://localhost:7001/api/products?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "product", new { area = "admin" });
        }
        return NotFound();
    }
}
