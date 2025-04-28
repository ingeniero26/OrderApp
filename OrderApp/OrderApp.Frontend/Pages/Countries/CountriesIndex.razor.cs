using Microsoft.AspNetCore.Components;
using OrderApp.Frontend.Repositorios;
using OrderApp.Shared.Entities;

namespace OrderApp.Frontend.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<Country>? Countries { get; set; } = new List<Country>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var responseHttp = await Repository.GetAsync<List<Country>>("api/countries");
                Countries = responseHttp.Response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los datos: {ex.Message}");
            }
        }
    }
}
