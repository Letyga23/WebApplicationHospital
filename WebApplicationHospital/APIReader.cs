
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebApplicationHospital.Data.Models;

namespace WebApplicationHospital
{
    internal class APIReader
    {
        private static readonly string url = "http://192.168.0.103:5181/";
        private static readonly HttpClient client = SettingHttpClient();

        public static HttpClient SettingHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            HttpClient client = new HttpClient(handler);
            return client;
        }

        public static async Task<Patient> getPatient(int id)
        {
            if (!await canConnectToAPI())
                return null;

            Patient patient = null;
            HttpResponseMessage response = await client.GetAsync(url + $"Patient/Get/{id}"); 
            if (response.IsSuccessStatusCode)
            {
                patient = await response.Content.ReadFromJsonAsync<Patient>();
            }
            return patient;
        }

        public static async Task<List<Patient>> getPatients()
        {
            if (!await canConnectToAPI())
                return null;

            List<Patient> patients = null;
            HttpResponseMessage response = await client.GetAsync(url + "Patient/Get");
            if (response.IsSuccessStatusCode)
            {
                patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
            }
            return patients;
        }

        public static async Task<bool> canConnectToAPI()
        {
            try
            {
                await client.GetAsync(url);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<bool> updatePatient(Patient patient)
        {
            if (!await canConnectToAPI())
                return false;

            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(url + $"/Patient/Put/{patient.Id_Patient}", patient);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<bool> addPatient(Patient patient)
        {
            if (!await canConnectToAPI())
                return false;

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(url + $"/Patient/Post", patient);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
