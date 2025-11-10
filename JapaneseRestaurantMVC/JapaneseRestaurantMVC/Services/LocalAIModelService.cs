using System;

namespace JapaneseRestaurant.Services
{
    public class LocalAIModelService
    {
        private static LocalAIModelService? _instance;
        private static readonly object _lock = new object();

        private string _modelPath;

        private LocalAIModelService()
        {
            _modelPath = "Models/my_local_model.bin";

        }

        public static LocalAIModelService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LocalAIModelService();
                        }
                    }
                }
                return _instance;
            }
        }

        public string GenerateRecommendation(string input)
        {
            if (input.Contains("sushi", StringComparison.OrdinalIgnoreCase))
                return "Try the salmon roll!";
            else if (input.Contains("ramen", StringComparison.OrdinalIgnoreCase))
                return "Our chef recommends trying today's special!";
            else
                return "Add extra noodles for better taste!";
        }

    }
}
