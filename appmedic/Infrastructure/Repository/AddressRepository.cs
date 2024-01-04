using appmedic.Domain.Entities;
using appmedic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace appmedic.Infrastructure.Repository;

public class AddressRepository
{
    private readonly DataContext _dataContext;
    private readonly HttpClient _httpClient;

    public AddressRepository(DataContext dataContext, HttpClient httpClient)
    {
        _dataContext = dataContext;
        _httpClient = httpClient;
    }

    public async Task<Address?> ShowAddress(string cep)
    {
        var response = await _httpClient.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
        var address = JsonConvert.DeserializeObject<Address>(response);
        return address;
    }
    
    public async Task<Address?> CreateCep(string cep)
    {
        var addressViaCep = await ShowAddress(cep);
        await _dataContext.Address.AddAsync(addressViaCep!);
        await _dataContext.SaveChangesAsync();
        return addressViaCep;
    }
    
    public async Task<List<Address>> Index()
    {
        var address = await _dataContext.Address.ToListAsync();
        return address;
    }
}