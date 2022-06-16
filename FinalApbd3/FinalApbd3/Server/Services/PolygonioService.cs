using System;
using WebSocket4Net;
using System.Security.Authentication;
using System.Collections.Generic;
using FinalApbd3.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;

namespace FinalApbd3.Server.Services
{
    public class PolygonioService:IPolygonService
    {
        private HttpClient _client;
        public PolygonioService(HttpClient client) 
        {
            _client = client;
        }

        public async Task<string> getCompanyContainer(string ticker)
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var test = await _client.GetAsync("https://api.polygon.io/v2/aggs/ticker/A/range/1/day/2021-07-22/2021-07-29?adjusted=true&sort=asc&limit=120&apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B");
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            return response;
        }

        WebSocket websocket;
        public void Start()
        {
            this.websocket = new WebSocket("wss://socket.polygon.io/stocks", sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);
            this.websocket.Opened += websocket_Opened;
            this.websocket.Error += websocket_Error;
            this.websocket.Closed += websocket_Closed;
            this.websocket.MessageReceived += websocket_MessageReceived;
            this.websocket.Open();
            Console.ReadKey();
        }
        private void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Connected!");
            this.websocket.Send("{\"action\":\"auth\",\"params\":\"YOUR_API_KEY\"}");
            this.websocket.Send("{\"action\":\"subscribe\",\"params\":\"T.AAPL\"}");
        }
        private void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine("WebSocket Error");
            Console.WriteLine(e.Exception.Message);
        }
        private void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Connection Closed...");
            // Add Reconnect logic... this.Start()
        }
        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        
    }
}
