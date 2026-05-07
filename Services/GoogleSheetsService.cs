using System.Text;
using System.Text.Json;
using FinalProject.Models;

namespace FinalProject.Services;

public class GoogleSheetsService
{
    private const string WebAppUrl = "https://script.google.com/macros/s/AKfycbxvISPBT4l1d5AD3VqVBs9wBAg8b_q3F_Ug3iGXWW7GtIPAVea5YSGXGHbWSqjVEMo3/exec";
    private readonly HttpClient client = new HttpClient();

    public async Task AddEntry(ZodiacReading reading)
    {
        if (WebAppUrl.Contains("PASTE_YOUR"))
        {
            await Task.Delay(300);
            return;
        }

        var json = JsonSerializer.Serialize(reading);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await client.PostAsync(WebAppUrl, content);
    }

    public async Task<List<ZodiacReading>> GetEntries()
    {
        if (WebAppUrl.Contains("PASTE_YOUR"))
        {
            await Task.Delay(300);
            return new List<ZodiacReading>
            {
                new ZodiacReading { name = "Jordan", birthdate = "08/10/2005", zodiac = "Leo" },
                new ZodiacReading { name = "Alex", birthdate = "03/12/2004", zodiac = "Pisces" },
                new ZodiacReading { name = "Maya", birthdate = "10/22/2005", zodiac = "Libra" }
            };
        }

        var response = await client.GetStringAsync(WebAppUrl);
        var readings = JsonSerializer.Deserialize<List<ZodiacReading>>(response);
        return readings ?? new List<ZodiacReading>();
    }
}
