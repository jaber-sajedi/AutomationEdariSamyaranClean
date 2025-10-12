using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private const string BaseUrl = "https://localhost:7132/api/";

        // تنظیمات مشترک برای JSON
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = false
        };

        public ApiService(string baseUrl)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/")
            };
        }
        /// <summary>
        /// فراخوانی متد GET از API
        /// </summary>
        public async Task<T?> GetAsync<T>(string endpoint)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
                throw new ArgumentException("Endpoint نمی‌تواند خالی باشد.", nameof(endpoint));

            try
            {
                var response = await _client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, JsonOptions);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"❌ خطا در ارتباط با API: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"❌ خطا در تبدیل داده‌های JSON از پاسخ API: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ خطای ناشناخته در فراخوانی API ({endpoint}): {ex.Message}", ex);
            }
        }

        /// <summary>
        /// فراخوانی متد POST از API
        /// </summary>
        public async Task<TResult?> PostAsync<TRequest, TResult>(string endpoint, TRequest data)
        {
            if (string.IsNullOrWhiteSpace(endpoint))
                throw new ArgumentException("Endpoint نمی‌تواند خالی باشد.", nameof(endpoint));

            try
            {
                var json = JsonSerializer.Serialize(data, JsonOptions);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<TResult>(responseContent, JsonOptions);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"❌ خطا در ارسال درخواست به API: {ex.Message}", ex);
            }
            catch (JsonException ex)
            {
                throw new Exception($"❌ خطا در پردازش JSON هنگام ارسال یا دریافت داده: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"❌ خطای ناشناخته در متد POST ({endpoint}): {ex.Message}", ex);
            }
        }
    }
}
