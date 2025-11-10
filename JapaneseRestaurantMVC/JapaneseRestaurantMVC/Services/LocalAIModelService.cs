using System;

//Singleton Pattern - гарантира, че в цялата програма съществува само един
//екземпляр от даден клас и предоставя глобална точка за достъп до него

namespace JapaneseRestaurant.Services
{
    public class LocalAIModelService
    {
        private static LocalAIModelService? _instance;  
        //тази променлива съхранява единствения екземпляр на услугата

        private static readonly object _lock = new object();
        //нужно е, за да може две заявки да не създават два екземпляра едновременно

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
        //това свойство проверява дали _instance е null, ако е null се създава нов
        //в противен случай се използва повторно съществуващият

        public string GenerateRecommendation(string input)
        {
            if (input.Contains("sushi", StringComparison.OrdinalIgnoreCase))
                return "Try the salmon roll!";
            else if (input.Contains("ramen", StringComparison.OrdinalIgnoreCase))
                return "Our chef recommends trying today's special!";
            else
                return "Add extra noodles for better taste!";
        }
        //този метод може да бъде извикан от controller-ите или views
        //този код трябва да ми е AI recommendation-на, но за сега е просто if цикъл ;-;
    }
}
