using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Lesson_6_Multithreading
{
    class Practice
    {      
        /// <summary>
        /// LA8.P1/X. Написать консольные часы, которые можно останавливать и запускать с 
        /// консоли без перезапуска приложения.
        /// </summary>
        public static void LA8_P1_5()
        {            
        }

        /// <summary>
        /// LA8.P2/X. Написать консольное приложение, которое “делает массовую рассылку”. 
        /// </summary>
        public static void LA8_P2_5()
        {
            var rnd = new Random();
            DateTime time1, time2 = new DateTime();
            time1 = DateTime.Now;

            for (int i = 0; i < 50; i++)
            {
                int temp = i;   //замыкание??
                ThreadPool.QueueUserWorkItem((object state)=> 
                {
                    using (StreamWriter fileCreator = new StreamWriter($@"D:\миша_документы\курсы 2018\С# basic\Wav\{temp}.txt"))
                    {
                        fileCreator.Write($"file {temp}");
                        Thread.Sleep(rnd.Next(100, 500));
                    }
                });                
            }
            time2 = DateTime.Now;            
            Console.WriteLine("\n\n\n" + ((time2 - time1).Seconds).ToString());
            Console.ReadKey();

        }

        /// <summary>
        /// Написать код, который в цикле (10 итераций) эмулирует посещение 
        /// сайта увеличивая на единицу количество посещений для каждой из страниц.  
        /// </summary>
        public static void LA8_P3_5()
        {            
        }

        /// <summary>
        /// LA8.P4/X. Отредактировать приложение по “рассылке” “писем”. 
        /// Сохранять все “тела” “писем” в один файл. Использовать блокировку потоков, чтобы избежать проблем синхронизации.  
        /// </summary>
        public static void LA8_P4_5()
        {
            var rnd = new Random();
            object ForLock = new object();          

            for (int i = 0; i < 50; i++)
            {
                int temp = i;   //замыкание??
                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    lock (ForLock)
                    {
                        using (StreamWriter fileCreator = new StreamWriter($@"D:\миша_документы\курсы 2018\С# basic\Wav\LA8_P4_5.txt", true))
                        {                        
                             fileCreator.WriteLine($"file {temp} ");                                               
                             //Thread.Sleep(rnd.Next(100, 500));
                        }
                    }
                    Thread.Sleep(rnd.Next(100, 500));
                });
            }
            
            Console.ReadKey();

        }

        /// <summary>
        /// LA8.P5/5. Асинхронная “отсылка” “письма” с блокировкой вызывающего потока 
        /// и информировании об окончании рассылки (вывод на консоль информации 
        /// удачно ли завершилась отсылка). 
        /// </summary>
        public async static void LA8_P5_5()
        {           
        }
    }    
}
