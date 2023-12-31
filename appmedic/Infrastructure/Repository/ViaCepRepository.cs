using appmedic.Domain.Entities;
using Newtonsoft.Json;

namespace appmedic.Infrastructure.Repository;

public class ViaCepRepository
{
    private readonly HttpClient _httpClient;

    public ViaCepRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ViaCep?> ShowAddress(string cep)
    {
        var response = await _httpClient.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
        var address = JsonConvert.DeserializeObject<ViaCep>(response);
        return address;
    }
}