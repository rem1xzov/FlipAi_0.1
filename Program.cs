using System;

namespace AI
{
    class Program
    {
        // Написание искусственного нейрона
        public class Neuron
        {
            // Вес нейрона, который будет изменяться в процессе обучения
            private decimal weight = 0.5m;
            // Последняя ошибка, которая будет использоваться для корректировки веса
            public decimal LastError { get; private set; }
            // Параметр сглаживания, который помогает избежать слишком больших корректировок веса
            public decimal Smoothing { get; set; } = 0.00001m;

            // Метод для обработки входных данных и получения результата
            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }
            // Метод для восстановления входных данных из выходных данных (обратная функция)
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }
            // Метод для обучения нейрона на основе входных данных и ожидаемого результата
            public void Train (decimal input, decimal expectedResult)
            {
                // Вычисляем фактический результат на основе текущего веса
                var actualResult = input * weight;
                // Вычисляем ошибку как разницу между ожидаемым результатом и фактическим результатом
                LastError = expectedResult - actualResult;
                // Вычисляем корректировку веса на основе ошибки и параметра сглаживания
                var correction = (LastError / actualResult) * Smoothing;// Smoothing сглаживание 
                weight += correction;
            }

        }
        // Обучае искусственный нейрое
        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();
           
            int i = 0;
            do
            {
                i++;
                neuron.Train (km, miles);
                Console.WriteLine($"Итерация: {i}\tОшибка:\t{neuron.LastError}");
            }while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine($"{ neuron.ProcessInputData(100)} миль в {100} км");
            Console.WriteLine($"{neuron.ProcessInputData(10)} миль в {10} км");
            Console.WriteLine($"{neuron.RestoreInputData(541)} км в {541} миль");
        }
    
    }
}
