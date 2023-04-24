using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
   public class MultiplicationTable
    {
            /*Pseudo kod för denna uppgift skulle kunna se ut ungefär såhär. 
            Metoden kommer inte behöva något värde inmatat för att den ska skriva ut multipliktionstabellerna från 1-9 oavsätt.
            Det finns ingen variation för output.
            Så hur den skulle kunna se ut på ett ungefär. 
            for (int i =1; i<10; i++){
                for(int j =1; j<10; j++){
                    Console.WriteLine(i*j)
                    }
            }
            Kom på att man behöver lagra datan också så gjorde så att koden sparas i en 2d array och retunerar den,
            */
        
        public static int[,] CreateMultiplicationTable( )
        {
            int[,] result = new int[10, 10];
            for (int i = 1; i < 10; i++)// make the tables 1-9
            {
                Console.WriteLine("\n{0}:ans-tabell\n", i);

                for (int j = 1; j < 10; j++) // Multiplý each number 1-10
                {
                    result[i, j] = i*j;
                    Console.WriteLine(result[i,j]);
                    
                }
            }
            return result;
        }
    }
}
