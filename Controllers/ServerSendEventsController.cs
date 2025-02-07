using Microsoft.AspNetCore.Mvc;

namespace StockTicker.ServerSentEvents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerSendEventsController : ControllerBase
    {
        private readonly ILogger<ServerSendEventsController> _logger;

        public ServerSendEventsController(ILogger<ServerSendEventsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "stream")]
        public async Task StreamStockService()
        {
            Response.ContentType = "text/event-stream";
            var random = new Random();
            for (int i = 0; i < 10; i++) {

                var stockPrice = random.Next(100, 500);

                await Response.WriteAsync($"data: online Stock price: {stockPrice} at {DateTime.Now}\n\n");

                await Response.Body.FlushAsync();

                await Task.Delay(2000);
            }
        }
    }
}
