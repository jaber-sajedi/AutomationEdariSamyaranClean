using AutomationEdariSamyaran.WPF.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;

namespace AutomationEdariSamyaran.WPF.Services
{
    public class RestApiService
    {
        private readonly RestClient _client;

        public RestApiService(string baseUrl = "https://localhost:7132/api/")
        {
            var options = new RestClientOptions(baseUrl)
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };
            _client = new RestClient(options);
        }

        // ================= Helper مدیریت پاسخ =================
        private void HandleResponse(RestResponse response)
        {
            if (response.IsSuccessful) return;

            if ((int)response.StatusCode == 400 && !string.IsNullOrEmpty(response.Content))
            {
                throw new ValidationException($"خطای اعتبارسنجی: {response.Content}");
            }

            throw new Exception($"خطا در اتصال به سرور: {(int)response.StatusCode} - {response.StatusDescription} \n {response.ErrorMessage}");
        }

        private T HandleResponse<T>(RestResponse<T> response)
        {
            if (response.IsSuccessful)
                return response.Data;

            if ((int)response.StatusCode == 400 || (int)response.StatusCode == 500)
            {
                if (!string.IsNullOrEmpty(response.Content))
                {
                    var message = ExtractValidationMessage(response.Content);
                    throw new ValidationException(message);
                }
            }

            throw new Exception($"خطا در اتصال به سرور: {(int)response.StatusCode} - {response.StatusDescription} \n {response.ErrorMessage}");
        }



        // ================= Personal =================
        public async Task<List<PersonalDto>?> GetPersonalsAsync()
        {
            var request = new RestRequest("Personal/list", Method.Get);
            request.AddHeader("Accept", "application/json");
            var response = await _client.ExecuteAsync<List<PersonalDto>>(request);
            return HandleResponse(response);
        }

        public async Task<PersonalDto?> CreatePersonalAsync(CreatePersonalCommand command)
        {
            var request = new RestRequest("Personal/create", Method.Post);
            request.AddJsonBody(command);
            var response = await _client.ExecuteAsync<PersonalDto>(request);
            return HandleResponse(response);
        }

        // ================= Workflow =================
        public async Task<List<WorkflowDto>?> GetWorkflowsAsync()
        {
            var request = new RestRequest("Workflow/list", Method.Get);
            request.AddHeader("Accept", "application/json");
            var response = await _client.ExecuteAsync<List<WorkflowDto>>(request);
            return HandleResponse(response);
        }

        public async Task<WorkflowDto?> CreateWorkflowAsync(CreateWorkflowCommand command)
        {
            var request = new RestRequest("Workflow/create", Method.Post);
            request.AddJsonBody(command);
            var response = await _client.ExecuteAsync<WorkflowDto>(request);
            return HandleResponse(response);
        }

        // ================= WorkflowStep =================
        public async Task<List<WorkflowStepDto>?> GetWorkflowStepsAsync(int workflowId)
        {
            var request = new RestRequest($"WorkflowStep/get-by-workflow/{workflowId}", Method.Get);
            request.AddHeader("Accept", "application/json");
            var response = await _client.ExecuteAsync<List<WorkflowStepDto>>(request);
            return HandleResponse(response);
        }

        public async Task<WorkflowStepDto?> CreateWorkflowStepAsync(CreateWorkflowStepCommand command)
        {
            var request = new RestRequest("WorkflowStep/create", Method.Post);
            request.AddJsonBody(command);
            var response = await _client.ExecuteAsync<WorkflowStepDto>(request);
            return HandleResponse(response);
        }

        // ================= WorkflowInstance =================
        public async Task<WorkflowInstanceDto?> StartWorkflowInstanceAsync(StartWorkflowInstanceCommand command)
        {
            var request = new RestRequest("WorkflowInstance/start", Method.Post);
            request.AddJsonBody(command);
            var response = await _client.ExecuteAsync<WorkflowInstanceDto>(request);
            return HandleResponse(response);
        }

        public async Task<List<WorkflowStepDto>?> GetWorkflowInstanceStepsAsync(int instanceId)
        {
            var request = new RestRequest($"WorkflowInstance/steps/{instanceId}", Method.Get);
            request.AddHeader("Accept", "application/json");
            var response = await _client.ExecuteAsync<List<WorkflowStepDto>>(request);
            return HandleResponse(response);
        }

        // ================= WorkflowExecution =================
        public async Task CompleteWorkflowStepAsync(CompleteWorkflowStepCommand command)
        {
            var request = new RestRequest("WorkflowExecution/complete-step", Method.Post);
            request.AddJsonBody(command);
            var response = await _client.ExecuteAsync(request);
            HandleResponse(response);
        }

        // ================= Role =================
        public async Task<List<RoleDto>?> GetRolesAsync()
        {
            var request = new RestRequest("Roll/list", Method.Get);
            request.AddHeader("Accept", "application/json");
            var response = await _client.ExecuteAsync<List<RoleDto>>(request);
            return HandleResponse(response);
        }

        //public async Task<RoleDto?> CreateRoleAsync(CreateRollCommand command)
        //{
        //    var request = new RestRequest("Roll/create", Method.Post);
        //    request.AddJsonBody(command);
        //    var response = await _client.ExecuteAsync<RoleDto>(request);
        //    return HandleResponse(response);
        //}



        private string ExtractValidationMessage(string content)
        {
            if (string.IsNullOrEmpty(content)) return "خطای ناشناخته";

            try
            {
                var json = System.Text.Json.JsonDocument.Parse(content);
                if (json.RootElement.TryGetProperty("detailed", out var detailed))
                {
                    var lines = detailed.GetString()!
                        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(l => l.Contains("--")) // فقط خطوط فیلدها
                        .Select(l =>
                        {
                            // حذف "Severity: Error"
                            var indexSeverity = l.IndexOf("Severity:");
                            if (indexSeverity > 0)
                                l = l.Substring(0, indexSeverity).Trim();

                            // حذف نام انگلیسی قبل از ":" و "--"
                            var colonIndex = l.IndexOf(":");
                            if (colonIndex >= 0 && colonIndex + 1 < l.Length)
                                return l.Substring(colonIndex + 1).Trim();

                            return l.Trim();
                        });

                    return string.Join("\n", lines);
                }
            }
            catch
            {
                // اگر JSON نبود، پیام را مستقیم برگردان
                return content;
            }

            return content;
        }


    }
}
