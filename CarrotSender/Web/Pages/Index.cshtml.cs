using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CarrotSender.Business.Abstracts;

namespace CarrotSender.Web.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ISenderManager _senderManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<IndexModel> _logger;

        public const string CarrotSentMessageKey = nameof(CarrotSentMessageKey);

        public string DefaultMessageQueueName => _configuration.GetValue<String>("MessageBusSettings:QueueSettings:DefaultQueueName");

        public bool IsBusReady { get; }

        [BindProperty, Display(Name = "Rabbit name you want the carrot to be sent for")]
        public string MessageQueueName { get; set; }

        [BindProperty, Display(Name = "Carrot name")]
        public string ExchangeName { get; set; }

        [BindProperty, Display(Name = "The carrot in JSON format:)")]
        public string JsonToSend { get; set; }

        public IndexModel(ISenderManager senderManager,
            IConfiguration configuration,
            ILogger<IndexModel> logger)
        {
            _senderManager = senderManager;
            _configuration = configuration;
            _logger = logger;

            IsBusReady = _senderManager.IsBusReady;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(JsonToSend))
            {
                return BadRequest();
            }

            if (!String.IsNullOrEmpty(ExchangeName))
            {
                _senderManager.SendMessageToExchange(ExchangeName, JsonToSend);
            }
            else
            {
                var queue = DefaultMessageQueueName;
                if (!String.IsNullOrEmpty(MessageQueueName))
                {
                    queue = MessageQueueName;
                }

                _senderManager.SendMessageToQueue(queue, JsonToSend);
            }

            TempData[CarrotSentMessageKey] = "Carrot has been successfully sent! Rabbit is happy and says \"yum - yum\"!";
            return RedirectToAction(Request.Path);
        }
    }
}